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
    public partial class Formupdate : Form
    {

        //数据查询对象
        Service1Client mc = new Service1Client();

        public Formupdate()
        {
            InitializeComponent();
        }

        private void Formupdate_Load(object sender, EventArgs e)
        {
            textBox1.Text = FormControl.person.id;
            textBox2.Text = "";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //修改密码
            string username = textBox1.Text;
            string password = textBox3.Text;
            string passnew = textBox2.Text;
            if (username == "" || password == "" || passnew == "")
            {
                //输入存在空值
                MessageBox.Show("请输入完整信息");
            }
            else
            {
                //判断用户名密码是否正确 power>0 正确
                int power = mc.Loadding(username, password);
                if (power > 0)
                {
                    DialogResult result = MessageBox.Show("确定将密码更改为 ：" + passnew,"修改", MessageBoxButtons.OKCancel);
                    if (result == DialogResult.OK)
                    {
                        int ch = mc.Changepassward(passnew, username);
                        if (ch > 0)
                        {
                            MessageBox.Show("修改成功");
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show("修改失败");
                        }
                    }
                }
                else
                {
                    MessageBox.Show("旧密码不正确");
                }
            }
        }
    }
}
