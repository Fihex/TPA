using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TPA
{
    abstract class Bank
    {
        public abstract decimal Balance { get; set;}

        public abstract void Print();

    }
    class AccountUser : Bank
    {
        public override decimal Balance { get; set; } = 1000;
    
        public override void Print()
        {
            Console.WriteLine("Your Balance: " + Balance);
            Console.ReadKey();
        }

    }
    class AccountTrader : Bank
    {
        public override decimal Balance { get; set; } = 0;

        public override void Print()
        {
            Console.WriteLine("Your Balance: " + Balance);
            Console.ReadKey();
        }

    }
}
