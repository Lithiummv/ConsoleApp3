using System;
using System.Collections.Generic;
using System.Linq;
using LinqToExcel;

namespace ConsoleApp3
{
    class Program
    {
        static void Main(string[] args)
        {
            string pathCustomersList = @"..\..\..\..\CustomersList.xlsx";
            string pathProductList = @"..\..\..\..\ProductList.xlsx";
            string pathProductPrice = @"..\..\..\..\ProductPrice.xlsx";
            List<Product> products = new();
            ExcelReader excelReader = new();
            excelReader.ReadProductPrice(ref products, pathProductPrice);
            excelReader.ReadProductList(ref products, pathProductList);
            excelReader.ReadCustomerList(ref products, pathCustomersList);
            excelReader.SortAndOutput(ref products);
        }
    }
}
