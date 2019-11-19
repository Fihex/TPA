using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using System.Xml.Linq;

namespace TPA
{
    abstract class Bank
    {
        public abstract decimal Balance { get; set; }

        public abstract void Print();

    }
    class AccountUser : Bank
    {
        public override decimal Balance { get; set; }

        public decimal money;

        public decimal ShowBalance(ref decimal money)
        {
            money = GetBalance();
            return money;
        }
        public decimal GetBalance()
        {
            string patchFile = @"bank.xml";
            XDocument doc = XDocument.Load(patchFile);

            var node = from accounts in doc.Descendants("Account")
                       where (string)accounts.Attribute("title") == "user"
                       select new
                       {
                           balance = accounts.Element("balance").Value
                       };

            decimal result = 0;
            foreach (var nod in node)
            {
                result = Convert.ToDecimal(nod.balance);
            }

            return result;
        }
        public decimal AddBalance(ref decimal money)
        {
            string patchFile = @"bank.xml";
            money = ShowBalance(ref money);
            money += 100;
            XmlDocument doc = new XmlDocument();
            doc.Load(patchFile);
            doc.SelectSingleNode("Bank/Accounts/Account[@title='user']/balance").InnerText = Convert.ToString(money);
            doc.Save(patchFile);
            return money;
        }
        public void ShowCredit()
        {
            AddBalance(ref money);
            Balance = money;
            Console.WriteLine("\nYour taked 100 credit: " + money);
            Console.ReadKey();
        }
        public override void Print()
        {
            try
            {
                ShowBalance(ref money);
                Balance = money;
                Console.WriteLine("\nYour balance: " + Balance);
                Console.ReadKey();

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.ReadKey();
            }
        }
    }
    class AccountTrader : Bank
    {
        public override decimal Balance { get; set; }

        public override void Print()
        {
            try
            {

                Console.WriteLine(Balance);

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.ReadKey();
            }
        }
    }
}