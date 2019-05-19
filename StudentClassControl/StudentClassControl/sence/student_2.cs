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
    public partial class student_2 : Form
    {
        Service1Client mc = new Service1Client();
        public student_2()
        {
            InitializeComponent();
        }

        private void myclass(string year)
        {
            DataTable dt = new DataTable("subject");
            dt.Columns.Add("周数/节数", typeof(string));   //添加列集，下面都是
            dt.Columns.Add("周一", typeof(string));
            dt.Columns.Add("周二", typeof(string));
            dt.Columns.Add("周三", typeof(string));
            dt.Columns.Add("周四", typeof(string));
            dt.Columns.Add("周五", typeof(string));
            dt.Columns.Add("周六", typeof(string));
            dt.Columns.Add("周日", typeof(string));

            for (int i = 0; i < 5; i++)  //用循环添加4个行集~
            {
                DataRow dr = dt.NewRow();
                dt.Rows.Add(dr);
            }

            dt.Rows[0][0] = "第1节";  //向第一行里的第一个格中添加一个“第1节”
            dt.Rows[1][0] = "第2节";  //向第二行里的第一个格中添加一个“第 2 节”
            dt.Rows[2][0] = "第3节";  //向第三行里的第一个格中添加一个“第3节”
            dt.Rows[3][0] = "第4节";  //向第四行里的第一个格中添加一个“第4节”
            dt.Rows[4][0] = "第5节";  //向第四行里的第一个格中添加一个“第5节”

            //设置不自动增加行
            dataGridView1.AllowUserToAddRows = false;
            //取消左边 选择列
            dataGridView1.RowHeadersVisible = false;
            //dataGridView1.DataSource = dt;
            //获取学生选课表
            string sql = "SELECT * FROM chose_class WHERE stu_id='" + FormControl.person.id + "' AND class_time= '"+year+"' ;";
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
            //dataGridView1.DataSource = class_timeold.Tables[0];
            for(int j=0; class_timeold !=null&& j<class_timeold.Tables[0].Rows.Count;j++)
            {
                string[] classtime = class_timeold.Tables[0].Rows[j][9].ToString().Split('*');
                for (int k = 0; k < classtime.Length; k++)
                {
                    if (classtime[k] != "")
                    {
                        int wk = int.Parse(classtime[k].Substring(0, 1));
                        int jie = int.Parse(classtime[k].Substring(1));
                        dt.Rows[jie - 1][wk] += class_timeold.Tables[0].Rows[j][1].ToString() +
                            "\n" + class_timeold.Tables[0].Rows[j][5].ToString() +"-"+ class_timeold.Tables[0].Rows[j][6].ToString()+"周"+
                            "\n" + class_timeold.Tables[0].Rows[j][7].ToString()+ class_timeold.Tables[0].Rows[j][8].ToString();
                    }
                }
            }

            //dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCellsExceptHeader; ///根据数据内容自动调整列宽 
            //dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCellsExceptHeaders; ///根据数据内容自动调整行高

            //设置自动换行  
            dataGridView1.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            //设置自动调整高度  
            dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dataGridView1.DataSource = dt;
        }

        private void student_2_Load(object sender, EventArgs e)
        {
           // myclass();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text != "")
            {
                myclass(comboBox1.Text);
            }
            else
            {
                MessageBox.Show("请选择学期");
            }
        }
    }
}
