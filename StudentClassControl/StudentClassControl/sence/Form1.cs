using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Drawing.Printing;
using System.IO;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;
using System.Drawing.Drawing2D;
using MySql.Data.MySqlClient;
using StudentClassControl.ServiceReference1;

namespace StudentClassControl
{
    public partial class Form1 : Form
    {
        Service1Client mc = new Service1Client();
        public Form1()
        {
            InitializeComponent();
            //printButton.Text = "Print Form";
            //printButton.Click += new EventHandler(printButton_Click);
            //printDocument1.PrintPage += new PrintPageEventHandler(PrintDocument1_PrintPage);
            //this.Controls.Add(printButton);
            namenum.Text = FormControl.person.id;
            name.Text = FormControl.person.name;
        }
        //void printButton_Click(object sender, EventArgs e)
        //{
        //    CaptureScreen();
        //    printDocument1.Print();
        //}
        //private Button printButton = new Button();
        //private PrintDocument printDocument1 = new PrintDocument();
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Button1_Click(object sender, EventArgs e)
        {
            Class1 cs = new Class1();
            dataGridView1.DataSource = null;
            DataSet ds = cs.GetData();
            if (ds != null)
            {
                //DataSet ds = cs.GetData();
                DataTable dt = ds.Tables[0];
                dataGridView1.DataSource = dt;
                MessageBox.Show(cs.Getnumber(ds, 1, 1) + "**" + dt.Rows[0][0].ToString());
                for (int i = 0; i < 5; i++)
                {
                    for (int j = 0; j < 5; j++)
                    {
                        textBox1.Text = textBox1.Text + dt.Rows[0][0].ToString();
                    }
                }
            }

            //dataGridView1.DataSource = dt;
            //DataSet sd = cs.GetData();
            //MessageBox.Show(cs.Getnumber(ds,1,1)+"**"+dt.Rows[1][1].ToString());
        }

        private Bitmap Drawimage()
        {
            MessageBox.Show(this.Name + this.Size + this.ClientSize);
            Bitmap bm = new Bitmap(this.Width, this.Height);
            Rectangle rc = SystemInformation.WorkingArea;
            using (Graphics g = Graphics.FromImage(bm))
            {
                // this.Width = (int)(this.Width*1.25f);
                //this.Height = (int)(this.Height*1.25f);
                /*int wi = (int)(this.Left *1.3f);
                int hi = (int)(this.Top *1.25f);
                Size size = this.Size;
                size.Width = (int)(size.Width * 2f);
                size.Height = (int)(size.Height * 2f);*/
                g.CopyFromScreen(rc.X, rc.Y, 0, 0, rc.Size, CopyPixelOperation.SourceCopy);
            }
            return bm;
        }





        private void Saveimage(Bitmap bp)
        {
            //byte[] bt=null;
            bp.Save("D:\\test\\123.jpg", ImageFormat.Jpeg);
            //File.WriteAllBytes("D:\\test\\123.jpg", bt);
        }


        Bitmap memoryImage;

        private void CaptureScreen()
        {
            Graphics myGraphics = this.CreateGraphics();
            Size s = this.Size;
            //MessageBox.Show(this.Size.ToString());

            // s.Width = Convert.ToInt32(s.Width * 1.25f);//s.Width * 1.2f;
            //s.Height = Convert.ToInt32(s.Height * 1.25f);
            Rectangle rc = SystemInformation.VirtualScreen;
            memoryImage = new Bitmap(s.Width, s.Height, myGraphics);
            Graphics memoryGraphics = Graphics.FromImage(memoryImage);

            memoryGraphics.CopyFromScreen(rc.X, rc.Y, 0, 0, rc.Size, CopyPixelOperation.SourceCopy);
        }

        private void PrintDocument1_PrintPage(System.Object sender,
               System.Drawing.Printing.PrintPageEventArgs e)
        {
            e.Graphics.DrawImage(memoryImage, 0, 0);
        }
        private void button1_Click_1(object sender, EventArgs e)
        {

            Bitmap bit = new Bitmap((int)(this.Width * 1.25f), (int)(this.Height * 1.25f));//实例化一个和窗体一样大的bitmap
            Graphics g = Graphics.FromImage(bit);
            g.CompositingQuality = CompositingQuality.HighQuality;//质量设为最高
            int newleft = (int)(this.Left * 1.25f);
            int newtop = (int)(this.Top * 1.25f);
            g.CopyFromScreen(newleft, newtop, 0, 0, new Size((int)(this.Width * 1.25f), (int)(this.Height * 1.25f)), CopyPixelOperation.SourceCopy);//保存整个窗体为图片
                                                                                                                                                    //g.CopyFromScreen(panel游戏区 .PointToScreen(Point.Empty), Point.Empty, panel游戏区.Size);//只保存某个控件(这里是panel游戏区)
                                                                                                                                                    //bit.Save("weiboTemp.png");//默认保存格式为PNG，保存成jpg格式质量不是很好
            bit.Save("D:\\test\\123.jpg", ImageFormat.Jpeg);
            //Saveimage(Drawimage());
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            MysqlControl.Loadmysql();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics; //创建画板,这里的画板是由Form提供的.
            Pen p = new Pen(Color.Blue, 2);//定义了一个蓝色,宽度为2的画笔
            g.DrawLine(p, 10, 10, 100, 100);//在画板上画直线,起始坐标为(10,10),终点坐标为(100,100)
            g.DrawRectangle(p, 10, 10, 100, 100);//在画板上画矩形,起始坐标为(10,10),宽为,高为
            g.DrawEllipse(p, 10, 10, 100, 100);//在画板上画椭圆,起始坐标为(10,10),外接矩形的宽为,高为100
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ////新建一个修改密码的窗体
            student_1 st1 = new student_1();
            ////将窗体的TopLevel属性设为false，即窗体显示不是顶级窗口
            st1.TopLevel = false;
            ////清空panel控件的内容
            this.panel2.Controls.Clear();
            ////向panel控件中添加窗体
            this.panel2.Controls.Add(st1);
            ////panel控件内显示窗体
            st1.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            student_2 st2 = new student_2();
            st2.TopLevel = false;
            this.panel2.Controls.Clear();
            this.panel2.Controls.Add(st2);
            st2.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            student_3 st3 = new student_3();
            st3.TopLevel = false;
            this.panel2.Controls.Clear();
            this.panel2.Controls.Add(st3);
            st3.Show();
        }
    }
}
