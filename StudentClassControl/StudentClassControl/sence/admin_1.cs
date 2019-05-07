using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;

namespace StudentClassControl
{
    public partial class admin_1 : Form
    {
        Dictionary<string, string> Address = new Dictionary<string, string>();
        MysqlControl mc = new MysqlControl();
        Excelcon ex = new Excelcon();
        public admin_1()
        {
            InitializeComponent();
            //初始化专业选择
            DataSet ds = mc.Selectschool("school_dis");
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                //MessageBox.Show(dr[0].ToString());
                Address.Add(dr[0].ToString(), dr[1].ToString());
            }
            foreach (string province in Address.Values)
            {
                //判断下集合内是否有这个院系，避免重复添加
                if (!comboBox1.Items.Contains(province))
                {
                    comboBox1.Items.Add(province);
                    comboBox4.Items.Add(province);
                }             
                
            }
            for (int i = 1990; i < DateTime.Now.Year; i++)
            {
                comboBox3.Items.Add(i);
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
        //定义字典用于下拉列表选择


        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox2.Items.Clear();
            comboBox2.Text = "";
            comboBox1.Text = comboBox1.SelectedItem.ToString();
            //通过值查找键值
            foreach (KeyValuePair<string, string> kvp in Address)
            {
                if (kvp.Value.Equals(comboBox1.SelectedItem.ToString()))
                {
                    comboBox2.Items.Add(kvp.Key);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string id = stuid.Text;
            string name = textBox1.Text;
            string sex = radioButton1.Checked ? "男" : "女";
            string stuclass = textBox3.Text;
            string discipline = comboBox2.Text;
            string college = comboBox1.Text;
            string intime = comboBox3.Text;
            if (id != "" && name != "" && stuclass != "" && discipline != "" && college != "" && intime != "" && (radioButton1.Checked || radioButton2.Checked))
            {
                int key = mc.Insert("student", id, name, sex, stuclass, discipline, college, intime);
                if (key >= 1)
                {
                    MessageBox.Show("信息录入成功！");
                }
                else
                {
                    MessageBox.Show("录入信息失败！");
                }
            }
            else
            {
                MessageBox.Show("请填写完整信息！");
            }
        }

        //导出excel函数
       
        private void button2_Click(object sender, EventArgs e)
        {
            ex.ExportExcel_stu("学生信息表");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (dataGridView1.DataSource == null)
            {
                MessageBox.Show("请先导入信息");
            }
            else
            {
                //格式 [列，行] Rows代表行的集合，Columns代表列的集合。
                string data = dataGridView1[0, 1].Value.ToString();
                //MessageBox.Show(data + dataGridView1[1, 1].Value.ToString() + dataGridView1.Rows.Count);
                string sqlop = "INSERT INTO student VALUES";
                string sqled = "";
                int len = dataGridView1.Rows.Count - 1;
                for (int i = 1; i < len; i++)
                {
                    sqled = sqled + 
                        "('"+ dataGridView1[0, i].Value.ToString() +
                        "', '"+ dataGridView1[1, i].Value.ToString() + 
                        "', '"+ dataGridView1[2, i].Value.ToString() + 
                        "', "+ dataGridView1[3, i].Value.ToString() +
                        ", '"+ dataGridView1[4, i].Value.ToString() +
                        "', '" + dataGridView1[5, i].Value.ToString() +
                        "', " + dataGridView1[6, i].Value.ToString()  + ")";
                    if (i + 1 < len)
                    {
                        sqled = sqled + ",";
                    }
                    else
                    {
                        sqled = sqled + ";";
                    }
                }
                string over = sqlop + sqled;
                MessageBox.Show(over);
                 //sqldata = "INSERT INTO student VALUES" +
                 //   "('123468', '想从事', '男', 1521, '软件工程', '计算机网络', 2016)" +
                 //   ",('123474', '想从事', '男', 1521, '软件工程', '计算机网络', 2016)" +
                 //   ",('123482', '想从事', '男', 1521, '软件工程', '计算机网络', 2016); ";
                int key= mc.Myinsert(sqlop+sqled);
                if (key >= 1)
                {
                    MessageBox.Show("成功录入" + key+"条信息");
                }
                else
                {
                    MessageBox.Show("录入失败");
                }
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Class1 cs = new Class1();
            dataGridView1.DataSource = null;
            DataSet ds = cs.GetData();
            if (ds != null)
            {
                dataGridView1.DataSource = ds.Tables[0];
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            string name = textBox2.Text;
            string classid = textBox4.Text;
            string sex = radioButton3.Checked ? "男" : "女";
            string college = comboBox4.Text;

            string sqlin = "INSERT INTO teacher VALUES " +
                "('"+classid+"','"+name+"','"+sex+"','"+college+"')";
            int key = mc.Myinsert(sqlin);
            if (key >= 1)
            {
                MessageBox.Show("添加成功！");
            }
            else
            {
                MessageBox.Show("添加失败！");
            }

        }

        private void button13_Click(object sender, EventArgs e)
        {
            Formclass fcl = new Formclass();
            fcl.ShowDialog();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            string classnum = textBox6.Text;
            string classname = textBox5.Text;
            string teachernum = textBox7.Text;
            string classroom = comboBox6.Text;
            string classroomid = comboBox7.Text + comboBox8.Text;
            string classop = comboBox5.Text;
            string classed = comboBox9.Text;
            string clweaktime = FormControl.weaktime;

            string sqlin = "INSERT INTO choseclass VALUES " +
                "("+classnum+", '"+classname+"', '"+teachernum+"', "+classop+", "+classed+", '"+classroom+"', "+classroomid+", '"+clweaktime+"'); ";
            int key = mc.Myinsert(sqlin);
            if (key >= 1)
            {
                MessageBox.Show("添加成功");
            }
            else
            {
                MessageBox.Show("添加失败");
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            ex.ExportExcel_tea("教师信息表");
        }

        private void button9_Click(object sender, EventArgs e)
        {
            ex.ExportExcel_cla("课程信息表");
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Class1 cs = new Class1();
            dataGridView2.DataSource = null;
            DataSet ds = cs.GetData();
            if (ds != null)
            {
                dataGridView2.DataSource = ds.Tables[0];
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            Class1 cs = new Class1();
            dataGridView3.DataSource = null;
            DataSet ds = cs.GetData();
            if (ds != null)
            {
                dataGridView3.DataSource = ds.Tables[0];
            }
        }
    }
}
