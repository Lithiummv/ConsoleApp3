using System;
using System.Collections.Generic;
using System.Linq;
using LinqToExcel;

namespace ConsoleApp3
{
    public class Program
    {
        static void Main(string[] args)
        {
            string pathCustomersList = @"..\..\..\..\CustomersList.xlsx";
            string pathProductList = @"..\..\..\..\ProductList.xlsx";
            string pathProductPrice = @"..\..\..\..\ProductPrice.xlsx";
            List<Product> products = new();
            ExcelReader excelReader = new();
            excelReader.GetDataFromFirstFile(ref products, pathProductPrice);
            excelReader.GetDataFromSecondFile(ref products, pathProductList);
            excelReader.GetDataFromThirdFile(ref products, pathCustomersList);
            excelReader.SortAndOutput(ref products);
        }
    }
}
