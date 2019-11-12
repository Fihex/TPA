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
                    doc.Load("products.xml");

                    var node = doc.SelectSingleNode("Products/Product");

                    if(node == null)
                    {
                        File.Delete("products.xml");
                    }
                    else
                    {
                        Console.WriteLine("-_-");
                    }
                }
                else
                {
                    Console.WriteLine("ERROR");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.ReadKey();
            }
        }
        public static void Buy()
        {
            try
            {
                Info info = new Info();
                XDocument xDoc = XDocument.Load("products.xml");

                Console.Write("Id: ");
                info.Id = Convert.ToInt32(Console.ReadLine());
                Console.Write("Category: ");
                info.Category = Console.ReadLine();

                string doc = xDoc.Element("Products")
                .Elements("Product")
                .Where(x => (string)x.Attribute("id") == "" + info.Id && (string)x.Attribute("category") == "" + info.Category)
                .Single()
                .Element("Price")
                .Value;
            
                Console.WriteLine(doc);
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
