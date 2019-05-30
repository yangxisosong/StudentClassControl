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
        DataSet teatable;
        List<string> classtime = new List<string>();
        public student_1()
        {
            InitializeComponent();
            teatable = mc.Selectout("SELECT * FROM teacher", "teacher");
        }
        //查询选课判断
        private bool choseclass(string cl,string []cla)
        {
            string weak = cl.Substring(0,1);
            string weak2 = cl.Substring(1);
            for (int i = 0; i < cla.Length&&cla[i]!=""; i++)
            {
                string getcla = cla[i].Substring(0,1);
                string getcla2 = cla[i].Substring(1);
                //MessageBox.Show(getcla + "/" + getcla.Substring(0,1)+"/"+getcla.Substring(1));
                if (weak == getcla || weak == "*")
                {
                    if (weak2 == getcla2 || weak2 == "*")
                    {
                        return true;
                    }
                }

            }
            //没找到这个课程
            return false;
        }
        //判断是否选课冲突
        private bool checkclass(string[] cla_now,int _op,int _ed)
        {
            //获取学生选课表
            string sql = "SELECT * FROM chose_class WHERE stu_id='" + FormControl.person.id + "';";
            DataSet stu_cla = mc.Selectout(sql, "chose_class");
            //保存已选课程
            //List<string> class_old = new List<string>();
            string sqlgettime = "SELECT * FROM choseclass WHERE class_id  IN("; //10000','12225','45678');";
            for (int i = 0; i < stu_cla.Tables[0].Rows.Count; i++)
            {
                //class_old.Add(stu_cla.Tables[0].Rows[i][1].ToString());
                sqlgettime = sqlgettime + "'" + stu_cla.Tables[0].Rows[i][1].ToString() + "'";
                if (i + 1 < stu_cla.Tables[0].Rows.Count)
                {
                    sqlgettime += ",";
                }
                else
                {
                    sqlgettime += ");";
                }
            }
            //已选课程时间获取
            DataSet class_timeold = mc.Selectout(sqlgettime, "choseclass");
            string classweaklave = "";
            int key = 0;
            if (class_timeold == null)
            {
                return true;
            }
            for (int k = 0; k < class_timeold.Tables[0].Rows.Count; k++)
            {
                //classweaklave += "*" + class_timeold.Tables[0].Rows[k][9].ToString();
                int star_ed = int.Parse(class_timeold.Tables[0].Rows[k][6].ToString());
                //周数是否冲突 _op 当前选择课程的开始时间  star_ed 一条记录的结束时间
                if (star_ed < _op)
                {
                    //选择课程开始时间大于已选课程结束时间
                    key++;
                    if (key  == class_timeold.Tables[0].Rows.Count)
                    {
                        //与所有选课的周都不冲突
                        return true;
                    }
                }
                else
                {
                    classweaklave += "*" + class_timeold.Tables[0].Rows[k][9].ToString();
                }
            }
            string[] checktime = classweaklave.Split('*');

            for (int m = 0; m < cla_now.Length; m++)
            {
                for (int n = 0; n < checktime.Length; n++)
                {
                    if (cla_now[m] == checktime[n]&& cla_now[m]!="")
                    {
                        //存在相同时间
                        return false;
                    }
                }
            }
            return true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            dataGridView1.Columns.Clear();
            string classid = textBox1.Text;
            string classname = textBox2.Text;
            string classlave = comboBox2.Text;
            string classweek = comboBox1.Text;
            string classtime = comboBox3.Text;
            List<string> mList = new List<string>();
            //查询教师表


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
                if(classid == "" && classname == "" && classlave == "")
                {
                    sqlstu = "SELECT * FROM choseclass";
                }
                DataSet data = mc.Selectout(sqlstu, "choseclass");
                //有判断上课时间
                if (classweek != "" || classtime != "")
                {
                    List<DataRow> ro = new List<DataRow>();
                    foreach (DataRow row in data.Tables[0].Rows)
                    {
                        //MessageBox.Show(row[9].ToString());
                        string[] clj = row[9].ToString().Split('*');
                        if (classweek == "") classweek = "*";
                        if (classtime == "") classtime = "*";
                        if (choseclass(classweek + classtime, clj))
                        {
                            //发现符合
                        }
                        else
                        {
                            //data.Tables[0].Rows.Remove(row);
                            ro.Add(row);
                        }
                    }
                    for (int j = 0; j < ro.Count; j++)
                    {
                        data.Tables[0].Rows.Remove(ro[j]);
                    }
                }
                
                int len = data.Tables[0].Rows.Count;
                if (data != null && len != 0)
                {
                    //设置不自动增加行
                    dataGridView1.AllowUserToAddRows = false;
                    //取消左边 选择列
                    dataGridView1.RowHeadersVisible = false;
                    DataTable dt = data.Tables[0];
                    DataGridViewTextBoxColumn col1 = new DataGridViewTextBoxColumn();
                    // 设置标题中显示的文本
                    col1.Name = "checkclass";
                    col1.HeaderText = "课程名";

                    DataGridViewTextBoxColumn col2 = new DataGridViewTextBoxColumn();
                    col2.Name = "classname";
                    col2.HeaderText = "课程号";

                    DataGridViewButtonColumn col3 = new DataGridViewButtonColumn();
                    col3.Name = "check";
                    col3.HeaderText = "选课";
                    col3.DefaultCellStyle.NullValue = "选课";

                    DataGridViewTextBoxColumn col4 = new DataGridViewTextBoxColumn();
                    col4.Name = "teacher";
                    col4.HeaderText = "教师";

                    DataGridViewTextBoxColumn col5 = new DataGridViewTextBoxColumn();
                    col5.Name = "stu_live";
                    col5.HeaderText = "学分";

                    DataGridViewTextBoxColumn col6 = new DataGridViewTextBoxColumn();
                    col6.Name = "classlave";
                    col6.HeaderText = "课程类型";

                    DataGridViewTextBoxColumn col7 = new DataGridViewTextBoxColumn();
                    col7.Name = "classtime";
                    col7.HeaderText = "上课时间";

                    DataGridViewTextBoxColumn col8 = new DataGridViewTextBoxColumn();
                    col8.Name = "classanpai";
                    col8.HeaderText = "课程安排";

                    //添加数据 列
                    dataGridView1.Columns.Add(col3);
                    dataGridView1.Columns.Add(col1);
                    dataGridView1.Columns.Add(col2);
                    dataGridView1.Columns.Add(col4);
                    dataGridView1.Columns.Add(col5);
                    dataGridView1.Columns.Add(col6);
                    dataGridView1.Columns.Add(col7);
                    dataGridView1.Columns.Add(col8);

                    //课程安排不显示
                    dataGridView1.Columns[7].Visible = false;
                    //行宽
                    dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                    //DataGridViewRow row = new DataGridViewRow();
                    //row.CreateCells(dataGridView1);
                    //设置单元格的值
                    for (int i = 0; i <len; i++)
                    {
                        //行  列
                        //string sql = "SELECT teacher.`name` FROM teacher WHERE id= '"+ dt.Rows[i][3]+"'";
                        //DataSet name= mc.Selectout(sql, "teacher");
                        DataRow[] tea = teatable.Tables[0].Select("id='"+ dt.Rows[i][3]+"'");
                        //MessageBox.Show(tea[0].ItemArray[1].ToString());
                        dataGridView1.Rows.Add("选课", dt.Rows[i][1], dt.Rows[i][0], tea[0].ItemArray[1],
                            dt.Rows[i][2], dt.Rows[i][4], dt.Rows[i][5] + "-" + dt.Rows[i][6] + " 周",dt.Rows[i][9]);
                    }
                }
                else
                {
                    MessageBox.Show("查询失败");
                }
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex==0)
            {
                string lave= dataGridView1.Rows[0].Cells[e.ColumnIndex].Value.ToString();
                if (lave == "选课")
                {
                    //占击按钮操作
                    int ro = dataGridView1.CurrentRow.Cells[0].RowIndex;
                    //当前课程周数
                    string clasweak = dataGridView1.Rows[ro].Cells[2].Value.ToString();
                    //MessageBox.Show("*"+ dataGridView1.Rows[ro].Cells[2].Value.ToString());
                    //当前课程时间
                    string classtim = dataGridView1.Rows[ro].Cells[7].Value.ToString();
                    string[] clat = classtim.Split('*');
                    string clop = dataGridView1.Rows[ro].Cells[6].Value.ToString().Substring(0, 1);
                    int op = int.Parse(clop);
                    string cled = dataGridView1.Rows[ro].Cells[6].Value.ToString().Substring(2, 2);
                    int ed = int.Parse(cled);


                    bool te = checkclass(clat, op, ed);
                    if (te)
                    {
                        //不冲突
                        string classid = dataGridView1.Rows[ro].Cells[2].Value.ToString();
                        string tim_year = DateTime.Now.Year.ToString();
                        string tim_month = DateTime.Now.Month > 5 ? "2" : "1";
                        string sqlin = "INSERT INTO chose_class VALUES('" + FormControl.person.id + "'," + classid + ",NULL,'" + tim_year + "-" + tim_month + "',NULL)";
                        int key = mc.Myinsert(sqlin);
                        if (key >= 1)
                        {
                            MessageBox.Show("选课成功");
                        }
                        else
                        {

                        }
                    }
                    else
                    {
                        MessageBox.Show("课程时间冲突");
                    }
                }
                else
                {
                    //删除课程
                    string tim_year = DateTime.Now.Year.ToString();
                    string tim_month = DateTime.Now.Month > 5 ? "2" : "1";
                    string classid = dataGridView1.Rows[0].Cells[2].Value.ToString();
                    string sqldelete = "DELETE FROM chose_class WHERE stu_id='"+FormControl.person.id+
                        "' AND class_id='"+classid+
                        "' AND class_time='"+tim_year+"-"+tim_month+"'";
                    int key = mc.Myinsert(sqldelete);
                    if (key >= 1)
                    {
                        dataGridView1.Rows.RemoveAt(e.RowIndex);
                        MessageBox.Show("取消成功");
                    }
                }
              
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            dataGridView1.Columns.Clear();
            //获取学生选课表
            string tim_year = DateTime.Now.Year.ToString();
            string tim_month = DateTime.Now.Month > 5 ? "1" : "1";
            string sql = "SELECT * FROM chose_class WHERE stu_id='" + FormControl.person.id + "' AND class_time= '" +tim_year+"-"+ tim_month + "' ;";
            DataSet stu_cla = mc.Selectout(sql, "chose_class");
            //保存已选课程
            //List<string> class_old = new List<string>();
            string sqlgettime = "SELECT * FROM choseclass WHERE class_id  IN("; //10000','12225','45678');";
            for (int i = 0; i < stu_cla.Tables[0].Rows.Count; i++)
            {
                //class_old.Add(stu_cla.Tables[0].Rows[i][1].ToString());
                sqlgettime = sqlgettime + "'" + stu_cla.Tables[0].Rows[i][1].ToString() + "'";
                if (i + 1 < stu_cla.Tables[0].Rows.Count)
                {
                    sqlgettime += ",";
                }
            }
            sqlgettime += ");";
            //已选课程时间获取
            DataSet class_timeold = mc.Selectout(sqlgettime, "choseclass");
            if (class_timeold != null)
            {
                //设置不自动增加行
                dataGridView1.AllowUserToAddRows = false;
                //取消左边 选择列
                dataGridView1.RowHeadersVisible = false;
                DataTable dt = class_timeold.Tables[0];
                DataGridViewTextBoxColumn col1 = new DataGridViewTextBoxColumn();
                // 设置标题中显示的文本
                col1.Name = "checkclass";
                col1.HeaderText = "课程名";

                DataGridViewTextBoxColumn col2 = new DataGridViewTextBoxColumn();
                col2.Name = "classname";
                col2.HeaderText = "课程号";

                DataGridViewButtonColumn col3 = new DataGridViewButtonColumn();
                col3.Name = "check";
                col3.HeaderText = "已选课程";
                col3.DefaultCellStyle.NullValue = "取消选择";

                DataGridViewTextBoxColumn col4 = new DataGridViewTextBoxColumn();
                col4.Name = "teacher";
                col4.HeaderText = "教师";

                DataGridViewTextBoxColumn col5 = new DataGridViewTextBoxColumn();
                col5.Name = "stu_live";
                col5.HeaderText = "学分";

                DataGridViewTextBoxColumn col6 = new DataGridViewTextBoxColumn();
                col6.Name = "classlave";
                col6.HeaderText = "课程类型";

                DataGridViewTextBoxColumn col7 = new DataGridViewTextBoxColumn();
                col7.Name = "classtime";
                col7.HeaderText = "上课时间";

                DataGridViewTextBoxColumn col8 = new DataGridViewTextBoxColumn();
                col8.Name = "classanpai";
                col8.HeaderText = "课程安排";

                //添加数据 列
                dataGridView1.Columns.Add(col3);
                dataGridView1.Columns.Add(col1);
                dataGridView1.Columns.Add(col2);
                dataGridView1.Columns.Add(col4);
                dataGridView1.Columns.Add(col5);
                dataGridView1.Columns.Add(col6);
                dataGridView1.Columns.Add(col7);
                dataGridView1.Columns.Add(col8);

                //课程安排不显示
                dataGridView1.Columns[7].Visible = false;

                //DataGridViewRow row = new DataGridViewRow();
                //row.CreateCells(dataGridView1);
                int len = class_timeold.Tables[0].Rows.Count;
                //设置单元格的值
                for (int i = 0; i < len; i++)
                {
                    //行  列
                    //string sql = "SELECT teacher.`name` FROM teacher WHERE id= '"+ dt.Rows[i][3]+"'";
                    //DataSet name= mc.Selectout(sql, "teacher");
                    DataRow[] tea = teatable.Tables[0].Select("id='" + dt.Rows[i][3] + "'");
                    //MessageBox.Show(tea[0].ItemArray[1].ToString());
                    dataGridView1.Rows.Add("取消选择", dt.Rows[i][1], dt.Rows[i][0], tea[0].ItemArray[1],
                        dt.Rows[i][2], dt.Rows[i][4], dt.Rows[i][5] + "-" + dt.Rows[i][6] + " 周", dt.Rows[i][9]);
                }
            }
            else
            {
                MessageBox.Show("请添加课程");
            }
        }
    }
}
