using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml;
using System.Xml.Linq;

namespace TPA
{
    class BuySell
    {
        public static void DeleteProducts()
        {
            try
            {

                Info info = new Info();
                XDocument xDoc = XDocument.Load("products.xml");

                Console.Write("ID: ");
                info.Id = Convert.ToInt32(Console.ReadLine());
                Console.Write("CATEGORY: ");
                info.Category = Console.ReadLine();

                xDoc.Element("Products")
                .Descendants("Product")
                .Where(x => (string)x.Attribute("id") == "" + info.Id && (string)x.Attribute("category") == "" + info.Category)
                .Remove();
                xDoc.Save("products.xml");

                for (var e = 0; ; e++)
                {
                    Console.Write("Напишите [Y/N] чтобы добавить ещё или завершить: ");
                    char confirm = Convert.ToChar(Console.ReadLine());
                    if (confirm == 'Y')
                    {
                        Console.Write("ID: ");
                        info.Id = Convert.ToInt32(Console.ReadLine());
                        Console.Write("CATEGORY: ");
                        info.Category = Console.ReadLine();

                        xDoc.Element("Products")
                        .Descendants("Product")
                        .Where(x => (string)x.Attribute("id") == "" + info.Id && (string)x.Attribute("category") == "" + info.Category)
                        .Remove();
                        xDoc.Save("products.xml");
                        continue;
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
                /*foreach (XElement xNode in xDoc.Root.Nodes())
                {
                    Console.Write("ID: ");
                    info.Id = Convert.ToInt32(Console.ReadLine());
                    Console.Write("CATEGORY: ");
                    info.Category = Console.ReadLine();

                    if (xNode.Attribute("id").Value == "" + info.Id && xNode.Attribute("category").Value == "" + info.Category)
                    {
                        xNode.Remove();
                    }
                    else
                    {
                        Console.WriteLine("Попробуйте снова!");
                    }
                */

                /*Info info = new Info();
                XDocument xDoc = XDocument.Load("products.xml");

                foreach (XElement xNode in xDoc.Root.Nodes())
                {
                    Console.Write("ID: ");
                    info.Id = Convert.ToInt32(Console.ReadLine());
                    Console.Write("CATEGORY: ");
                    info.Category = Console.ReadLine();

                    if (xNode.Attribute("id").Value == "" + info.Id && xNode.Attribute("category").Value == "" + info.Category)
                    {
                        xNode.Remove();
                    }
                    xDoc.Save("products.xml");

                    for (var i = 0; ; i++)
                    {
                        Console.Write("Напишите [Y/N] чтобы добавить ещё или завершить: ");
                        char confirm = Convert.ToChar(Console.ReadLine());
                        if (confirm == 'Y')
                        {
                            Console.Write("ID: ");
                            info.Id = Convert.ToInt32(Console.ReadLine());
                            Console.Write("CATEGORY: ");
                            info.Category = Console.ReadLine();

                            if (xNode.Attribute("id").Value == Convert.ToString(info.Id) && xNode.Attribute("category").Value == Convert.ToString(info.Category))
                            {
                                xNode.Remove();
                            }
                            xDoc.Save("products.xml");
                        }
                        else if (confirm == 'N')
                        {
                            xDoc.Save("products.xml");
                            break;
                        }
                        else
                        {
                            Console.WriteLine("ERROR");
                            break;
                        }
                    }
                    break;
                }*/
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.ReadKey();
            }
        }
    }
}
