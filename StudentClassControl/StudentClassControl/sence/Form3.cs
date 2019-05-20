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
    public partial class Form3 : Form
    {
        Service1Client mc = new Service1Client();
        teacher_1 tea1 = new teacher_1();
        teacher_2 tea2 = new teacher_2();
        teacher_3 tea3 = new teacher_3();
        public Form3()
        {
            InitializeComponent();
            namenum.Text = FormControl.person.id;
            name.Text = FormControl.person.name;

           

            tea1.TopLevel = false;
            tea2.TopLevel = false;
            tea3.TopLevel = false;


            panel2.Controls.Clear();
            ////向panel控件中添加窗体
            panel2.Controls.Add(tea1);
            tea1.Show();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            namenum.Text = FormControl.person.id;
            name.Text = FormControl.person.name;
        }

        private void namenum_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            panel2.Controls.Clear();
            ////向panel控件中添加窗体
            panel2.Controls.Add(tea1);
            ////panel控件内显示窗体
            tea1.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            panel2.Controls.Clear();
            panel2.Controls.Add(tea2);
            tea2.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            panel2.Controls.Clear();
            panel2.Controls.Add(tea3);
            tea3.Show();
        }
    }
}
