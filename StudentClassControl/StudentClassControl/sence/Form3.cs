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
        public Form3()
        {
            InitializeComponent();
            namenum.Text = FormControl.person.id;
            name.Text = FormControl.person.name;
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            namenum.Text = FormControl.person.id;
        }

        private void namenum_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
