using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3
{
    public class Product
    {
        public int ProductId { get; set; }
        public int CustomerId { get; set; }
        public string? ProductName { get; set; }
        public string? CustomerName { get; set; }
        public string? Description { get; set; }
        public double? Price { get; set; }
        public DateTime? Date { get; set; }
    }
}
