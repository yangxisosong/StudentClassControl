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
    public partial class teacher_1 : Form
    {
        Service1Client mc = new Service1Client();
        DataSet tea_class;
        public teacher_1()
        {
            InitializeComponent();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //MessageBox.Show(e.ToString());
            int index = listBox1.SelectedIndex;
            listBox2.Items.Clear();
            listBox2.Items.Add("课程名称:");
            listBox2.Items.Add(listBox1.SelectedItem.ToString());
            listBox2.Items.Add("");
            listBox2.Items.Add("课程号:");
            listBox2.Items.Add(tea_class.Tables[0].Rows[index][0].ToString());
            listBox2.Items.Add("");
            listBox2.Items.Add("上课教室");
            listBox2.Items.Add(tea_class.Tables[0].Rows[index][7].ToString()+
                tea_class.Tables[0].Rows[index][8].ToString()+"教室");
            listBox2.Items.Add("");
            listBox2.Items.Add("上课时间:");
            listBox2.Items.Add(tea_class.Tables[0].Rows[index][5].ToString()+
                "-"+ tea_class.Tables[0].Rows[index][6].ToString()+"周");
            string[] cla = tea_class.Tables[0].Rows[index][9].ToString().Split('*');
            for (int j = 0; j < cla.Length && cla[j] != ""; j++)
            {
                string weak = cla[j].Substring(0, 1);
                string jie = cla[j].Substring(1);
                listBox2.Items.Add("星期 "+weak+ "第 "+jie+" 节");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text != "")
            {

                string sql = "SELECT * FROM choseclass WHERE teacher='"+FormControl.person.id+"'";
                tea_class = mc.Selectout(sql, "choseclass");
                for (int i = 0; i < tea_class.Tables[0].Rows.Count; i++)
                {
                    listBox1.Items.Add(tea_class.Tables[0].Rows[i][1].ToString());
                }
            }
            else
            {
                MessageBox.Show("请选择学期");
            }
        }
    }
}
