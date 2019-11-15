using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TPA
{
    abstract class Bank
    {
        public abstract decimal Balance { get; set; }

        public abstract void Print();

    }
    class Account : Bank
    {
        public override decimal Balance { get; set; } = 100;

        public override void Print()
        {
            try
            {
                while (true)
                {
                    Console.Write("\nPress and choose [Y/C/B/S]\nY - to check balance\nC - to take credit + 100\nB - to buy pdoduct\nS - Show products\n\n");
                    var key = System.Console.ReadKey(true);
                    switch (key.Key)
                    {
                        case System.ConsoleKey.Y:

                            Console.WriteLine("Balance: " + Balance);
                            continue;
                        case System.ConsoleKey.C:
                            Balance += 100;
                            Console.WriteLine("You take credit: " + Balance);
                            continue;
                        case System.ConsoleKey.B:
                            Balance -= BuySell.Buy();
                            Console.WriteLine("You buy product and reduced balance: " + Balance);
                            continue;
                        case System.ConsoleKey.S:
                            Deserializer.DeserializationUser();
                            continue;
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
    }
}