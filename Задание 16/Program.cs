using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Text.Unicode;
using System.Threading.Tasks;

namespace Задание_16_1
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                #region Вводим товары и формируем экземпляры класса
               
                Console.WriteLine("Введите код, имя и стоимость первого товара.");
                string[] good1 = { Console.ReadLine(), Console.ReadLine(), Console.ReadLine() };
                Goods product1 = new Goods()
                {
                    ArticleGood = Convert.ToInt32(good1[0]),
                    NameGood = good1[1],
                    PriceGood = Convert.ToDouble(good1[2])
                };

                Console.WriteLine("Введите код, имя и стоимость второго товара.");
                string[] good2 = { Console.ReadLine(), Console.ReadLine(), Console.ReadLine() };
                Goods product2 = new Goods()
                {
                    ArticleGood = Convert.ToInt32(good2[0]),
                    NameGood = good2[1],
                    PriceGood = Convert.ToDouble(good2[2])
                };

                Console.WriteLine("Введите код, имя и стоимость третьего товара.");
                string[] good3 = { Console.ReadLine(), Console.ReadLine(), Console.ReadLine() };
                Goods product3 = new Goods()
                {
                    ArticleGood = Convert.ToInt32(good3[0]),
                    NameGood = good3[1],
                    PriceGood = Convert.ToDouble(good3[2])
                };

                Console.WriteLine("Введите код, имя и стоимость четвертого товара.");
                string[] good4 = { Console.ReadLine(), Console.ReadLine(), Console.ReadLine() };
                Goods product4 = new Goods()
                {
                    ArticleGood = Convert.ToInt32(good4[0]),
                    NameGood = good4[1],
                    PriceGood = Convert.ToDouble(good4[2])
                };

                Console.WriteLine("Введите код, имя и стоимость пятого товара.");
                string[] good5 = { Console.ReadLine(), Console.ReadLine(), Console.ReadLine() };
                Goods product5 = new Goods()
                {
                    ArticleGood = Convert.ToInt32(good5[0]),
                    NameGood = good5[1],
                    PriceGood = Convert.ToDouble(good5[2])
                };

                Goods[] productsArray = { product1, product2, product3, product4, product5 };

                #endregion

                #region Создаём директорию и файл
                string path = "C:/Users/i.smirnov/source/repos";
                string filePath = "C:/Users/i.smirnov/source/reposProducts.json";

                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }

                if (!File.Exists(filePath))
                {
                    File.Create(filePath);
                }

                using (StreamWriter clearFile = new StreamWriter(filePath, false))
                {
                    clearFile.Write("");
                }
                #endregion

                #region Преобразование класса в json
                JsonSerializerOptions options = new JsonSerializerOptions()
                {
                    Encoder = JavaScriptEncoder.Create(UnicodeRanges.BasicLatin, UnicodeRanges.Cyrillic),
                    WriteIndented = true
                };

                string jsonProduct1 = JsonSerializer.Serialize(productsArray, options);

                #endregion

                #region Запись в файл
                using (StreamWriter lineFile = new StreamWriter(filePath, true))
                {
                    lineFile.WriteLine(jsonProduct1);
                }
                Console.WriteLine(jsonProduct1);
            }

            #endregion


            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }




            Console.WriteLine("Нажмите любую кнопку, чтобы закрыть программу");
            Console.ReadKey();

        }
    }
    public class Goods
    {
        [JsonPropertyName("Код товара")]
        public int ArticleGood { get; set; }
        [JsonPropertyName("Название товара")]
        public string NameGood { get; set; }
        [JsonPropertyName("Цена товара")]
        public double PriceGood { get; set; }
    }
}
