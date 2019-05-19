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

        private void myclass()
        {
            //获取学生选课表
            string sql = "SELECT * FROM chose_class WHERE stu_id='" + FormControl.person.id + "';";
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
            dataGridView1.DataSource = class_timeold.Tables[0];
        }

        private void student_2_Load(object sender, EventArgs e)
        {
            myclass();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            myclass();
        }
    }
}
