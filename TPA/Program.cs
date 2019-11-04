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
                    new Menu.Item("Продукты", new[]
                    {
                        new Menu.Item("Список продуктов", Desert),
                        new Menu.Item("Добавить продукты с удаление файла", Sert),
                        new Menu.Item("Добавить продукты", ISert),
                        new Menu.Item("Удалить продукт", DSert),
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

        static void Print()
        {
            Menu.WriteLine("Selected: " + Menu.Selected.Name);
        }
        static void InputTest(string str)
        {
            var inp = Menu.Selected as Menu.InputItem;

            Menu.WriteLine("You wrote: " + inp.Value);
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
        static void Sert()
        {

            Serializer.Serialization();
        }
        static void DSert()
        {
            DelSell.DeleteF();
        }
        static void ISert()
        {
            Serializer.Add();
            for (var e = 0; ; e++)
            {
                Console.Write("Напишите [Y/N] чтобы добавить ещё или завершить: ");
                char confirm = Convert.ToChar(Console.ReadLine());
                if (confirm == 'Y')
                {
                    Serializer.Add();
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
        }
        static void Desert()
        {
            try
            {
                Deserializer.Deserialization();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            Console.ReadKey();
        }
    }
}