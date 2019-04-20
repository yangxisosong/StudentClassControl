using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StudentClassControl
{
    class Class2
    {
        public DataSet GetData()
        {
            //打开文件
            OpenFileDialog file = new OpenFileDialog();
        file.Filter ="Excel(*。xlsx)| * .xlsx | Excel(*。xls)| * .xls";
            file.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            file.Multiselect = false;
            if(file.ShowDialog()== DialogResult.Cancel)
                return null;
            //判断文件后缀
            var path = file.FileName;
        string fileSuffix = System.IO.Path.GetExtension(path);
            if(string.IsNullOrEmpty(fileSuffix))
                return null;
            using (DataSet ds = new DataSet())
            {
                //判断的Excel文件是2003版本还是2007年版本
                string connString ="";
                if(fileSuffix ==".xls")
                    connString ="Provider = Microsoft.Jet.OLEDB.4.0;" + "Data Source ="+path +";" +"; Extended Properties = \"Excel 8.0; HDR = YES; IMEX = 1 \"";
               else
                    connString ="Provider = Microsoft.ACE.OLEDB.12.0;" + "Data Source ="+path +";" +"; Extended Properties = \"Excel 12.0; HDR = YES; IMEX = 1 \"";
                //读取文件
                string sql_select ="SELECT* FROM[Sheet1 $]";
                using(OleDbConnection conn = new OleDbConnection(connString))
                using(OleDbDataAdapter cmd = new OleDbDataAdapter(sql_select,conn))
                {
                    conn.Open();
                    cmd.Fill(ds);
                }
                if(ds == null || ds.Tables.Count <= 0)return null;
                return ds;
            }
        }

    }
}
