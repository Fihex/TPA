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
                string mainFile = @"products.xml";
                if(File.Exists(mainFile))
                {

                    var doc = new XmlDocument();
                    doc.Load(mainFile);

                    var node = doc.SelectSingleNode("Products/Product");

                    if(node == null)
                    {   
                        Console.WriteLine("Seller did not add products!");
                        Console.ReadKey();
                    }
                    else
                    {

                        XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Product>), new XmlRootAttribute("Products"));
                        StreamReader reader = new StreamReader(mainFile);
                        List<Product> LProducts = (List<Product>)xmlSerializer.Deserialize(reader);

                        Console.WriteLine();
                        foreach (Product ListProduct in LProducts)
                        {
                            Console.WriteLine($"Id: {ListProduct.Id}");
                            Console.WriteLine($"Category: {ListProduct.Category}");
                            Console.WriteLine($"Title: {ListProduct.Title}");
                            Console.WriteLine($"Price: {ListProduct.price.Value} {ListProduct.price.Unit}");
                            Console.WriteLine($"Weight: {ListProduct.description.Weight}");
                            Console.WriteLine();
                        }

                        reader.Close();

                        Console.WriteLine("Deserialization completed...");
                    }
                }
                else if (!File.Exists(mainFile))
                {
                    Console.WriteLine("Seller did not add products!");
                }
                else
                {
                    Console.WriteLine("Error");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
       public static void DeserializationTrader()
        {
            try
            {
                string mainFile = @"products.xml";
                if(File.Exists(mainFile))
                {

                    var doc = new XmlDocument();
                    doc.Load(mainFile);

                    var node = doc.SelectSingleNode("Products/Product");

                    if(node == null)
                    {
                        Console.Write("Press and choose [Y/N]\nY - to add\nN - to break\n");
                        var keyOne = System.Console.ReadKey(true);
                        switch(keyOne.Key)
                        {
                        case System.ConsoleKey.Y:
                            Serializer.Serialization();
                            break;
                        case System.ConsoleKey.N:
                            Console.WriteLine("\nBreak down...");
                            Console.ReadKey();
                            break;
                        default:
                            File.Delete(mainFile);
                            break;
                        }
                    }
                    else
                    {

                        XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Product>), new XmlRootAttribute("Products"));
                        StreamReader reader = new StreamReader(mainFile);
                        List<Product> LProducts = (List<Product>)xmlSerializer.Deserialize(reader);

                        Console.WriteLine();
                        foreach (Product ListProduct in LProducts)
                        {
                            Console.WriteLine($"Id: {ListProduct.Id}");
                            Console.WriteLine($"Category: {ListProduct.Category}");
                            Console.WriteLine($"Title: {ListProduct.Title}");
                            Console.WriteLine($"Price: {ListProduct.price.Value} {ListProduct.price.Unit}");
                            Console.WriteLine($"Weight: {ListProduct.description.Weight}");
                            Console.WriteLine();
                        }

                        reader.Close();

                        Console.WriteLine("Deserialization completed...");
                    }
                    Console.ReadKey();
                }
                else if (!File.Exists(mainFile))
                {

                    Console.Write("Press and choose [Y/N]\nY - to add\nN - to break\n");
                    var keyTwo = System.Console.ReadKey(true);
                    switch(keyTwo.Key)
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
                else
                {
                    Console.WriteLine("Error");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
