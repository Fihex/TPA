using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;

namespace TPA
{
    class Program
    {
        static Menu Menu;

        static void Main(string[] args)
        {

            Console.OutputEncoding = Encoding.Default;

            Menu = new Menu
            (
                "Main Menu",
                new[]
                {
                    new Menu.Item("Buyer", new[]
                    {
                        new Menu.Item("Bank", new[]
                        {
                            new Menu.Item("Balance", BankUser),
                            new Menu.Item("Take Credits", Exit)
                        }),

                        new Menu.Item("Products", new[]
                        {
                            new Menu.Item("Show Products", DeserializerUser),
                            new Menu.Item("Buy Products", Buy)
                        })
                    }),
                    new Menu.Item("Seller", new[]
                    {
                        new Menu.Item("Bank", new[]
                        {
                            new Menu.Item("Balance", BankTrader)
                        }),

                        new Menu.Item("Product Management", new[]
                        {
                            new Menu.Item("Show Products", DeserializerTrader),
                            new Menu.Item("Add Products", AddProducts),
                            new Menu.Item("Remove Products", RemoveProducts),
                            new Menu.Item("Delete Product File", DeleteFile)
                        }),
                    }),
                    new Menu.Item("Exit", Exit),
                }
            );
            //Menu.Main.MaxColumns = 1;

            Menu.WriteLine("Press ←↑↓→ for navigation.");
            Menu.WriteLine("Press Esc to return Main Menu.");
            Menu.WriteLine("Press Backspace to go back.");
            Menu.WriteLine("Press Del for cleaning log.");

            Menu.Begin();
        }
        static void Exit()
        {
            Menu.Close();
        }
        static void DeleteFile()
        {
            Console.WriteLine("Do you really want to delete this file?\nPress and choose [Y/N]");
            var key = System.Console.ReadKey(true);
            switch(key.Key)
            {
                case System.ConsoleKey.Y:
                    File.Delete("products.xml");
                    Console.WriteLine("Deleted File...");
                    Console.ReadKey();
                    break;
                case System.ConsoleKey.N:
                    Console.WriteLine("\nBreak down...");
                    Console.ReadKey();
                    break;
                default:
                    break;
            }
        }
        static void AddProducts()
        {
            Serializer.Serialization();
        }
        static void RemoveProducts()
        {
            BuySell.RemoveProducts();
        }
        static void DeserializerUser()
        {

            Deserializer.DeserializationUser();
        }
        static void DeserializerTrader()
        {
            Deserializer.DeserializationTrader();
        }
        static void Buy()
        {
            BuySell.Buy();
        }
        static void BankUser()
        {
            Bank au = new AccountUser();
            au.Print();
        }
        static void BankTrader()
        {
            Bank at = new AccountTrader();
            at.Print();
        }
    }
}