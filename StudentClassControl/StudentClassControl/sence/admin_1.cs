using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;

namespace StudentClassControl
{
    public partial class admin_1 : Form
    {
        Dictionary<string, string> Address = new Dictionary<string, string>();
        MysqlControl mc = new MysqlControl();
        public admin_1()
        {
            InitializeComponent();

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
                    comboBox1.Items.Add(province);
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
                if (key == 1)
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

        private void button2_Click(object sender, EventArgs e)
        {
            //导出模板
            Excel.Application excel = new Excel.Application();
            excel.Application.Workbooks.Add(true);
            excel.Visible = false;//是否打开该Excel文件
       
            //填充数据 
            excel.Cells[1, 1] = "学号";
            excel.Cells[1, 2] = "姓名";
            excel.Cells[1, 3] = "性别";
            excel.Cells[1, 4] = "班级";
            excel.Cells[1, 5] = "专业";
            excel.Cells[1, 6] = "学院";
            excel.Cells[1, 7] = "入学年份";
            excel.GetSaveAsFilename( "学生信息表");
        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Class1 cs = new Class1();
            dataGridView1.DataSource = null;
            DataSet ds = cs.GetData();
            dataGridView1.DataSource = ds;
        }
    }
}
