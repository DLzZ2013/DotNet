using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NPOI;
using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using Ado.Net;

namespace NPOI
{
    class Program
    {
        static void Main(string[] args)
        {
            Test1();
        }

        public static void Test()
        {
            var list = new List<Person>
            {
                new Person{  Name= "LBJ", Age = 34},
                new Person{Name = "DW", Age= 36},
                new Person{Name = "CP", Age= 33},
                new Person{Name = "KMA",Age = 34},
            };
            //1、创建工作簿
            var workbook = new HSSFWorkbook();
            //创建表
            var sheet = workbook.CreateSheet("NPOI");
            //2、插入数据
            for (int i = 0; i < list.Count; i++)
            {
                //创建行
                var row = sheet.CreateRow(i);
                //创建单元格
                row.CreateCell(0).SetCellValue(list[i].Name);
                row.CreateCell(1).SetCellValue(list[i].Age);
            }
            //3、写入
            using (var fs = File.Open("D:\\TestArea\\NBAplayers.xls", FileMode.OpenOrCreate, FileAccess.Write))
            {
                workbook.Write(fs);
            }

            Console.ReadKey();
        }

        public static void Test1()
        {
            int sss = 1;
            using (var fs = File.Open("D:\\TestArea\\NBAplayers.xls", FileMode.OpenOrCreate, FileAccess.Read))
            {
                var workbook = new HSSFWorkbook(fs);
                //遍历sheet
                for (int i = 0; i < workbook.NumberOfSheets; i++)
                {
                    var sheet = workbook.GetSheetAt(i);
                    Console.WriteLine(sheet.SheetName);
                    //LastRowNum最后一行的索引
                    for (int j = 0; j <= sheet.LastRowNum; j++)
                    {
                        var row = sheet.GetRow(j);
                        for (int k = 0; k < row.LastCellNum; k++)
                        {
                            var cell = row.GetCell(k);
                            //把每个单元格中的内容当成字符串处理
                            Console.Write(cell.ToString() + " | ");
                        }

                        Console.WriteLine();
                    }
                }
            }
            Console.ReadKey();
        }
        //DB导出Excel
        private void button1_Click(object sender, EventArgs e)
        {
            //1.通过Ado.net读取数据
            string sql = "SELECT * FROM T_Seats";
            using (SqlDataReader reader = SqlHelper.ExecuteReader(sql, CommandType.Text))
            {
                if (reader.HasRows)
                {
                    IWorkbook wk = new HSSFWorkbook();
                    ISheet sheet = wk.CreateSheet("T_Seats");

                    #region 创建第一行，设置列名
                    //--------------------------------------------------
                    //创建第一行，第一行表示列名
                    IRow rowHead = sheet.CreateRow(0);
                    //循环查询出的每一列
                    for (int col = 0; col < reader.FieldCount; col++)
                    {
                        rowHead.CreateCell(col).SetCellValue(reader.GetName(col));
                    }
                    //--------------------------------------------------
                    #endregion

                    int rindex = 1;
                    //下面是创建数据行
                    while (reader.Read())
                    {
                        //CC_AutoId, CC_LoginId, CC_LoginPassword, CC_UserName, CC_ErrorTimes, CC_LockDateTime, CC_TestInt
                        IRow currentRow = sheet.CreateRow(rindex);
                        rindex++;
                        int autoId = reader.GetInt32(0);
                        string loginId = reader.GetString(1);
                        string password = reader.GetString(2);
                        string username = reader.GetString(3);
                        int errorTimes = reader.GetInt32(4);
                        DateTime? lockDate = reader.IsDBNull(5) ? null : (DateTime?)reader.GetDateTime(5);
                        int? testInt = reader.IsDBNull(6) ? null : (int?)reader.GetInt32
(6);

                        currentRow.CreateCell(0).SetCellValue(autoId);
                        currentRow.CreateCell(1).SetCellValue(loginId);
                        currentRow.CreateCell(2).SetCellValue(password);
                        currentRow.CreateCell(3).SetCellValue(username);
                        currentRow.CreateCell(4).SetCellValue(errorTimes);
                        if (lockDate == null)
                        {
                            //如果是null值，那么就像excel写入一个单元格，这个单元格的类型就是Blank
                            currentRow.CreateCell(5).SetCellType(CellType.Blank);
                        }
                        else
                        {

                            //创建一个单元格
                            ICell cellLockDate = currentRow.CreateCell(5);

                            //创建一个单元格样式
                            ICellStyle cellStyle = wk.CreateCellStyle();
                            cellStyle.DataFormat = HSSFDataFormat.GetBuiltinFormat("m/d/yy h:mm");
                            //设置当前单元格应用cellStyle样式
                            cellLockDate.CellStyle = cellStyle;


                            cellLockDate.SetCellValue((DateTime)lockDate);
                        }

                        if (testInt == null)
                        {
                            currentRow.CreateCell(6).SetCellType(CellType.Blank);
                        }
                        else
                        {
                            currentRow.CreateCell(6).SetCellValue((int)testInt);
                        }
                    }

                    //写入
                    using (FileStream fsWrite = File.OpenWrite("tseats.xls"))
                    {
                        wk.Write(fsWrite);
                    }
                    //label1.Text = "写入成功！" + DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss");
                }
                else
                {
                    //label1.Text = "没有查询到任何数据";
                }
            }
            //2.写入excel
        }


