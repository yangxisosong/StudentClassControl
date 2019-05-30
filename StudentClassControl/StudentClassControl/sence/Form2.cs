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
    public partial class formload : Form
    {
        //数据查询对象
        //MysqlControl mc = new MysqlControl();
        Service1Client mc = new Service1Client();
        public formload()
        {
            InitializeComponent();
        }
        //登录
        private void button1_Click(object sender, EventArgs e)
        {
            //判断密码是否正确
            //获取用户名，查询密码
            string username = maskedTextBox1.Text;
            string password = maskedTextBox2.Text;
            if (username == null || password == null)
            {
                MessageBox.Show("输入不完整");
            }
            else
            {
                int power = mc.Loadding(username, password);
                if (power > 0)
                {
                    //MessageBox.Show("登录成功"+power);
                    FormControl.person.id = maskedTextBox1.Text;
                    //切换视窗
                    switch (power)
                    {
                        case 1:
                            //MessageBox.Show(power+"**");
                            //学生
                            DataSet data = mc.Selectin(maskedTextBox1.Text, "student");
                            FormControl.person.name = data.Tables[0].Rows[0][1].ToString();
                            FormControl.Changeform(1, this);
                            break;
                        case 2:
                            //MessageBox.Show(power + "**");
                            //老师
                            DataSet data2 = mc.Selectin(maskedTextBox1.Text, "teacher");
                            FormControl.person.name = data2.Tables[0].Rows[0][1].ToString();
                            FormControl.Changeform(2, this);
                            break;
                        case 3:
                            //MessageBox.Show(power + "**");
                            //管理员
                            FormControl.Changeform(3, this);
                            break;
                    }
                    //Form1 fm1 = new Form1();
                    //this.Hide();
                    //fm1.ShowDialog();
                    //Application.ExitThread();
                }
                else
                {
                    if (power == -1)
                    {
                        MessageBox.Show("当前用户不存在");
                        maskedTextBox2.Text = null;
                        maskedTextBox1.Text = null;
                    }
                    else
                    {
                        MessageBox.Show("密码错误");
                        maskedTextBox2.Text = null;
                    }

                }
            }
        }
        //修改密码
        private void button2_Click(object sender, EventArgs e)
        {
            //获取用户名
            string username = maskedTextBox1.Text;
            if (username == "")
            {
                //MessageBox.Show("11");
                FormControl.Changeform(4, this);
            }
            else
            {
                FormControl.person.id = username;
                FormControl.Changeform(4, this);
            }
        }

        private void formload_Load(object sender, EventArgs e)
        {
            
        }
    }
}
