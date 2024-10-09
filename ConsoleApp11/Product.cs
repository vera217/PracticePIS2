using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp11
{
    public class Product
    {
        public DateTime Date { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; }
        public bool Exist { get; set; }

        public Product( DateTime date, string name, int quantity, bool exist)
        {
            Date = date;
            Name = name;
            Quantity = quantity;
            Exist = exist;
        }

        public static string PrintInfo(Product product)
        {
            return $"Дата поступления - {product.Date:yyyy.MM.dd}\n" +
                   $"Название товара - {product.Name}\n" +
                   $"Количество - {product.Quantity} кг\n" + $"Существует - {product.Exist }";
           
        }
    }
}
