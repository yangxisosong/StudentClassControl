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
            FormControl.weaktime = null;
            foreach (Control c in groupBox1.Controls)
            {
                if (c is CheckBox)
                {
                    CheckBox ck = c as CheckBox;
                    if (ck.Checked == true)
                    {
                        //int num = int.Parse(ck.Tag.ToString());
                        //int key = num / 10;
                        //int value = num - key * key;
                        //FormControl.keyValues.Add(key.ToString(), value.ToString());
                        FormControl.weaktime = FormControl.weaktime + ck.Tag.ToString()+"*";
                    }
                }
            }
            //string ts = "12*56*89";
            //string[] arry = ts.Split('*');
            //foreach (string i in arry) {
            //    MessageBox.Show(i+arry.Length);
            //}
            //MessageBox.Show(FormControl.weaktime);

            
            this.Close();
        }
    }
}
