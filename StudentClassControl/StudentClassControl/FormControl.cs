using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StudentClassControl
{
    class FormControl
    {
        public static void Changeform(int key,formload fl)
        {
            switch (key)
            {
                case 1:
                    //学生
                    Form1 fm1 = new Form1();
                    fl.Hide();
                    fm1.ShowDialog();
                    Application.ExitThread();
                    break;
                case 2:
                    //老师
                    Form3 form3 = new Form3();
                    fl.Hide();
                    form3.ShowDialog();
                    Application.ExitThread();
                    break;
                case 3:
                    //管理员
                    Formselect formselect = new Formselect();
                    fl.Hide();
                    formselect.ShowDialog();
                    Application.ExitThread();
                    break;
            }
        }
    }
}
