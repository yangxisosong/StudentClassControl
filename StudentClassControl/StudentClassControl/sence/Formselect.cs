using System;
using System.Data;
using System.Windows.Forms;
using StudentClassControl.ServiceReference1;
using System.Reflection;
using System.Diagnostics;
using Excel = Microsoft.Office.Interop.Excel;

namespace StudentClassControl
{
    public partial class Formselect : Form
    {
        public Formselect()
        {
            InitializeComponent();
            //Service1Client client = new Service1Client();
            //label1.Text= client.Test(8).ToString();
            //dataGridView1.DataSource = client.GetSalesVolume();
 
        }

        private void Formselect_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = MysqlControl.Selectvalue("123","2","1").Tables[0];

        }

        private void button2_Click(object sender, EventArgs e)
        {
            DataTable dataTable = MysqlControl.Selectvalue("155", "222","1").Tables[0];
            int rowNumber = dataTable.Rows.Count; 
            int columnNumber = dataTable.Columns.Count;
            if (rowNumber == 0)
            {
                MessageBox.Show("没有任何数据可以导入到Excel文件！");
            }
            //建立Excel对象
            Excel.Application excel = new Excel.Application();
            excel.Application.Workbooks.Add(true);
            excel.Visible = true;//是否打开该Excel文件

            //填充数据 
            for (int c = 0; c < rowNumber; c++)
            {
                for (int j = 0; j < columnNumber; j++)
                {
                    excel.Cells[c + 1, j + 1] = dataTable.Rows[c].ItemArray[j];
                }
            }

            excel.GetSaveAsFilename();
        }
    }
}
