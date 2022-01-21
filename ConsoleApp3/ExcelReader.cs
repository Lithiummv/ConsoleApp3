using System;
using System.Collections.Generic;
using System.Linq;
using LinqToExcel;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3
{
    class ExcelReader
    {
        public void ReadProductPrice(ref List<Product> products, string path)
        {
            ExcelQueryFactory productPrice = new(path);
            products = (from rowProductPrice in productPrice.Worksheet().ToList()
                        select new Product()
                        {
                            ProductId = rowProductPrice["ProductId"].Cast<int>(),
                            Price = rowProductPrice["Price"].Cast<double>(),
                            Date = rowProductPrice["DateTime"].Cast<DateTime>(),
                            CustomerId = rowProductPrice["CustomerId"].Cast<int>(),
                        }).ToList();
        }

        public void ReadProductList(ref List<Product> products, string path)
        {
            ExcelQueryFactory productList = new(path);
            var product = from rowProductList in productList.Worksheet().ToList()
                          select new
                          {
                              Id = rowProductList["Id"].Cast<int>(),
                              ProductName = rowProductList["ProductName"].Cast<string>(),
                          };

            foreach (Product productPrice in products)
            {
                productPrice.ProductName = product.ToList().Find(x => x.Id == productPrice.ProductId).ProductName;
            }
        }

        public void ReadCustomerList(ref List<Product> products, string path)
        {
            ExcelQueryFactory customersList = new(path);
            var customers = from rowCustomersList in customersList.Worksheet().ToList()
                            select new
                            {
                                Id = rowCustomersList["Id"].Cast<int>(),
                                CustomerName = rowCustomersList["CustomerName"].Cast<string>(),
                                Description = rowCustomersList["Description"].Cast<string>(),
                            };

            foreach (Product product in products)
            {
                var customer = customers.ToList().Find(x => x.Id == product.CustomerId);
                product.CustomerName = customer.CustomerName;
                product.Description = customer.Description;
            }
        }

        public void SortAndOutput(ref List<Product> products)
        {
            products = (from product in products
                        orderby product.Date
                        select product).ToList();

            Product secondProduct = products.Find(x => x.ProductId == 2);
            Console.WriteLine("ProductId = " + secondProduct.ProductId + " ProductName = " + secondProduct.ProductName + " CustomerName = " + secondProduct.CustomerName + " Description = " + secondProduct.Description);
        }
    }
}
