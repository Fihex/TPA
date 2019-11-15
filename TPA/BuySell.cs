using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace TPA
{
    class BuySell
    {
        public static void RemoveProducts()
        {
            try
            {
                string mainFile = @"products.xml";
                if (!File.Exists(mainFile))
                {
                    Console.Write("File not found\nPress and choose [Y/N]\nY - to add\nN - to break\n");
                    var key = System.Console.ReadKey(true);
                    switch(key.Key)
                    {
                        case System.ConsoleKey.Y:
                            Serializer.Serialization();
                            break;
                        case System.ConsoleKey.N:
                            Console.WriteLine("\nBreak down...");
                            Console.ReadKey();
                            break;
                        default:
                            break;
                    }
                }
                else if(File.Exists(mainFile))
                {
                    Info info = new Info();
                    XDocument xDoc = XDocument.Load(mainFile);

                    Console.Write("Id: ");
                    info.Id = Convert.ToInt32(Console.ReadLine());
                    Console.Write("Category: ");
                    info.Category = Console.ReadLine();

                    xDoc.Element("Products")
                    .Descendants("Product")
                    .Where(x => (string)x.Attribute("id") == "" + info.Id && (string)x.Attribute("category") == "" + info.Category)
                    .Remove();

                    xDoc.Save(mainFile);

                    while(true)
                    {
                        Console.Write("Press and choose [Y/N]\nY - to add\nN - to break\n");
                        var key = System.Console.ReadKey(true);
                        switch(key.Key)
                        {
                            case System.ConsoleKey.Y:

                                Console.Write("Id: ");
                                info.Id = Convert.ToInt32(Console.ReadLine());
                                Console.Write("Category: ");
                                info.Category = Console.ReadLine();

                                xDoc.Element("Products")
                                .Descendants("Product")
                                .Where(x => (string)x.Attribute("id") == "" + info.Id && (string)x.Attribute("category") == "" + info.Category)
                                .Remove();

                                xDoc.Save(mainFile);

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
                    
                    var doc = new XmlDocument();
                    doc.Load(mainFile);

                    var node = doc.SelectSingleNode("Products/Product");

                    if(node == null)
                    {
                        File.Delete(mainFile);
                    }
                    else
                    {
                        Console.WriteLine("O_o");
                    }
                }
                else
                {
                    Console.WriteLine("Error");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.ReadKey();
            }
        }
        public static decimal Buy()
        {
                Info info = new Info();
                string mainFile = @"products.xml";
                XDocument doc = XDocument.Load(mainFile);

                Console.Write("Id: ");
                info.Id = Convert.ToInt32(Console.ReadLine());
                Console.Write("Category: ");
                info.Category = Console.ReadLine();

                var node = from product in doc.Descendants("Product")
                           where (string)product.Attribute("id") == "" + info.Id && (string)product.Attribute("category") == "" + info.Category
                           select new
                           {
                               id = product.Attribute("id").Value,
                               category = product.Attribute("category").Value,
                               title = product.Element("title").Value,
                               price = product.Element("price").Value,
                               weight = product.Element("description").Element("weight").Value
                           };

                decimal result = 0;
                Console.WriteLine("You buy product or products...\n");
                foreach ( var nod in node)
                {
                    Console.WriteLine("Id: " + nod.id);
                    Console.WriteLine("Category: " + nod.category);
                    Console.WriteLine("Title: " + nod.title);
                    Console.WriteLine("Price: " + nod.price + " RUB");
                    Console.WriteLine("weight: " + nod.weight);
                    result = Convert.ToDecimal(nod.price);
                }
                doc.Element("Products")
                                .Descendants("Product")
                                .Where(x => (string)x.Attribute("id") == "" + info.Id && (string)x.Attribute("category") == "" + info.Category)
                                .Remove();

                doc.Save(mainFile);

                var docA = new XmlDocument();
                docA.Load(mainFile);

                var nodeA = docA.SelectSingleNode("Products/Product");

                if (nodeA == null)
                {
                    File.Delete(mainFile);
                }
                else
                {
                    Console.WriteLine("O_o");
                }

            /*IEnumerable<string element = xDoc.Element("Products").Descendants("Product")
            .Where(x => (string)x.Attribute("id") == "" + info.Id && (string)x.Attribute("category") == "" + info.Category)
            .Select(r => r.Element("Price")).Value;*/

            Console.ReadKey();

                return result;
        }
    }
}
