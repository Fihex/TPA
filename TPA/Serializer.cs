using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using System.IO;

namespace TPA
{
    class Serializer
    {
        public static void Serialization()
        {
            try
            {
                string curFile = @"products.xml";
                if (!File.Exists(curFile))
                {
                    
                    Info info = new Info();
                    List<Product> LProducts = new List<Product>();
                
                    Console.WriteLine();
                    Console.Write("ID: ");
                    info.Id = Convert.ToInt32(Console.ReadLine());
                    Console.Write("CATEGORY: ");
                    info.Category = Console.ReadLine();
                    Console.Write("TITLE: ");
                    info.Title = Console.ReadLine();
                    Console.Write("PRICE: ");
                    info.Price = Convert.ToDecimal(Console.ReadLine());
                    Console.Write("WEIGHT: ");
                    info.Weight = Convert.ToDecimal(Console.ReadLine());
                    Console.WriteLine();

                    LProducts.Add(new Product { Id = info.Id, Category = info.Category, Title = info.Title, price = new Price { Value = info.Price, Unit = "RUB" }, description = new Description { Weight = info.Weight } });

                    XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Product>), new XmlRootAttribute("Products"));
                    StreamWriter writer = new StreamWriter("products.xml");
                    xmlSerializer.Serialize(writer, LProducts);
                    writer.Close();
                    Console.WriteLine("Файл не существует: поэтому был создан файл!");
                }
                else if(File.Exists(curFile))
                {
                    Add();

                    Console.WriteLine("Файл существует!");
                    Console.ReadKey();
                }
                else
                {
                    Console.WriteLine("ERROR");
                }

                Console.WriteLine("Сериализация завершена!");

                for (var e = 0; ; e++)
                {
                    Console.Write("Напишите [Y/N] чтобы добавить ещё или завершить: ");
                    char confirm = Convert.ToChar(Console.ReadLine());
                    if (confirm == 'Y')
                    {
                        Add();
                    }
                    else if (confirm == 'N')
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("ERROR");
                        break;
                    }
                }

                Console.ReadKey();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.ReadKey();
            }
            /*
            try
            {
                Product product = new Product { Id = 1, Category = "Fruits", Title = "Apple", price = new Price { Value = 100.99m, Unit = "RUB" }, description = new Description { Weight = 0.12m} };
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(Product));
                StreamWriter writer = new StreamWriter("products.xml");
                xmlSerializer.Serialize(writer, product);
                writer.Close();
                Console.WriteLine("Сериализация завершена");

            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
            */
        }
        public static void Add()
        {
            Info info = new Info();
            XmlDocument doc = new XmlDocument();
            doc.Load("products.xml");

            Console.WriteLine();
            Console.Write("ID: ");
            info.Id = Convert.ToInt32(Console.ReadLine());
            Console.Write("CATEGORY: ");
            info.Category = Console.ReadLine();
            Console.Write("TITLE: ");
            info.Title = Console.ReadLine();
            Console.Write("PRICE: ");
            info.Price = Convert.ToDecimal(Console.ReadLine());
            Console.Write("WEIGHT: ");
            info.Weight = Convert.ToDecimal(Console.ReadLine());
            Console.WriteLine();

            XmlNode product = doc.CreateElement("Product");
            XmlAttribute id = doc.CreateAttribute("id");
            id.Value = Convert.ToString(info.Id);
            XmlAttribute category = doc.CreateAttribute("category");
            category.Value = Convert.ToString(info.Category);
            product.Attributes.Append(id);
            product.Attributes.Append(category);
            XmlNode title = doc.CreateElement("title");
            title.InnerText = Convert.ToString(info.Title);
            product.AppendChild(title);
            XmlNode price = doc.CreateElement("price");
            XmlAttribute unit = doc.CreateAttribute("unit");
            unit.Value = "RUB";
            price.InnerText = Convert.ToString(info.Price);
            price.Attributes.Append(unit);
            product.AppendChild(price);
            XmlNode description = doc.CreateElement("description");
            XmlNode weight = doc.CreateElement("weight");
            weight.InnerText = Convert.ToString(info.Weight);
            description.AppendChild(weight);
            product.AppendChild(description);
            doc.DocumentElement.AppendChild(product);
            doc.Save("products.xml");
            Console.WriteLine("Продукт добавлен!");
            Console.ReadKey();

        }
    }
    interface IInfo
    {
        int Id { get; set; }
        string Category { get; set; }
        string Title { get; set; }
        decimal Price { get; set; }
        decimal Weight { get; set; }
    }
    public class Info
    {
        public int Id { get; set; }
        public string Category { get; set; }
        public string Title { get; set; }
        public decimal Price { get; set; }
        public decimal Weight { get; set; }
    }
}
