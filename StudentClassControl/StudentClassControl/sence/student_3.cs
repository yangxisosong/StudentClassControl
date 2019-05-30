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

namespace StudentClassControl
{
    public partial class student_3 : Form
    {
        Service1Client mc = new Service1Client();
        public student_3()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text != "")
            {
                string year = comboBox1.Text;
                //获取学生选课表
                string tim_year = DateTime.Now.Year.ToString();
                string tim_month = DateTime.Now.Month > 5 ? "2" : "1";
                string sql = "SELECT * FROM chose_class WHERE stu_id='" + FormControl.person.id + "' AND class_time= '" +year+ "' ;";
                DataSet stu_cla = mc.Selectout(sql, "chose_class");
                //保存已选课程
                //List<string> class_old = new List<string>();
                string sqlgettime = "SELECT * FROM choseclass WHERE class_id  IN("; //10000','12225','45678');";
                for (int i = 0; i < stu_cla.Tables[0].Rows.Count; i++)
                {
                    //class_old.Add(stu_cla.Tables[0].Rows[i][1].ToString());
                    sqlgettime = sqlgettime + "'" + stu_cla.Tables[0].Rows[i][1].ToString() + "'";
                    if (i + 1 < stu_cla.Tables[0].Rows.Count)
                    {
                        sqlgettime += ",";
                    }
                    else
                    {
                        sqlgettime += ");";
                    }
                }
                //已选课程时间获取
                DataSet class_timeold = mc.Selectout(sqlgettime, "choseclass");

                DataTable dt = new DataTable("subject");
                dt.Columns.Add("课程名称", typeof(string));
                dt.Columns.Add("学分", typeof(string));
                dt.Columns.Add("考试成绩", typeof(string));

                for (int j = 0; j < stu_cla.Tables[0].Rows.Count; j++)  //用循环添加4个行集~
                {
                    DataRow dr = dt.NewRow();
                    dt.Rows.Add(dr);
                }
                for (int h = 0; h < stu_cla.Tables[0].Rows.Count; h++)
                {

                    dt.Rows[h][0] = class_timeold.Tables[0].Rows[h][1].ToString();
                    dt.Rows[h][1] = class_timeold.Tables[0].Rows[h][2].ToString();
                    dt.Rows[h][2] = stu_cla.Tables[0].Rows[h][2].ToString();
                }

                //设置不自动增加行
                dataGridView1.AllowUserToAddRows = false;
                //取消左边 选择列
                dataGridView1.RowHeadersVisible = false;
                //行宽
                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dataGridView1.DataSource = dt;

            }
            else
            {
                MessageBox.Show("请选择学期");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (dataGridView1.DataSource != null)
            {
                Excelcon ex = new Excelcon();
                ex.ExportExcel_stulife("成绩单", dataGridView1);
            }
            else
            {
                MessageBox.Show("请先导入数据");
            }
        }
    }
}
