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
                "Главное меню",
                new[]
                {
                    new Menu.Item("Покупатель", new[]
                    {
                        new Menu.Item("Список продуктов", DeserializerUser),
                        new Menu.Item("Купить продукт", Exit),
                    }),
                    new Menu.Item("Продавец", new[]
                    {
                        new Menu.Item("Список продуктов", DeserializerTrader),
                        new Menu.Item("Добавить продукты", AddProducts),
                        new Menu.Item("Удалить продукты", DellProducts),
                        new Menu.Item("Удалить файл", DeleteFile)
                    }),
                    new Menu.Item("Выход", Exit),
                }
            );
            //Menu.Main.MaxColumns = 1;

            Account bank = new Account();

            Menu.WriteLine($"Баланс: {Convert.ToString(bank.Balance)}");
            Menu.WriteLine("Используйте ←↑↓→ для навигации.");
            Menu.WriteLine("Нажмите Esc чтобы вернуться в главное меню.");
            Menu.WriteLine("Нажмите Backspace чтобы вернуться назад.");
            Menu.WriteLine("Нажмите Del для очистки журнала.");

            Menu.Begin();
        }
        static void Exit()
        {
            Menu.Close();
        }
        static void DeleteFile()
        {
            File.Delete("products.xml");
            Console.WriteLine("Файл с продуктами удалён!");
            Console.ReadKey();
        }
        static void AddProducts()
        {
            Serializer.Serialization();
        }
        static void DellProducts()
        {
            BuySell.DeleteProducts();
        }
        static void DeserializerUser()
        {
            try
            {
                Deserializer.DeserializationUser();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            Console.ReadKey();
        }
        static void DeserializerTrader()
        {
            try
            {
                Deserializer.DeserializationTrader();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            Console.ReadKey();
        }
    }
}