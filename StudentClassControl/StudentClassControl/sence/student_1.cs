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
    public partial class student_1 : Form
    {
        Service1Client mc = new Service1Client();
        public student_1()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string classid = textBox1.Text;
            string classname = textBox2.Text;
            string classlave = comboBox2.Text;
            string classweek = comboBox1.Text;
            string classtime = comboBox3.Text;
            List<string> mList = new List<string>();

            if (classid == "" && classname == "" && classlave == "" && classweek == "" && classtime == "")
            {
                MessageBox.Show("请添加查询内容");
            }
            else
            {
                string sqlstu = "SELECT * FROM choseclass WHERE ";
                if (classid != "") mList.Add("class_id= '" + classid + "'");
                if (classname != "") mList.Add("class_name= '" + classname + "'");
                if (classlave != "") mList.Add("classlave= '" + classlave + "'");
                for (int i = 0; i < mList.Count; i++)
                {
                    sqlstu += mList[i];
                    if (i + 1 < mList.Count)
                    {
                        sqlstu += " AND ";
                    }
                    else
                    {

                    }
                }
                DataSet data = mc.Selectout(sqlstu, "choseclass");
                if (data != null && data.Tables[0].Rows.Count != 0)
                {
                    //dataGridView4.DataSource = data.Tables[0];

                    //dataGridView1.DataSource = data.Tables[0];
                    //dataGridView1.Columns[0].HeaderText = "课程号";
                    //dataGridView1.Columns[1].HeaderText = "课程名";
                    //dataGridView1.Columns[2].HeaderText = "学分";
                    //dataGridView1.Columns[3].HeaderText = "教师工号";
                    //dataGridView1.Columns[4].HeaderText = "课程类型";
                    //dataGridView1.Columns[5].HeaderText = "开始周数";
                    //dataGridView1.Columns[6].HeaderText = "结束周数";
                    //dataGridView1.Columns[7].HeaderText = "教学楼";
                    //dataGridView1.Columns[8].HeaderText = "教室";
                    //dataGridView1.Columns[9].HeaderText = "上课时间";
                    //this.dataGridView1.Columns[0].DataPropertyName = data.Tables[0].Columns["class_id"].ToString();
                    //dataGridView1.AutoGenerateColumns = false;


                    DataTable dt = data.Tables[0];
                    //dataGridView1.Columns.Add("class_id", "class_name");//添加新列
                    //DataTable dt = oper.GetDataTable("db_time");//获取数据表
                    //foreach (DataColumn col in dataGridView1.Columns)
                    //{
                        dataGridView1.Columns.Add("123","321");
                    //}
                    dataGridView1.Rows.Clear();
                    dataGridView1.Rows.Add(dt.Rows.Count);//增加同等数量的行数
                    int i = 0;
                    foreach (DataRow row in dt.Rows)//逐个读取单元格的内容；
                    {
                        DataGridViewRow r1 = dataGridView1.Rows[i];
                        r1.Cells[0].Value = row.RowState.ToString();
                        for (int j = 0; j < dataGridView1.Columns.Count; j++)
                        {
                            r1.Cells[j + 1].Value = row[j].ToString();
                        }
                        i++;
                    }
                }
                else
                {
                    MessageBox.Show("查询失败");
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }
    }
}
