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
        public void BuyProducts()
        {
            try
            {
                string patchFile = @"bank.xml";
                if (!File.Exists(patchFile))
                {
                    XDocument xDoc = new XDocument
                    (
                        new XDeclaration("1.0", "utf-8", "yes"),
                        new XElement("Bank",
                            new XElement("Accounts",
                                new XElement("Account",
                                    new XAttribute("title", "user"),
                                    new XElement("balance", 100)),
                                new XElement("Account",
                                    new XAttribute("title", "admin"),
                                    new XElement("balance", 0)
                    ))));
                    xDoc.Save(patchFile);

                    Console.WriteLine("The file does not exist, so a new file was created...\nTry click again...");
                    Console.ReadKey();
                }
                else if(File.Exists(patchFile))
                {
                    decimal pathBalance = BuySell.Buy();
                    XmlDocument doc = new XmlDocument();
                    doc.Load(patchFile);
                    money = GetBalance();
                    if (money == 0 || money < 0)
                    {
                        Console.WriteLine("You haven't balance");
                    }
                    else
                    {
                        Console.WriteLine("Your balance reduced: -" + pathBalance);
                        money -= pathBalance;
                        doc.SelectSingleNode("Bank/Accounts/Account[@title='user']/balance").InnerText = Convert.ToString(money);
                        Console.WriteLine("Your balance left: " + money);
                        XDocument docX = XDocument.Load(patchFile);

                        decimal result = 0;
                        var node = from accounts in docX.Descendants("Account")
                                   where (string)accounts.Attribute("title") == "admin"
                                   select new
                                   {
                                       balance = accounts.Element("balance").Value
                                   };

                        foreach (var nod in node)
                        {
                            result = Convert.ToDecimal(nod.balance);
                        }
                        result += pathBalance;
                        doc.SelectSingleNode("Bank/Accounts/Account[@title='admin']/balance").InnerText = Convert.ToString(result);
                        doc.Save(patchFile);
                    }

                    Console.ReadKey();
                }
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
                Console.ReadKey();
            }
        }
        public void ShowCredit()
        {
            try
            {
                string patchFile = @"bank.xml";
                if (!File.Exists(patchFile))
                {
                    XDocument xDoc = new XDocument
                    (
                        new XDeclaration("1.0", "utf-8", "yes"),
                        new XElement("Bank",
                            new XElement("Accounts",
                                new XElement("Account",
                                    new XAttribute("title", "user"),
                                    new XElement("balance", 100)),
                                new XElement("Account",
                                    new XAttribute("title", "admin"),
                                    new XElement("balance", 0)
                    ))));
                    xDoc.Save(patchFile);

                    Console.WriteLine("The file does not exist, so a new file was created...\nTry click again...");
                    Console.ReadKey();
                }
                else if(File.Exists(patchFile))
                {
                    AddBalance(ref money);
                    Balance = money;
                    Console.WriteLine("\nYour taked 100 credit: " + money);
                    Console.ReadKey();
                }
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
                Console.ReadKey();
            }
        }
        public override void Print()
        {
            try
            {
                string patchFile = @"bank.xml";
                if (!File.Exists(patchFile))
                {
                    XDocument xDoc = new XDocument
                    (
                        new XDeclaration("1.0", "utf-8", "yes"),
                        new XElement("Bank",
                            new XElement("Accounts",
                                new XElement("Account",
                                    new XAttribute("title", "user"),
                                    new XElement("balance", 100)),
                                new XElement("Account",
                                    new XAttribute("title", "admin"),
                                    new XElement("balance", 0)
                    ))));
                    xDoc.Save(patchFile);

                    Console.WriteLine("The file does not exist, so a new file was created...\nTry click again...");
                    Console.ReadKey();
                }
                else if(File.Exists(patchFile))
                {
                    ShowBalance(ref money);
                    Balance = money;
                    Console.WriteLine("\nYour balance: " + Balance);
                    Console.ReadKey();
                }

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

        public decimal money;

        public decimal GetBalance()
        {
            string patchFile = @"bank.xml";
            decimal result = 0;
            if (!File.Exists(patchFile))
            {
                XDocument xDoc = new XDocument
                (
                    new XDeclaration("1.0", "utf-8", "yes"),
                    new XElement("Bank",
                        new XElement("Accounts",
                            new XElement("Account",
                                new XAttribute("title", "user"),
                                new XElement("balance", 100)),
                            new XElement("Account",
                                new XAttribute("title", "admin"),
                                new XElement("balance", 0)
                ))));
                xDoc.Save(patchFile);
                
                Console.WriteLine("The file does not exist, so a new file was created...\nTry click again...");
                Console.ReadKey();
            }
            else if (File.Exists(patchFile))
            {
                XDocument doc = XDocument.Load(patchFile);

                var node = from accounts in doc.Descendants("Account")
                           where (string)accounts.Attribute("title") == "admin"
                           select new
                           {
                               balance = accounts.Element("balance").Value
                           };

                foreach (var nod in node)
                {
                    result = Convert.ToDecimal(nod.balance);
                }
            }
            else
            {
                Console.WriteLine("Error");
            }
            return result;
        }

        public decimal AddBalance(ref decimal money)
        {
            string patchFile = @"bank.xml";
            money = ShowBalance(ref money);
            money -= 100;
            XmlDocument doc = new XmlDocument();
            doc.Load(patchFile);
            doc.SelectSingleNode("Bank/Accounts/Account[@title='admin']/balance").InnerText = Convert.ToString(money);
            doc.Save(patchFile);
            return money;
        }

        public decimal ShowBalance(ref decimal money)
        {
            money = GetBalance();
            return money;
        }

        public override void Print()
        {
            try
            {
                ShowBalance(ref money);
                Balance = money;
                Console.WriteLine("Your balance: " + Balance);
                Console.ReadKey();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.ReadKey();
            }
        }
    }
}