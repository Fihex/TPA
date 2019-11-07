using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using System.Xml.Linq;
using System.IO;

namespace TPA
{
    class Deserializer
    {
        public static void DeserializationUser()
        {
            try
            {
                string curFile = @"products.xml";
                if (!File.Exists(curFile))
                {
                    Console.WriteLine("Продавец ещё не добавил продукты!");
                }
                else if(File.Exists(curFile))
                {
                    XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Product>), new XmlRootAttribute("Products"));
                    StreamReader reader = new StreamReader("products.xml");
                    List<Product> LProducts = (List<Product>)xmlSerializer.Deserialize(reader);

                    Console.WriteLine();
                    foreach (Product ListProduct in LProducts)
                    {
                        Console.WriteLine($"ID: {ListProduct.Id}");
                        Console.WriteLine($"CATEGORY: {ListProduct.Category}");
                        Console.WriteLine($"TITLE: {ListProduct.Title}");
                        Console.WriteLine($"PRICE: {ListProduct.price.Value} {ListProduct.price.Unit}");
                        Console.WriteLine($"WEIGHT: {ListProduct.description.Weight}");
                        Console.WriteLine();
                    }

                    reader.Close();
                    Console.WriteLine("Десериализация завершена!");
                    Console.ReadKey();
                }
                else
                {
                    Console.WriteLine("ERROR");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            /*
            try
            {
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(Product));
                StreamReader reader = new StreamReader("products.xml");
                Product product = (Product)xmlSerializer.Deserialize(reader);
                Console.WriteLine($"ID: {product.Id}");

                Console.WriteLine("Десериализация завершена");

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            */
        }
       public static void DeserializationTrader()
        {
            try
            {
                string curFile = @"products.xml";
                if (!File.Exists(curFile))
                {
                    Console.WriteLine("Файл не существует!");
                    Console.WriteLine("Создать файл [Y/N]");
                    char confirm = Convert.ToChar(Console.ReadLine());
                    if (confirm == 'Y')
                    {
                        Serializer.Serialization();
                    }
                    else if (confirm == 'N')
                    {
                        Console.WriteLine("BREAK");
                    }
                    else
                    {
                        Console.WriteLine("ERROR");
                    }
                }
                else if(File.Exists(curFile))
                {
                    XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Product>), new XmlRootAttribute("Products"));
                    StreamReader reader = new StreamReader("products.xml");
                    List<Product> LProducts = (List<Product>)xmlSerializer.Deserialize(reader);

                    Console.WriteLine();
                    foreach (Product ListProduct in LProducts)
                    {
                        Console.WriteLine($"ID: {ListProduct.Id}");
                        Console.WriteLine($"CATEGORY: {ListProduct.Category}");
                        Console.WriteLine($"TITLE: {ListProduct.Title}");
                        Console.WriteLine($"PRICE: {ListProduct.price.Value} {ListProduct.price.Unit}");
                        Console.WriteLine($"WEIGHT: {ListProduct.description.Weight}");
                        Console.WriteLine();
                    }

                    reader.Close();
                    Console.WriteLine("Десериализация завершена!");
                    Console.ReadKey();
                }
                else
                {
                    Console.WriteLine("ERROR");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
