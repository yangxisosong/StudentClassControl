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
    public partial class teacher_2 : Form
    {
        Service1Client mc = new Service1Client();
        DataSet tea_class;
        DataSet stu;
        public teacher_2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int index = listBox1.SelectedIndex;
            string stulif = textBox1.Text;
            string sql = "UPDATE chose_class SET stu_life="+stulif+" WHERE class_id='"+
                stu.Tables[0].Rows[index][8]+"' And stu_id="+ stu.Tables[0].Rows[index][0];
            int key = mc.Myinsert(sql);
        }

        private void teacher_2_Load(object sender, EventArgs e)
        {
            string sql = "SELECT * FROM choseclass WHERE teacher='" + FormControl.person.id + "'";
            tea_class = mc.Selectout(sql, "choseclass");

          
            for (int i = 0; i < tea_class.Tables[0].Rows.Count; i++)
            {
                listBox1.Items.Add(tea_class.Tables[0].Rows[i][1].ToString());
            }

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            listBox2.Items.Clear();
            //当前行号 
            int index = listBox1.SelectedIndex;
            //MessageBox.Show(tea_class.Tables[0].Rows[index][0].ToString());
            string sql_stu = "select * from student inner join chose_class on student.id=chose_class.stu_id AND chose_class.class_id = '"+
                tea_class.Tables[0].Rows[index][0].ToString() + "'";
            stu = mc.Selectout(sql_stu, "student");
            int ts = stu.Tables[0].Rows.Count;
            for (int k = 0; k < ts; k++)
            {
                listBox2.Items.Add(stu.Tables[0].Rows[k][1]);
            }
        }

        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = listBox2.SelectedIndex;
            if (stu != null)
            {
                label5.Text = stu.Tables[0].Rows[index][1].ToString();
                label6.Text = stu.Tables[0].Rows[index][4].ToString();
                label7.Text = stu.Tables[0].Rows[index][3].ToString();
                label9.Text = stu.Tables[0].Rows[index][5].ToString();
            }
        }
    }
}
