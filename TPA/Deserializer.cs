using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.IO;

namespace TPA
{
    class Deserializer
    {
        public static void Deserialization()
        {
            try
            {
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Product>), new XmlRootAttribute("Products"));
                StreamReader reader = new StreamReader("products.xml");
                List<Product> LProducts = (List<Product>)xmlSerializer.Deserialize(reader);

                Console.WriteLine();
                foreach (Product ListProduct in LProducts)
                {
                    Console.WriteLine($"ID: {ListProduct.Id}");
                    Console.WriteLine($"CATEGORY: {ListProduct.Category}");
                    Console.WriteLine($"TITLE: {ListProduct.Title}");
                    Console.WriteLine($"PRICE: {ListProduct.price.Value} {ListProduct.price.Unit}");
                    Console.WriteLine($"WEIGHT: {ListProduct.description.Weight}");
                    Console.WriteLine();
                }

                reader.Close();
                Console.WriteLine("Десериализация завершена!");
                Console.ReadKey();

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            /*
            try
            {
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(Product));
                StreamReader reader = new StreamReader("products.xml");
                Product product = (Product)xmlSerializer.Deserialize(reader);
                Console.WriteLine($"ID: {product.Id}");

                Console.WriteLine("Десериализация завершена");

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            */
        }
    }
}
