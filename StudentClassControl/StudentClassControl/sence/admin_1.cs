using StudentClassControl.ServiceReference1;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;

namespace StudentClassControl
{
    public partial class admin_1 : Form
    {
        MysqlControl bdmc = new MysqlControl();
        Service1Client mc = new Service1Client();
        Excelcon ex = new Excelcon();

        //定义字典用于下拉列表选择
        Dictionary<string, string> Address = new Dictionary<string, string>();
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
                    comboBox13.Items.Add(province);
                }             
            }
            for (int i = 2010; i < DateTime.Now.Year; i++)
            {
                comboBox3.Items.Add(i);
            }
        }
        //当选择完学院后 添加专业的下拉列表
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

        //添加一个学生信息
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
                    string sqlin = "INSERT INTO userin VALUES('"+id+"', '123456', 1); ";
                    int kk=mc.Myinsert(sqlin);
                    //if(kk>=1)
                    //{
                    //    MessageBox.Show("ok");
                    //}
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
        //excel添加学生
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
                    string sql = "INSERT INTO userin VALUES('" + dataGridView1[0, i].Value.ToString() + "', '123456', 1); ";
                    int kk = mc.Myinsert(sql);
                }
                //string over = sqlop + sqled;
                //MessageBox.Show(over);
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
        //导入excel学生表
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
        //添加一个教师信息
        private void button5_Click(object sender, EventArgs e)
        {
            string name = textBox2.Text;
            string classid = textBox4.Text;
            string sex = radioButton3.Checked ? "男" : "女";
            string college = comboBox4.Text;

            if (name != "" && classid != "" && sex != "" && college != "")
            {
                string sqlin = "INSERT INTO teacher VALUES " +
              "('" + classid + "','" + name + "','" + sex + "','" + college + "')";
                int key = mc.Myinsert(sqlin);
                if (key >= 1)
                {
                    MessageBox.Show("添加成功！");
                    string sql = "INSERT INTO userin VALUES('" + classid + "', '123456', 2); ";
                    int kk = mc.Myinsert(sql);
                }
                else
                {
                    MessageBox.Show("添加失败！");
                }
            }
            else
            {
                MessageBox.Show("请输入完整信息");
            }
        }
        //课程时间选择
        private void button13_Click(object sender, EventArgs e)
        {
            Formclass fcl = new Formclass();
            fcl.ShowDialog();
        }
        //添加课程
        private void button12_Click(object sender, EventArgs e)
        {
            string classnum = textBox6.Text;
            string classname = textBox5.Text;
            string class_live = comboBox10.Text;
            string teachernum = textBox7.Text;
            string classroom = comboBox6.Text;
            string classroomid = comboBox7.Text + comboBox8.Text;
            string classop = comboBox5.Text;
            string classed = comboBox9.Text;
            string classlave = comboBox11.Text;
            string clweaktime = FormControl.weaktime;
            if (classnum != "" && classname != "" && teachernum != "" && classroom != "" && classroomid != "" && classop != "" && classed != "" && clweaktime != "" && class_live != ""&&classlave!="")
            {
                string sqlin = "INSERT INTO choseclass VALUES " +
              "('" + classnum + "', '" + classname + "',"+class_live+", '" + teachernum + "', '" +classlave+"',"+ classop + ", " + classed + ", '" + classroom + "', " + classroomid + ", '" + clweaktime + "'); ";
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
            else
            {
                MessageBox.Show("请输入完整信息");
            }
        }
        //导出教师excel
        private void button6_Click(object sender, EventArgs e)
        {
            ex.ExportExcel_tea("教师信息表");
        }
        //导出课程表
        private void button9_Click(object sender, EventArgs e)
        {
            ex.ExportExcel_cla("课程信息表");
        }
        //导入教师表
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
        //导入课程表
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
        //excel添加教师
        private void button8_Click(object sender, EventArgs e)
        {
            if (dataGridView2.DataSource == null)
            {
                MessageBox.Show("请先导入信息");
            }
            else
            {
                //string data = dataGridView1[0, 1].Value.ToString();
                //MessageBox.Show(data + dataGridView1[1, 1].Value.ToString() + dataGridView1.Rows.Count);
                string sqlop = "INSERT INTO teacher VALUES";
                string sqled = "";
                int len = dataGridView2.Rows.Count - 1;
                for (int i = 1; i < len; i++)
                {
                    sqled = sqled +
                         "('" + dataGridView2[0, i].Value.ToString() +
                         "','" + dataGridView2[1, i].Value.ToString() +
                         "','" + dataGridView2[2, i].Value.ToString() + 
                         "','" + dataGridView2[3, i].Value.ToString() + "')";
                    if (i + 1 < len)
                    {
                        sqled = sqled + ",";
                    }
                    else
                    {
                        sqled = sqled + ";";
                    }
                    string sqlin = "INSERT INTO userin VALUES('" + dataGridView2[0, i].Value.ToString() + "', '123456', 2); ";
                    int kk = mc.Myinsert(sqlin);
                }
               
                int key = mc.Myinsert(sqlop + sqled);
                //string te = sqlop + sqled;
                if (key >= 1)
                {
                    MessageBox.Show("成功录入" + key + "条信息");
                }
                else
                {
                    MessageBox.Show("录入失败");
                }
            }
        }
        //excel添加课程
        private void button11_Click(object sender, EventArgs e)
        {
            if (dataGridView3.DataSource == null)
            {
                MessageBox.Show("请先导入信息");
            }
            else
            {
                string sqlop = "INSERT INTO choseclass VALUES";
                string sqled = "";
                int len = dataGridView3.Rows.Count - 1;
                for (int i = 1; i < len; i++)
                {
                    sqled = sqled +
                       "(" + dataGridView3[0, i].Value.ToString() + 
                       ", '" + dataGridView3[1, i].Value.ToString() + 
                       "',"+ dataGridView3[2, i].Value.ToString() +
                       ", '" + dataGridView3[3, i].Value.ToString() +
                       "','"+ dataGridView3[4, i].Value.ToString()+
                       "', " + dataGridView3[5, i].Value.ToString() +
                       ", " + dataGridView3[6, i].Value.ToString() +
                       ", '" + dataGridView3[7, i].Value.ToString() +
                       "', " + dataGridView3[8, i].Value.ToString() + 
                       ", '" + dataGridView3[9, i].Value.ToString() + "')";
                    if (i + 1 < len)
                    {
                        sqled = sqled + ",";
                    }
                    else
                    {
                        sqled = sqled + ";";
                    }
                }

                int key = mc.Myinsert(sqlop + sqled);
                //string te = sqlop + sqled;
                if (key >= 1)
                {
                    MessageBox.Show("成功录入" + key + "条信息");
                }
                else
                {
                    MessageBox.Show("录入失败");
                }
            }
        }
        //查询学生表
        private void button14_Click(object sender, EventArgs e)
        {
            string stuid = textBox8.Text;
            string stuclass = textBox11.Text;
            string stuhome = textBox12.Text;
            string stuname = textBox13.Text;
            string stucollege = textBox14.Text;
            List<string> mList = new List<string>();
            if (stuid == ""&& stuclass == ""&&stuhome==""&&stuname==""&& stucollege=="")
            {
                MessageBox.Show("请添加查询内容");
            }
            else
            {
                string sqlstu = "SELECT * FROM student WHERE ";
                if (stuid != "") mList.Add("id='"+stuid+"'");
                if (stuclass != "") mList.Add("class=" + stuclass);
                if (stuhome != "") mList.Add("discipline='" + stuhome+"'");
                if (stuname != "") mList.Add("name='" + stuname+"'");
                if (stucollege != "") mList.Add("college= '" + stucollege + "'");
                //MessageBox.Show(mList.Count+"");
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
                //MessageBox.Show(sqlstu);
                //sqlstu = sqlstu + stuclass == "" ? "" : "id='" + stuid + "'";
                DataSet data = mc.Selectout(sqlstu, "student");
                if (data != null&& data.Tables[0].Rows.Count != 0)
                {
                    //dataGridView4.DataSource = data.Tables[0];
                    dataGridView4.DataSource = data.Tables[0];
                    dataGridView4.Columns[0].HeaderText = "学号";
                    dataGridView4.Columns[1].HeaderText = "姓名";
                    dataGridView4.Columns[2].HeaderText = "性别";
                    dataGridView4.Columns[3].HeaderText = "班级";
                    dataGridView4.Columns[4].HeaderText = "专业";
                    dataGridView4.Columns[5].HeaderText = "学院";
                    dataGridView4.Columns[6].HeaderText = "入学时间";
                    mList.Clear();
                }
                else
                {
                    MessageBox.Show("查询失败");
                    mList.Clear();
                }
            }
        }
        //编辑学生
        private void button15_Click(object sender, EventArgs e)
        {
            dataGridView4.ReadOnly = false;
            dataGridView4.Columns[0].ReadOnly = true;
        }
        //更新学生数据
        private void button20_Click(object sender, EventArgs e)
        {
            if (dataGridView4.DataSource == null)
            {
                MessageBox.Show("请先导入信息");
            }
            else
            {
                //格式 [列，行] Rows代表行的集合，Columns代表列的集合。
                string sqlop = "replace INTO student VALUES";
                string sqled = "";
                int len = dataGridView4.Rows.Count - 1;
                for (int i = 0; i < len; i++)
                {
                    sqled = sqled +
                        "('" + dataGridView4[0, i].Value.ToString() +
                        "', '" + dataGridView4[1, i].Value.ToString() +
                        "', '" + dataGridView4[2, i].Value.ToString() +
                        "', " + dataGridView4[3, i].Value.ToString() +
                        ", '" + dataGridView4[4, i].Value.ToString() +
                        "', '" + dataGridView4[5, i].Value.ToString() +
                        "', " + dataGridView4[6, i].Value.ToString() + ")";
                    if (i + 1 < len)
                    {
                        sqled = sqled + ",";
                    }
                    else
                    {
                        sqled = sqled + ";";
                    }
                    //string sql = "INSERT INTO userin VALUES('" + dataGridView4[0, i].Value.ToString() + "', '123456', 1); ";
                    //int kk = mc.Myinsert(sql);
                }
                string ts = sqlop + sqled;
                int key = mc.Myinsert(sqlop + sqled);
                if (key >= 1)
                {
                    MessageBox.Show("成功修改信息");
                }
                else
                {
                    MessageBox.Show("录入失败");
                }
            }
        }
        //编辑老师
        private void button17_Click(object sender, EventArgs e)
        {
            dataGridView5.ReadOnly = false;
            dataGridView5.Columns[0].ReadOnly = true;
        }
        //课程表编辑
        private void button19_Click(object sender, EventArgs e)
        {
            dataGridView6.ReadOnly = false;
            dataGridView6.Columns[0].ReadOnly = true;
        }
        //课程表更新
        private void button21_Click(object sender, EventArgs e)
        {
            if (dataGridView6.DataSource == null)
            {
                MessageBox.Show("请先导入信息");
            }
            else
            {
                string sqlop = "replace INTO choseclass VALUES";
                string sqled = "";
                int len = dataGridView6.Rows.Count - 1;
                for (int i = 0; i < len; i++)
                {
                    sqled = sqled +
                       "(" + dataGridView6[0, i].Value.ToString() +
                       ", '" + dataGridView6[1, i].Value.ToString() +
                       "',"+ dataGridView6[2, i].Value.ToString() +
                       ", '" + dataGridView6[3, i].Value.ToString() +
                       "', '" + dataGridView6[4, i].Value.ToString() +
                       "', " + dataGridView6[5, i].Value.ToString() +
                       ", '" + dataGridView6[6, i].Value.ToString() +
                       "', '" + dataGridView6[7, i].Value.ToString() +
                       "', '" + dataGridView6[8, i].Value.ToString() +
                       "','"+dataGridView6[9,i].Value.ToString()+"')";
                    if (i + 1 < len)
                    {
                        sqled = sqled + ",";
                    }
                    else
                    {
                        sqled = sqled + ";";
                    }
                }

                int key = mc.Myinsert(sqlop + sqled);
                //string te = sqlop + sqled;
                if (key >= 1)
                {
                    MessageBox.Show("成功修改信息");
                }
                else
                {
                    MessageBox.Show("录入失败");
                }
            }
        }
        //查询课程
        private void button18_Click(object sender, EventArgs e)
        {
            string classid = textBox10.Text;
            string classname = textBox17.Text;
            string classlave = comboBox12.Text;
            string classtea = textBox16.Text;
            List<string> mList = new List<string>();


            if (classid == "" && classname == "" && classlave == "" && classtea == "")
            {
                MessageBox.Show("请添加查询内容");
            }
            else
            {
                string sqlstu = "SELECT * FROM choseclass WHERE ";
                if (classid != "") mList.Add("class_id= '" + classid + "'");
                if (classname != "") mList.Add("class_name= '" + classname + "'");
                if (classlave != "") mList.Add("classlave= '" + classlave + "'");
                if (classtea != "") mList.Add("classlave= '" + classtea + "'");
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
                    dataGridView6.DataSource = data.Tables[0];
                    dataGridView6.Columns[0].HeaderText = "课程号";
                    dataGridView6.Columns[1].HeaderText = "课程名";
                    dataGridView6.Columns[2].HeaderText = "学分";
                    dataGridView6.Columns[3].HeaderText = "教师工号";
                    dataGridView6.Columns[4].HeaderText = "课程类型";
                    dataGridView6.Columns[5].HeaderText = "开始周数";
                    dataGridView6.Columns[6].HeaderText = "结束周数";
                    dataGridView6.Columns[7].HeaderText = "教学楼";
                    dataGridView6.Columns[8].HeaderText = "教室";
                    dataGridView6.Columns[9].HeaderText = "上课时间";
                }
                else
                {
                    MessageBox.Show("查询失败");
                }
            }
          
        }
        //教师查询
        private void button16_Click(object sender, EventArgs e)
        {
            string teaid = textBox9.Text;
            string teaname = textBox15.Text;
            string teacollege = comboBox13.Text;
            List<string> mList = new List<string>();
            if (teaid == ""&&teaname==""&&teacollege=="")
            {
                MessageBox.Show("请添加查询内容");
            }
            else
            {
                string sqlstu = "SELECT * FROM teacher WHERE ";
                if (teaid != "") mList.Add("id= '" + teaid + "'");
                if (teaname != "") mList.Add("name= '" + teaname + "'");
                if (teacollege != "") mList.Add("college= '" + teacollege + "'");

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
                DataSet data = mc.Selectout(sqlstu, "teacher");
                if (data !=null&& data.Tables[0].Rows.Count != 0)
                {
                    //dataGridView4.DataSource = data.Tables[0];
                    dataGridView5.DataSource = data.Tables[0];
                    dataGridView5.Columns[0].HeaderText = "教师工号";
                    dataGridView5.Columns[1].HeaderText = "姓名";
                    dataGridView5.Columns[2].HeaderText = "性别";
                    dataGridView5.Columns[3].HeaderText = "学院";
                }
                else
                {
                    MessageBox.Show("查询失败");
                }
            }
        }
        //更新教师数据
        private void button22_Click(object sender, EventArgs e)
        {
            if (dataGridView5.DataSource == null)
            {
                MessageBox.Show("请先导入信息");
            }
            else
            {
                //string data = dataGridView1[0, 1].Value.ToString();
                //MessageBox.Show(data + dataGridView1[1, 1].Value.ToString() + dataGridView1.Rows.Count);
                string sqlop = "replace INTO teacher VALUES";
                string sqled = "";
                int len = dataGridView5.Rows.Count - 1;
                for (int i = 0; i < len; i++)
                {
                    sqled = sqled +
                         "('" + dataGridView5[0, i].Value.ToString() +
                         "','" + dataGridView5[1, i].Value.ToString() +
                         "','" + dataGridView5[2, i].Value.ToString() +
                         "','" + dataGridView5[3, i].Value.ToString() + "')";
                    if (i + 1 < len)
                    {
                        sqled = sqled + ",";
                    }
                    else
                    {
                        sqled = sqled + ";";
                    }
                }
                int key = mc.Myinsert(sqlop + sqled);
                string te = sqlop + sqled;
                if (key >= 1)
                {
                    MessageBox.Show("成功修改信息");
                }
                else
                {
                    MessageBox.Show("录入失败");
                }
            }
        }
        //删除学生
        private void button23_Click(object sender, EventArgs e)
        {
            if (dataGridView4.SelectedRows.Count == 0)
            {
                MessageBox.Show("请选择数据");
            }
            else
            {
                string sqlop = "DELETE FROM student where id IN (";
                for (int i = 0; i < dataGridView4.SelectedRows.Count; i++)//遍历所有选中的行
                {
                    string id = dataGridView4.SelectedRows[i].Cells[0].EditedFormattedValue.ToString();
                    sqlop = sqlop + "'" + id + "'";
                    if (i + 1 < dataGridView4.SelectedRows.Count)
                    {
                        sqlop = sqlop + ",";
                    }
                    else
                    {
                        sqlop = sqlop + ");";
                    }
                }
                foreach (DataGridViewRow dr in dataGridView4.SelectedRows)
                {
                    dataGridView4.Rows.Remove(dr);
                }
                int key = mc.Myinsert(sqlop);
                if (key >= 1)
                {
                    MessageBox.Show("成功删除" + key + "条数据");
                }
            }
        }
        //删除教师
        private void button24_Click(object sender, EventArgs e)
        {

            if (dataGridView5.SelectedRows.Count == 0)
            {
                MessageBox.Show("请选择数据");
            }
            else
            {
                string sqlop = "DELETE FROM teacher where id IN (";
                for (int i = 0; i < dataGridView5.SelectedRows.Count; i++)//遍历所有选中的行
                {
                    string id = dataGridView5.SelectedRows[i].Cells[0].EditedFormattedValue.ToString();
                    sqlop = sqlop + "'" + id + "'";
                    if (i + 1 < dataGridView5.SelectedRows.Count)
                    {
                        sqlop = sqlop + ",";
                    }
                    else
                    {
                        sqlop = sqlop + ");";
                    }
                }
                foreach (DataGridViewRow dr in dataGridView5.SelectedRows)
                {
                    dataGridView5.Rows.Remove(dr);
                }
                int key = mc.Myinsert(sqlop);
                if (key >= 1)
                {
                    MessageBox.Show("成功删除" + key + "条数据");
                }
            }
        }
        //删除课程
        private void button25_Click(object sender, EventArgs e)
        {
            if (dataGridView6.SelectedRows.Count == 0)
            {
                MessageBox.Show("请选择数据");
            }
            else
            {
                string sqlop = "DELETE FROM teacher where id IN (";
                for (int i = 0; i < dataGridView6.SelectedRows.Count; i++)//遍历所有选中的行
                {
                    string id = dataGridView6.SelectedRows[i].Cells[0].EditedFormattedValue.ToString();
                    sqlop = sqlop + "'" + id + "'";
                    if (i + 1 < dataGridView6.SelectedRows.Count)
                    {
                        sqlop = sqlop + ",";
                    }
                    else
                    {
                        sqlop = sqlop + ");";
                    }
                }
                foreach (DataGridViewRow dr in dataGridView5.SelectedRows)
                {
                    dataGridView6.Rows.Remove(dr);
                }
                int key = mc.Myinsert(sqlop);
                if (key >= 1)
                {
                    MessageBox.Show("成功删除" + key + "条数据");
                }
            }
        }
        //导出学生表格
        private void button26_Click(object sender, EventArgs e)
        {
            ex.ExportExcel_stuout("学生信息表", dataGridView4);
        }
        //导出教师表格
        private void button27_Click(object sender, EventArgs e)
        {
            ex.ExportExcel_teaout("教师信息表", dataGridView5);
        }
        //导出课程表格
        private void button28_Click(object sender, EventArgs e)
        {
            ex.ExportExcel_claout("课程信息表", dataGridView6);
        }
    }
}
