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
                string mainFile = @"products.xml";
                if (!File.Exists(mainFile))
                {
                    
                    Info info = new Info();
                    List<Product> LProducts = new List<Product>();
                
                    Console.WriteLine();
                    Console.Write("Id: ");
                    info.Id = Convert.ToInt32(Console.ReadLine());
                    Console.Write("Category: ");
                    info.Category = Console.ReadLine();
                    Console.Write("Title: ");
                    info.Title = Console.ReadLine();
                    Console.Write("Price: ");
                    info.Price = Convert.ToDecimal(Console.ReadLine());
                    Console.Write("Weight: ");
                    info.Weight = Convert.ToDecimal(Console.ReadLine());
                    Console.WriteLine();

                    LProducts.Add(new Product { Id = info.Id, Category = info.Category, Title = info.Title, price = new Price { Value = info.Price, Unit = "RUB" }, description = new Description { Weight = info.Weight } });

                    XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Product>), new XmlRootAttribute("Products"));
                    StreamWriter writer = new StreamWriter(mainFile);
                    xmlSerializer.Serialize(writer, LProducts);
                    writer.Close();
                    Console.WriteLine("The file does not exist, so a new file was created...");
                }
                else if(File.Exists(mainFile))
                {
                    Console.WriteLine("File exist...");
                    Add();
                }
                else
                {
                    Console.WriteLine("Error");
                }

                Console.WriteLine("Serialization completed...");

                while(true)
                {
                    Console.Write("Press and choose [Y/N]\nY - to add\nN - to break\n");
                    var key = System.Console.ReadKey(true);
                    switch(key.Key)
                    {
                        case System.ConsoleKey.Y:
                            Add();
                            continue;
                        case System.ConsoleKey.N:
                            Console.WriteLine("\nBreak down...");
                            Console.ReadKey();
                            break;
                        default:
                            break;
                    }
                    break;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.ReadKey();
            }
        }
        public static void Add()
        {
            string mainFile = @"products.xml";
            Info info = new Info();
            XmlDocument doc = new XmlDocument();
            doc.Load(mainFile);

            Console.WriteLine();
            Console.Write("Id: ");
            info.Id = Convert.ToInt32(Console.ReadLine());
            Console.Write("Category: ");
            info.Category = Console.ReadLine();
            Console.Write("Title: ");
            info.Title = Console.ReadLine();
            Console.Write("Price: ");
            info.Price = Convert.ToDecimal(Console.ReadLine());
            Console.Write("Weight: ");
            info.Weight = Convert.ToDecimal(Console.ReadLine());
            Console.WriteLine();

            XmlNode product = doc.CreateElement("Product");
            XmlAttribute id = doc.CreateAttribute("id");
            XmlAttribute category = doc.CreateAttribute("category");
            XmlNode title = doc.CreateElement("title");
            XmlNode price = doc.CreateElement("price");
            XmlAttribute unit = doc.CreateAttribute("unit");
            XmlNode description = doc.CreateElement("description");
            XmlNode weight = doc.CreateElement("weight");

            id.Value = Convert.ToString(info.Id);
            category.Value = Convert.ToString(info.Category);
            product.Attributes.Append(id);
            product.Attributes.Append(category);
            title.InnerText = Convert.ToString(info.Title);
            product.AppendChild(title);
            unit.Value = "RUB";
            price.InnerText = Convert.ToString(info.Price);
            price.Attributes.Append(unit);
            product.AppendChild(price);
            weight.InnerText = Convert.ToString(info.Weight);
            description.AppendChild(weight);
            product.AppendChild(description);
            doc.DocumentElement.AppendChild(product);
            doc.Save(mainFile);

            Console.WriteLine("Product added...");
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
    public class Info: IInfo
    {
        public int Id { get; set; }
        public string Category { get; set; }
        public string Title { get; set; }
        public decimal Price { get; set; }
        public decimal Weight { get; set; }
    }
}
