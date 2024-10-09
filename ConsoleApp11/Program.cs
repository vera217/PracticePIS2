using System;
using System.Data.SqlTypes;
using System.Globalization;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;

namespace ConsoleApp11
{
    class Program
    {
        
        static void Main(string[] args)

        {
            string s = "Поступление товаров: 2023.01.05; 'яблоки' ; 20 ;";
            Console.WriteLine(s);

            if (!s.StartsWith("Поступление товаров:"))
            {
                Console.WriteLine("Некорректный ввод: строка должна начинаться с Поступление товаров:");
                return;
            }

            s = s.Substring(s.IndexOf(":") + 1).Trim();
            string[] words = s.Split(new[] { ';' });

            if (words.Length < 3)
            {
                Console.WriteLine("Некорректные данные: недостаточно элементов.");
                return;
            }

            if (!DateTime.TryParseExact(words[0].Trim(), "yyyy.MM.dd", null, DateTimeStyles.None, out DateTime parsedDate))
            {
                Console.WriteLine("Неверный ввод даты");
                return;
            }

            string productName = words[1].Trim(' ', '\'');

            if (!Int32.TryParse(words[2].Trim(), out int quantity))
            {
                Console.WriteLine("Некорректные данные");
                return;
            }

            Console.WriteLine($"Введите true или false в зависимости от того, существует ли объект {parsedDate} {productName} {quantity}");
            string input = Console.ReadLine();

            if (input.ToLower() != "true" && input.ToLower() != "false")
            {
                Console.WriteLine("Некорректный ввод: необходимо ввести true или false.");
                return;
            }

            bool exist = Convert.ToBoolean(input);

            if (exist) 
            {
                Product product = new Product(parsedDate, productName, quantity, exist);
                Console.WriteLine(Product.PrintInfo(product));
            }
            else
            {
                Console.WriteLine("Объект не существует");
            }
            
        }

    }

}
