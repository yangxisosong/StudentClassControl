using StudentClassControl.ServiceReference1;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace StudentClassControl
{
    public partial class teacher_3 : Form
    {
        Service1Client mc = new Service1Client();
        DataSet teaclass;
        public teacher_3()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            chart1.Series.Clear();
            string tea_class = teaclass.Tables[0].Rows[comboBox1.SelectedIndex][0].ToString();
            string tea_year = comboBox2.Text;
            if (tea_year == "" || tea_class == "")
            {
                MessageBox.Show("添加查询信息");
                return;
            }
            string sql = "select * from student inner join chose_class on student.id=chose_class.stu_id AND chose_class.class_id = " +
                tea_class+ " AND chose_class.class_time='"+tea_year+"'";
            DataSet ds= mc.Selectout(sql,"chose_class");
            if (ds == null||ds.Tables[0].Rows.Count == 0)
            {
                MessageBox.Show("无成绩信息");
                return;
            }
            DataTable dt = new DataTable("stu_life");
            dt.Columns.Add("姓名", typeof(string));
            dt.Columns.Add("成绩", typeof(int));
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                DataRow dr = dt.NewRow();
                dt.Rows.Add(dr);
            }
            //MessageBox.Show(ds.Tables[0].Rows[0][0].ToString());
            for (int j = 0; j < ds.Tables[0].Rows.Count; j++)
            {
                dt.Rows[j][0] = ds.Tables[0].Rows[j][1];
                dt.Rows[j][1] = ds.Tables[0].Rows[j][9];
            }

            //取均值
            label4.Text = dt.Compute("Avg(成绩)", "true").ToString();
            //取最大值
            label5.Text = dt.Compute("Max(成绩)", "true").ToString();
            //取最小值
            label6.Text = dt.Compute("Min(成绩)", "true").ToString();

            Series dataTable3Series = new Series("成绩");
            dataTable3Series.Points.DataBind(dt.AsEnumerable(), "姓名", "成绩", "");
            dataTable3Series.XValueType = ChartValueType.String;//设置X轴类型为时间
            dataTable3Series.ChartType = SeriesChartType.Line;  //设置Y轴为折线
            chart1.Series.Add(dataTable3Series);//加入你的chart1
        }

        private void teacher_3_Load(object sender, EventArgs e)
        {
            chart1.Series.Clear();
            string sql = "SELECT * FROM choseclass WHERE teacher='" + FormControl.person.id + "'";
            teaclass = mc.Selectout(sql, "choseclass");


            for (int i = 0; i < teaclass.Tables[0].Rows.Count; i++)
            {
                comboBox1.Items.Add(teaclass.Tables[0].Rows[i][1].ToString());
            }
        }
    }
}
