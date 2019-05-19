using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;

namespace StudentClassControl
{
    class Excelcon
    {
        //学生表
        public void ExportExcel_stu(string fileName)
        {
            string saveFileName = "";
            SaveFileDialog saveDialog = new SaveFileDialog();
            saveDialog.DefaultExt = "xls";
            saveDialog.Filter = "Excel文件|*.xls";
            saveDialog.FileName = fileName;
            saveDialog.ShowDialog();
            saveFileName = saveDialog.FileName;
            if (saveFileName.IndexOf(":") < 0) return; //被点了取消
            Excel.Application xlApp = new Excel.Application();
            if (xlApp == null)
            {
                MessageBox.Show("无法创建Excel对象，可能您可能未安装Excel");
                return;
            }
            Excel.Workbooks workbooks = xlApp.Workbooks;
            Excel.Workbook workbook = workbooks.Add(Excel.XlWBATemplate.xlWBATWorksheet);
            Excel.Worksheet worksheet = (Excel.Worksheet)workbook.Worksheets[1];//取得sheet1
                                                                                //写入标题

            //worksheet.Cells[1, 0] = myDGV.Columns[i].HeaderText;
            worksheet.Cells[1, 1] = "学号             ";
            worksheet.Cells[1, 2] = "姓名    ";
            worksheet.Cells[1, 3] = "性别  ";
            worksheet.Cells[1, 4] = "班级  ";
            worksheet.Cells[1, 5] = "专业            ";
            worksheet.Cells[1, 6] = "学院            ";
            worksheet.Cells[1, 7] = "入学年份    ";

            ////写入数值
            //for (int r = 0; r < myDGV.Rows.Count; r++)
            //{
            //    for (int i = 0; i < myDGV.ColumnCount; i++)
            //    {
            //        worksheet.Cells[r + 2, i + 1] = myDGV.Rows[r].Cells[i].Value;
            //    }
            //    System.Windows.Forms.Application.DoEvents();
            //}
            worksheet.Columns.EntireColumn.AutoFit();//列宽自适应
            if (saveFileName != "")
            {
                try
                {
                    workbook.Saved = true;
                    workbook.SaveCopyAs(saveFileName);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("导出文件时出错,文件可能正被打开！\n" + ex.Message);
                }
            }
            xlApp.Quit();
            GC.Collect();//强行销毁
            MessageBox.Show("文件： " + fileName + ".xls 保存成功", "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        //教师表
        public void ExportExcel_tea(string fileName)
        {
            string saveFileName = "";
            SaveFileDialog saveDialog = new SaveFileDialog();
            saveDialog.DefaultExt = "xls";
            saveDialog.Filter = "Excel文件|*.xls";
            saveDialog.FileName = fileName;
            saveDialog.ShowDialog();
            saveFileName = saveDialog.FileName;
            if (saveFileName.IndexOf(":") < 0) return; //被点了取消
            Excel.Application xlApp = new Excel.Application();
            if (xlApp == null)
            {
                MessageBox.Show("无法创建Excel对象，可能您可能未安装Excel");
                return;
            }
            Excel.Workbooks workbooks = xlApp.Workbooks;
            Excel.Workbook workbook = workbooks.Add(Excel.XlWBATemplate.xlWBATWorksheet);
            Excel.Worksheet worksheet = (Excel.Worksheet)workbook.Worksheets[1];//取得sheet1
                                                                                //写入标题

            //worksheet.Cells[1, 0] = myDGV.Columns[i].HeaderText;
            worksheet.Cells[1, 1] = "工号             ";
            worksheet.Cells[1, 2] = "姓名    ";
            worksheet.Cells[1, 3] = "性别  ";
            worksheet.Cells[1, 4] = "学院        ";


            ////写入数值
            //for (int r = 0; r < myDGV.Rows.Count; r++)
            //{
            //    for (int i = 0; i < myDGV.ColumnCount; i++)
            //    {
            //        worksheet.Cells[r + 2, i + 1] = myDGV.Rows[r].Cells[i].Value;
            //    }
            //    System.Windows.Forms.Application.DoEvents();
            //}
            worksheet.Columns.EntireColumn.AutoFit();//列宽自适应
            if (saveFileName != "")
            {
                try
                {
                    workbook.Saved = true;
                    workbook.SaveCopyAs(saveFileName);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("导出文件时出错,文件可能正被打开！\n" + ex.Message);
                }
            }
            xlApp.Quit();
            GC.Collect();//强行销毁
            MessageBox.Show("文件： " + fileName + ".xls 保存成功", "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        //课程表
        public void ExportExcel_cla(string fileName)
        {
            string saveFileName = "";
            SaveFileDialog saveDialog = new SaveFileDialog();
            saveDialog.DefaultExt = "xls";
            saveDialog.Filter = "Excel文件|*.xls";
            saveDialog.FileName = fileName;
            saveDialog.ShowDialog();
            saveFileName = saveDialog.FileName;
            if (saveFileName.IndexOf(":") < 0) return; //被点了取消
            Excel.Application xlApp = new Excel.Application();
            if (xlApp == null)
            {
                MessageBox.Show("无法创建Excel对象，可能您可能未安装Excel");
                return;
            }
            Excel.Workbooks workbooks = xlApp.Workbooks;
            Excel.Workbook workbook = workbooks.Add(Excel.XlWBATemplate.xlWBATWorksheet);
            Excel.Worksheet worksheet = (Excel.Worksheet)workbook.Worksheets[1];//取得sheet1
                                                                                //写入标题

            //worksheet.Cells[1, 0] = myDGV.Columns[i].HeaderText;
            worksheet.Cells[1, 1] = "课程号         ";
            worksheet.Cells[1, 2] = "课程名    ";
            worksheet.Cells[1, 3] = "学分   ";
            worksheet.Cells[1, 4] = "教师工号  ";
            worksheet.Cells[1, 5] = "课程类型 ";
            worksheet.Cells[1, 6] = "开始周数  ";
            worksheet.Cells[1, 7] = "结束周数  ";
            worksheet.Cells[1, 8] = "教学楼        ";
            worksheet.Cells[1, 9] = "教室  ";
            worksheet.Cells[1, 10] = "课程时间（周数节数）中间以*隔开";
            ////写入数值
            //for (int r = 0; r < myDGV.Rows.Count; r++)
            //{
            //    for (int i = 0; i < myDGV.ColumnCount; i++)
            //    {
            //        worksheet.Cells[r + 2, i + 1] = myDGV.Rows[r].Cells[i].Value;
            //    }
            //    System.Windows.Forms.Application.DoEvents();
            //}
            worksheet.Columns.EntireColumn.AutoFit();//列宽自适应
            if (saveFileName != "")
            {
                try
                {
                    workbook.Saved = true;
                    workbook.SaveCopyAs(saveFileName);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("导出文件时出错,文件可能正被打开！\n" + ex.Message);
                }
            }
            xlApp.Quit();
            GC.Collect();//强行销毁
            MessageBox.Show("文件： " + fileName + ".xls 保存成功", "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        //导出datagridview中的表
        public void ExportExcel_stuout(string fileName , DataGridView myDGV)
        {
            string saveFileName = "";
            SaveFileDialog saveDialog = new SaveFileDialog();
            saveDialog.DefaultExt = "xls";
            saveDialog.Filter = "Excel文件|*.xls";
            saveDialog.FileName = fileName;
            saveDialog.ShowDialog();
            saveFileName = saveDialog.FileName;
            if (saveFileName.IndexOf(":") < 0) return; //被点了取消
            Excel.Application xlApp = new Excel.Application();
            if (xlApp == null)
            {
                MessageBox.Show("无法创建Excel对象，可能您可能未安装Excel");
                return;
            }
            Excel.Workbooks workbooks = xlApp.Workbooks;
            Excel.Workbook workbook = workbooks.Add(Excel.XlWBATemplate.xlWBATWorksheet);
            Excel.Worksheet worksheet = (Excel.Worksheet)workbook.Worksheets[1];//取得sheet1
                                                                                //写入标题

            //worksheet.Cells[1, 0] = myDGV.Columns[i].HeaderText;
            worksheet.Cells[1, 1] = "学号             ";
            worksheet.Cells[1, 2] = "姓名    ";
            worksheet.Cells[1, 3] = "性别  ";
            worksheet.Cells[1, 4] = "班级  ";
            worksheet.Cells[1, 5] = "专业            ";
            worksheet.Cells[1, 6] = "学院            ";
            worksheet.Cells[1, 7] = "入学年份    ";

            //写入数值
            for (int r = 0; r < myDGV.Rows.Count; r++)
            {
                for (int i = 0; i < myDGV.ColumnCount-1; i++)
                {
                    worksheet.Cells[r + 2, i + 1] = "'" + myDGV.Rows[r].Cells[i].Value;
                }
                Application.DoEvents();
            }
            worksheet.Columns.EntireColumn.AutoFit();//列宽自适应
            if (saveFileName != "")
            {
                try
                {
                    workbook.Saved = true;
                    workbook.SaveCopyAs(saveFileName);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("导出文件时出错,文件可能正被打开！\n" + ex.Message);
                }
            }
            xlApp.Quit();
            GC.Collect();//强行销毁
            MessageBox.Show("文件 " + fileName + ".xls 保存成功", "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public void ExportExcel_teaout(string fileName, DataGridView myDGV)
        {
            string saveFileName = "";
            SaveFileDialog saveDialog = new SaveFileDialog();
            saveDialog.DefaultExt = "xls";
            saveDialog.Filter = "Excel文件|*.xls";
            saveDialog.FileName = fileName;
            saveDialog.ShowDialog();
            saveFileName = saveDialog.FileName;
            if (saveFileName.IndexOf(":") < 0) return; //被点了取消
            Excel.Application xlApp = new Excel.Application();
            if (xlApp == null)
            {
                MessageBox.Show("无法创建Excel对象，可能您可能未安装Excel");
                return;
            }
            Excel.Workbooks workbooks = xlApp.Workbooks;
            Excel.Workbook workbook = workbooks.Add(Excel.XlWBATemplate.xlWBATWorksheet);
            Excel.Worksheet worksheet = (Excel.Worksheet)workbook.Worksheets[1];//取得sheet1
                                                                                //写入标题

            //worksheet.Cells[1, 0] = myDGV.Columns[i].HeaderText;
            worksheet.Cells[1, 1] = "工号             ";
            worksheet.Cells[1, 2] = "姓名    ";
            worksheet.Cells[1, 3] = "性别  ";
            worksheet.Cells[1, 4] = "学院        ";


            //写入数值
            for (int r = 0; r < myDGV.Rows.Count; r++)
            {
                for (int i = 0; i < myDGV.ColumnCount; i++)
                {
                    worksheet.Cells[r + 2, i + 1] = "'" + myDGV.Rows[r].Cells[i].Value;
                }
                Application.DoEvents();
            }
            worksheet.Columns.EntireColumn.AutoFit();//列宽自适应
            if (saveFileName != "")
            {
                try
                {
                    workbook.Saved = true;
                    workbook.SaveCopyAs(saveFileName);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("导出文件时出错,文件可能正被打开！\n" + ex.Message);
                }
            }
            xlApp.Quit();
            GC.Collect();//强行销毁
            MessageBox.Show("文件 " + fileName + ".xls 保存成功", "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public void ExportExcel_claout(string fileName, DataGridView myDGV)
        {
            string saveFileName = "";
            SaveFileDialog saveDialog = new SaveFileDialog();
            saveDialog.DefaultExt = "xls";
            saveDialog.Filter = "Excel文件|*.xls";
            saveDialog.FileName = fileName;
            saveDialog.ShowDialog();
            saveFileName = saveDialog.FileName;
            if (saveFileName.IndexOf(":") < 0) return; //被点了取消
            Excel.Application xlApp = new Excel.Application();
            if (xlApp == null)
            {
                MessageBox.Show("无法创建Excel对象，可能您可能未安装Excel");
                return;
            }
            Excel.Workbooks workbooks = xlApp.Workbooks;
            Excel.Workbook workbook = workbooks.Add(Excel.XlWBATemplate.xlWBATWorksheet);
            Excel.Worksheet worksheet = (Excel.Worksheet)workbook.Worksheets[1];//取得sheet1
                                                                                //写入标题

            //worksheet.Cells[1, 0] = myDGV.Columns[i].HeaderText;
            worksheet.Cells[1, 1] = "课程号         ";
            worksheet.Cells[1, 2] = "课程名    ";
            worksheet.Cells[1, 3] = "学分   ";
            worksheet.Cells[1, 4] = "教师工号  ";
            worksheet.Cells[1, 5] = "开始周数  ";
            worksheet.Cells[1, 6] = "结束周数  ";
            worksheet.Cells[1, 7] = "教学楼        ";
            worksheet.Cells[1, 8] = "教室  ";
            worksheet.Cells[1, 9] = "课程时间（周数节数）中间以*隔开";
            //写入数值
            for (int r = 0; r < myDGV.Rows.Count; r++)
            {
                for (int i = 0; i < myDGV.ColumnCount; i++)
                {
                    worksheet.Cells[r + 2, i + 1] = "'" + myDGV.Rows[r].Cells[i].Value;
                }
                Application.DoEvents();
            }
            worksheet.Columns.EntireColumn.AutoFit();//列宽自适应
            if (saveFileName != "")
            {
                try
                {
                    workbook.Saved = true;
                    workbook.SaveCopyAs(saveFileName);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("导出文件时出错,文件可能正被打开！\n" + ex.Message);
                }
            }
            xlApp.Quit();
            GC.Collect();//强行销毁
            MessageBox.Show("文件 " + fileName + ".xls 保存成功", "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public void ExportExcel_stulife(string fileName, DataGridView myDGV)
        {
            string saveFileName = "";
            SaveFileDialog saveDialog = new SaveFileDialog();
            saveDialog.DefaultExt = "xls";
            saveDialog.Filter = "Excel文件|*.xls";
            saveDialog.FileName = fileName;
            saveDialog.ShowDialog();
            saveFileName = saveDialog.FileName;
            if (saveFileName.IndexOf(":") < 0) return; //被点了取消
            Excel.Application xlApp = new Excel.Application();
            if (xlApp == null)
            {
                MessageBox.Show("无法创建Excel对象，可能您可能未安装Excel");
                return;
            }
            Excel.Workbooks workbooks = xlApp.Workbooks;
            Excel.Workbook workbook = workbooks.Add(Excel.XlWBATemplate.xlWBATWorksheet);
            Excel.Worksheet worksheet = (Excel.Worksheet)workbook.Worksheets[1];//取得sheet1
                                                                                //写入标题

            //worksheet.Cells[1, 0] = myDGV.Columns[i].HeaderText;
            worksheet.Cells[1, 1] = "课程名称     ";
            worksheet.Cells[1, 2] = "学分    ";
            worksheet.Cells[1, 3] = "考试成绩  ";
            //worksheet.Cells[1, 4] = "学院        ";


            //写入数值
            for (int r = 0; r < myDGV.Rows.Count; r++)
            {
                for (int i = 0; i < myDGV.ColumnCount; i++)
                {
                    worksheet.Cells[r + 2, i + 1] = "'" + myDGV.Rows[r].Cells[i].Value;
                }
                Application.DoEvents();
            }
            worksheet.Columns.EntireColumn.AutoFit();//列宽自适应
            if (saveFileName != "")
            {
                try
                {
                    workbook.Saved = true;
                    workbook.SaveCopyAs(saveFileName);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("导出文件时出错,文件可能正被打开！\n" + ex.Message);
                }
            }
            xlApp.Quit();
            GC.Collect();//强行销毁
            MessageBox.Show("文件 " + fileName + ".xls 保存成功", "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
