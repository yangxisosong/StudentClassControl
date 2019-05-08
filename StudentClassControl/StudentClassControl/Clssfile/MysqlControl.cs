using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace StudentClassControl
{
    class MysqlControl
    {
        MySqlConnection conna = new MySqlConnection("server=localhost;port=3306; database=yxs;username=root;password=123456;");
        //测试使用
        public static void Loadmysql()
        {
            //服务器、端口号、数据库、用户名、密码
            string conStr = "server=139.199.86.90;port=3306; database=mysql;username=root;password=123456;";
            //建立连接
            MySqlConnection conn = new MySqlConnection(conStr);
            //打开数据库
            try
            {
                conn.Open();
                //成功：
                //MessageBox.Show("a");
            }
            catch (MySqlException E)
            {
                MessageBox.Show(E.Message);
                return;
            }
            //conn.Close();
        }
        //连接本地
        public static void Loadmysqllocal()
        {
            //服务器、端口号、数据库、用户名、密码
            string conStr = "server=localhost;port=3306; database=mysql;username=root;password=123456;";
            //建立连接
            MySqlConnection conn = new MySqlConnection(conStr);
            //打开数据库
            try
            {
                conn.Open();
                //成功：
                //MessageBox.Show("a");

            }
            catch (MySqlException E)
            {
                MessageBox.Show(E.Message);
                return;
            }
            conn.Close();
        }
        //登录验证（弃用）
        public static DataSet Selectvalue(string id,string passward,string num)
        {
            DataSet ds = new DataSet();
            string conStr = "server=localhost;port=3306; database=yxs;username=root;password=123456;";
            //建立连接
            MySqlConnection conn = new MySqlConnection(conStr);
            //打开数据库
            try
            {
                conn.Open();
                //成功：
            }
            catch (MySqlException e)
            {
                MessageBox.Show(e.ToString());
            }

            //string test = "insert into userin(id,password) values('gg',789)";
            string test = Insertstr("userin", "id", "password","idpower", id, passward,num);
            MySqlCommand sqlCmd1 = new MySqlCommand(test, conn);
            sqlCmd1.ExecuteNonQuery();
            string cmdStr = "Select password from userin where id="+id;

            MySqlCommand sqlCmd = new MySqlCommand(cmdStr, conn);
            MySqlDataAdapter sda = new MySqlDataAdapter(sqlCmd);
            sda.Fill(ds, "userin");
            //string st = ds.Tables[0].Rows[0][0].ToString();
            conn.Close();
           
            //MessageBox.Show(data.Rows[0][0].ToString());
            return ds;
        }
        //登录密码判断
        public static int Loadding(string id, string passward)
        {
            DataSet ds = new DataSet();
            string conStr = "server=localhost;port=3306; database=yxs;username=root;password=123456;";
            //建立连接
            MySqlConnection conn = new MySqlConnection(conStr);
            //打开数据库
            try
            {
                conn.Open();
                //成功：
            }
            catch (MySqlException e)
            {
                MessageBox.Show(e.ToString());
            }
            string cmdStr = "Select password,idpower from userin where id='" + id+"'";
            MySqlCommand sqlCmd = new MySqlCommand(cmdStr, conn);
            MySqlDataAdapter sda = new MySqlDataAdapter(sqlCmd);
            sda.Fill(ds, "userin");
            string st=null;
            int power = 0 ;
            try
            {
                 st= ds.Tables[0].Rows[0][0].ToString();
                 power= int.Parse(ds.Tables[0].Rows[0][1].ToString());
            }
            catch
            {
                //出现异常 密码不对
                return -1;
            }
            //MessageBox.Show(st + "**" + power);
            conn.Close();
            //判断用户级别 1学生 2老师 3管理员
            if (st == passward)
            {
                return power;
            }
            else
            {
                return 0;
            }
        }
        //修改密码
        public static int Changepassward(string pass,string id)
        {
            string conStr = "server=localhost;port=3306; database=yxs;username=root;password=123456;";
            MySqlConnection conn = new MySqlConnection(conStr);
            try
            {
                conn.Open();
                //成功
            }
            catch (MySqlException e)
            {
                MessageBox.Show(e.ToString());
            }
            string updateu = "update userin set password="+pass+" where id='" + id + "'";
            MySqlCommand sqlCommand = new MySqlCommand(updateu,conn);
            int iet=sqlCommand.ExecuteNonQuery();
            conn.Close();
            if (iet > 0)
            {
                //修改成功
                return 1;
            }
            else
            {
                //修改失败
                return -1;
            }
        }
        //查询登录数据
        public  DataSet Selectin(string id,string table)
        {
            DataSet ds = new DataSet();
            try
            {
                conna.Open();
            }
            catch(MySqlException e)
            {

            }
            string cmdid = "Select * from "+table+" where id='" + id + "'";
            MySqlCommand sqlCmd = new MySqlCommand(cmdid, conna);
            MySqlDataAdapter sda = new MySqlDataAdapter(sqlCmd);
            sda.Fill(ds, table);
            conna.Close();
            return ds;
        }
        //查询学院专业
        public DataSet Selectschool(string table)
        {
            DataSet ds = new DataSet();
            try
            {
                conna.Open();
            }
            catch (MySqlException e)
            {

            }
            string cmdid = "Select * from " + table;
            MySqlCommand sqlCmd = new MySqlCommand(cmdid, conna);
            MySqlDataAdapter sda = new MySqlDataAdapter(sqlCmd);
            sda.Fill(ds, table);
            conna.Close();
            return ds;
        }
        //插入信息
        public int Insert(string table,string id,string name,string sex,string stuclass,string discipline,string college,string intime)
        {

            DataSet ds = new DataSet();
            try
            {
                if (conna.State != ConnectionState.Open)
                {
                    conna.Open();
                }
                string cmdid = "INSERT INTO " + table + " VALUES ('" + id + "','" + name + "','" + sex + "'," + stuclass + ",'" + discipline + "','" + college + "'," + intime + ");";
                MySqlCommand sqlCmd = new MySqlCommand(cmdid, conna);
                MySqlDataAdapter sda = new MySqlDataAdapter(sqlCmd);
                int iet = sqlCmd.ExecuteNonQuery();
                conna.Close();
                if (iet == 1)
                {

                    return 1;
                }
            }
            catch (MySqlException e)
            {
                return 0; 
            }
            return 0;

        }
        //自定义插入
        public int Myinsert(string ins)
        {
            DataSet ds = new DataSet();
            try
            {
                if (conna.State != ConnectionState.Open)
                {
                    conna.Open();
                }
            }
            catch (MySqlException e)
            {
                return 0;
            }
            string cmdid = ins;
            try
            {
                MySqlCommand sqlCmd = new MySqlCommand(cmdid, conna);
                MySqlDataAdapter sda = new MySqlDataAdapter(sqlCmd);
                int iet = sqlCmd.ExecuteNonQuery();
                conna.Close();
                if (iet >= 1)
                {
                    return iet;
                }
                else
                {
                    return 0;
                }
            }
            catch
            {
                conna.Close();
                return 0;
            }   
        }
        //自定义查询
        public DataSet Selectout(string sqlout,string table)
        {
            DataSet ds = new DataSet();
            try
            {
                if (conna.State != ConnectionState.Open)
                {
                    conna.Open();
                }
            }
            catch (MySqlException e)
            {
                return null;
            }
            string cmdid = sqlout;
            try
            {
                MySqlCommand sqlCmd = new MySqlCommand(cmdid, conna);
                MySqlDataAdapter sda = new MySqlDataAdapter(sqlCmd);
                //int iet = sqlCmd.ExecuteNonQuery();
                sda.Fill(ds, table);
                conna.Close();
                return ds;
            }
            catch
            {
                conna.Close();
                return null;
            }
        }
        public static string Insertstr(string table,string key1,string key2,string value1,string value2 )
        {
            string str = "insert into "+table+"("+key1+","+key2+") values('"+value1+"','"+value2+"')";
            return str;
        }
        public static string Insertstr(string table, string key1, string key2, string key3, string value1, string value2, string value3)
        {
            string str = "insert into " + table + "(" + key1 + "," + key2 +","+key3+ ") values('" + value1 + "','" + value2 + "','"+value3+"')";
            return str;
        }

    }
}