        //把excel中的内容导入到表
        private void button2_Click(object sender, EventArgs e)
        {
            //读取Excel
            using (FileStream fsRead = File.OpenRead("tseats.xls"))
            {
                //创建 工作簿
                IWorkbook wk = new HSSFWorkbook(fsRead);
                //创建工作表
                ISheet sheet = wk.GetSheetAt(0);

                string insert_sql = "INSERT INTO NewTSeats VALUES(@uid,@pwd,@name,@errorTimes,@lockDate,@testInt)";

                //遍历读取所有
                for (int i = 1; i <= sheet.LastRowNum; i++)
                {
                    SqlParameter[] pms = new SqlParameter[] {
                    new SqlParameter("@uid",SqlDbType.NVarChar,50),
                    new SqlParameter("@pwd",SqlDbType.VarChar,50),
                    new SqlParameter("@name",SqlDbType.NVarChar,50),
                    new SqlParameter("@errorTimes",SqlDbType.Int),
                    new SqlParameter("@lockDate",SqlDbType.DateTime),
                    new SqlParameter("@testInt",SqlDbType.Int)
                    };

                    //获取每一行
                    IRow currentRow = sheet.GetRow(i);
                    if (currentRow != null)//表示有该行对象
                    {
                        //遍历读取每一个单元格
                        for (int c = 1; c < currentRow.LastCellNum; c++)
                        {
                            ICell currentCell = currentRow.GetCell(c);

                            //判断单元格是否为空
                            if (currentCell == null || currentCell.CellType == CellType.Blank)
                            {
                                //表示空值，要向数据库中插入DBNull.Value
                                pms[c - 1].Value = DBNull.Value;
                            }
                            else
                            {
                                if (c == 5)
                                {

                                    //pms[c - 1].Value = DateTime.Parse(currentCell.ToString());
                                    //如果当前的列是一个日期类型，那么直接把该值作为一个number类型来读取，读取到后，通过DateTime.FromOADate()来转换为DateTime类型。
                                    pms[c - 1].Value = DateTime.FromOADate(currentCell.NumericCellValue);

                                }
                                else
                                {
                                    pms[c - 1].Value = currentCell.ToString();
                                }
                            }

                        }
                        SqlHelper.ExecuteNonQuery(insert_sql, CommandType.Text, pms);
                    }

                }
            }

            //将数据插入到Db中
            //label1.Text = "导入成功！" + DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss");
        }
    }

    class Person
    {
        private int sss = 2;
        public string Name { get; set; }

        public int Age { get; set; }
    }
}
