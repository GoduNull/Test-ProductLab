using Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Excel = Microsoft.Office.Interop.Excel;

namespace Logic.Managers
{
    public class WriteManager
    {
        public static void WriteExel(Root root, string search)
        {
            if (root.data is not null)
            {
                Excel.Application excelApp = new Excel.Application();
                excelApp.Visible = false;
                Excel.Workbook book = excelApp.Workbooks.Open(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "example.xlsx"));
                try
                {
                    var newlist = (Excel.Worksheet)book.Sheets[search]; //ошибка если вдруг нет нужного листа(а его легко может не быть),
                    //а если надо было каждый раз создавать новый файл и новые листы, то тогда проще
                    newlist.Cells[1, "A"] = "Title";
                    newlist.Cells[1, "B"] = "Brand";
                    newlist.Cells[1, "C"] = "Id";
                    newlist.Cells[1, "D"] = "Feddbacks";
                    newlist.Cells[1, "E"] = "Price";
                    int count = 2;
                    foreach (var item in root.data.Products)
                    {
                        newlist.Cells[count, "A"].Value = item.Brand + "/" + item.Name;
                        newlist.Cells[count, "B"].Value = item.Name;
                        newlist.Cells[count, "C"].Value = item.Id;
                        newlist.Cells[count, "D"].Value = item.Feedbacks;
                        newlist.Cells[count, "E"].Value = item.PriceU.Substring(0, item.PriceU.Length - 2);
                        count++;
                    }
                    book.Close(true);
                    excelApp.Application.Quit();
                    excelApp.Quit();
                }
                catch (Exception ex)
                {
                    excelApp.Application.Quit();
                    excelApp.Quit();
                    excelApp= new Excel.Application();
                    book= excelApp.Workbooks.Open(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "example.xlsx"));
                    Console.WriteLine(ex.Message);
                    var newlist = (Excel.Worksheet)book.Sheets.Add(After: book.ActiveSheet);
                    newlist.Name = search;
                    newlist.Cells[1, "A"] = "Title";
                    newlist.Cells[1, "B"] = "Brand";
                    newlist.Cells[1, "C"] = "Id";
                    newlist.Cells[1, "D"] = "Feddbacks";
                    newlist.Cells[1, "E"] = "Price";
                    int count = 2;
                    foreach (var item in root.data.Products)
                    {
                        newlist.Cells[count, "A"].Value = item.Brand + "/" + item.Name;
                        newlist.Cells[count, "B"].Value = item.Name;
                        newlist.Cells[count, "C"].Value = item.Id;
                        newlist.Cells[count, "D"].Value = item.Feedbacks;
                        newlist.Cells[count, "E"].Value = item.PriceU.Substring(0, item.PriceU.Length - 2);
                        count++;
                    }
                    book.Close(true);
                    excelApp.Application.Quit();
                    excelApp.Quit();
                }
            }
        }
    }
}
