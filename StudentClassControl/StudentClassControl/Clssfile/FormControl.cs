﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StudentClassControl
{
    struct Person
    {
        public string id;
        public string passward;
        public string lever;
        public string name;
        public string year;
    }
    class FormControl
    {
        public static Person person = new Person();
        public static string weaktime =null;
        public static Dictionary<string, string> keyValues = new Dictionary<string, string>();
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
                    admin_1 admin_1 = new admin_1();
                    fl.Hide();
                    admin_1.ShowDialog();
                    Application.ExitThread();
                    break;
                case 4:
                    //修改密码
                    Formupdate formupdate = new Formupdate();
                    formupdate.ShowDialog();
                    break;
            }
        }
    }
}
