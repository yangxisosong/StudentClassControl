using System;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Windows.Forms;



namespace StudentClassControl
{
    class Class1
    {
        public DataSet GetData()

        {

            //打开文件

            OpenFileDialog file = new OpenFileDialog
            {
                Filter = "Excel(*.xls)|*.xls|Excel(*.xlsx)|*.xlsx",
                //获取或设置文件对话框显示的初始目录。
                InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop),
                //设置是否可以多选
                Multiselect = false
            };
            //显示对话框==对话框取消
            if (file.ShowDialog() == DialogResult.Cancel)

                return null;

            //判断文件后缀

            var path = file.FileName;

            string fileSuffix = System.IO.Path.GetExtension(path);

            if (string.IsNullOrEmpty(fileSuffix))

                return null;
            //定义一个范围，在范围结束时处理对象。
            using (DataSet ds = new DataSet())

            {
                
                //判断Excel文件是2003版本还是2007版本

                string connString = "";

                if (fileSuffix == ".xls"|| fileSuffix == ".xlsx")

                    connString = "Provider=Microsoft.Jet.OLEDB.4.0;" + "Data Source=" + path + ";" + ";Extended Properties=\"Excel 8.0;HDR=NO;IMEX=1\"";

                else

                    connString = "Provider=Microsoft.ACE.OLEDB.12.0;" + "Data Source=" + path + ";" + ";Extended Properties=\"Excel 12.0;HDR=NO;IMEX=1\"";

                //读取文件

                string sql_select = " SELECT * FROM [Sheet1$]";

                using (OleDbConnection conn = new OleDbConnection(connString))

                using (OleDbDataAdapter cmd = new OleDbDataAdapter(sql_select, conn))
                {
                    conn.Open();
                    cmd.Fill(ds);
                }

                if (ds == null || ds.Tables.Count <= 0)
                    return null;

                return ds;

            }

        }

        public String  Getnumber(DataSet Ds ,int i,int j)
        {
            return Ds.Tables[0].Rows[i][j].ToString();
        }
       
    }
}
