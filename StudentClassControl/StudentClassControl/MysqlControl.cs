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
                return -1;
            }
            //MessageBox.Show(st + "**" + power);
            conn.Close();
            if (st == passward)
            {
                return power;
            }
            else
            {
                return 0;
            }
        }

        public static void changepassward()
        {
            string conStr = "server=localhost;port=3306; database=yxs;username=root;password=123456;";
            MySqlConnection conn = new MySqlConnection(conStr);
            try
            {
                conn.Open();
                //成功：
            }
            catch (MySqlException e)
            {
                MessageBox.Show(e.ToString());
            }
            string updateu = "update table1 set field1=value1 where id=123";
                
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
