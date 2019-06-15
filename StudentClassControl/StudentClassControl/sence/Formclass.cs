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
    public partial class Formclass : Form
    {
        public Formclass()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //记录课程时间字符串
            FormControl.weaktime = null;
            foreach (Control c in groupBox1.Controls)
            {
                if (c is CheckBox)
                {
                    CheckBox ck = c as CheckBox;
                    if (ck.Checked == true)
                    {
                        //添加课程时间信息
                        FormControl.weaktime = FormControl.weaktime + ck.Tag.ToString()+"*";
                    }
                }
            }
            this.Close();
        }
    }
}
