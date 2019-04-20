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

        public formload()
        {
            InitializeComponent();
        }

        private void maskedTextBox1_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //判断密码是否正确
            //获取用户名，查询密码
            string username = maskedTextBox1.Text;
            string password = maskedTextBox2.Text;
            if (username == null||password==null)
            {
                MessageBox.Show("输入不完整");
            }
            else
            {
                int power = MysqlControl.Loadding(username, password);
                if (power>0)
                {

                    //MessageBox.Show("登录成功"+power);

                    //切换视窗
                    switch (power)
                    {
                        case 1:
                            //MessageBox.Show(power+"**");
                            //学生
                            FormControl.Changeform(1, this);
                        break;
                        case 2:
                            //MessageBox.Show(power + "**");
                            //老师
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
                FormControl.person.id= username;
                FormControl.Changeform(4, this);
            }
        }
    }
}
