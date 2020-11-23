using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TRPO_labe_6.Models;

namespace TRPO_labe_6_console
{
    public class ShopsContext
    {
        private List<Shop> Shops;

        public ShopsContext()
        {
            Shops = GetBoolAnswer("Десериализовать ли магазины из файла? \n1. Да\n2. Нет", x => x == 1) ? new ShopsDeserializer($"{Directory.GetCurrentDirectory()}//shops.json").GetAll() : new List<Shop>();
            StartContext();
        }

        private void StartContext()
        {
            while (true)
            {
                Console.WriteLine("1. Добавить магазин");
                Console.WriteLine("2. Сохранить текущее состояние в файле");
                Console.WriteLine("3. Контроллер магазина");
                Console.WriteLine("Ответ: ");
                if (int.TryParse(Console.ReadLine(), out int answer))
                {
                    switch (answer)
                    {
                        case 1:
                        {
                            var builder = new ShopBuilder();
                            var shop = builder.Build();
                            Shops.Add(shop);
                            break;
                        }

                        case 2:
                        {
                            var serializer = new ShopsSerializer($"{Directory.GetCurrentDirectory()}//shops.json");
                            serializer.RewriteAll(Shops);
                            break;
                        }

                        case 3:
                        {
                            if (Shops.Count == 0)
                                Console.WriteLine("Магазинов нет!");
                            else
                            {
                                var shop = GetShop();
                                ShopController(shop);
                            }
                            break;
                        }
                    }
                }
            }
        }

        private void ShopController(Shop shop)
        {
            Console.WriteLine("1. Добавить продавца");
            Console.WriteLine("2. Удалить продавца");
            Console.WriteLine("3. Добавить товар");
            Console.WriteLine("4. Продать товар");
            Console.WriteLine("5. Посчитать общую сумму всех покупок");
            int answer = int.Parse(Console.ReadLine());
            switch (answer)
            {
                case 1:
                {
                    var builder = new ShopAssistantBuilder();
                    var assistant = builder.Build();
                    shop.Assistants.Add(assistant);
                    break;
                }

                case 2:
                {
                    if (shop.Assistants.Count == 0)
                    {
                        Console.WriteLine("Работников в этом магазине нет!");
                    }
                    else
                    {
                        var assist = GetShopAssistant(shop);
                        shop.Assistants.Remove(assist);
                    }
                    break;
                    }

                case 3:
                {
                    var builder = new ProductBuilder();
                    var product = builder.Build();
                    shop.AddProduct(product);
                    break;
                }

                case 4:
                {
                    var assist = GetShopAssistant(shop);
                    if (assist == null)
                        return;
                    var product = GetProduct(shop);
                    if (product == null)
                        return;
                    shop.SellProduct(assist, product);
                    break;
                }

                case 5:
                {
                    Console.WriteLine($"Общая стоимость покупок: {shop.CalculateOverall()}");
                    break;
                }
            }
        }

        private Shop GetShop()
        {
            Console.WriteLine("Список магазинов: ");
            for (int i = 0; i < Shops.Count; i++)
                Console.WriteLine($"{i} : {Shops[i]}");
            int index = int.Parse(Console.ReadLine() ?? throw new InvalidOperationException());
            if (index < 0 || index >= Shops.Count) throw new IndexOutOfRangeException();
            return Shops[index];
        }

        private ShopAssistant GetShopAssistant(Shop shop)
        {
            if (shop.Assistants.Count == 0)
            {
                Console.WriteLine("Ассистентов нет!");
                return null;
            }
            Console.WriteLine("Список работников: ");
            for (int i = 0; i < shop.Assistants.Count; i++)
                Console.WriteLine($"{i} : {shop.Assistants[i]}");
            int index = int.Parse(Console.ReadLine() ?? throw new InvalidOperationException());
            if (index < 0 || index >= shop.Assistants.Count) throw new IndexOutOfRangeException();
            return shop.Assistants[index];
        }

        private Product GetProduct(Shop shop)
        {
            if (shop.Products.Count == 0)
            {
                Console.WriteLine("В магазине нет продуктов!");
                return null;
            }
            Console.WriteLine("Список продуктов: ");
            for (int i = 0; i < shop.Products.Count; i++)
                Console.WriteLine($"{i} : {shop.Products.ElementAt(i)}");
            int index = int.Parse(Console.ReadLine() ?? throw new InvalidOperationException());
            if (index < 0 || index >= shop.Products.Count) throw new IndexOutOfRangeException();
            return shop.Products.ElementAt(index);
        }

        private bool GetBoolAnswer(string text, Func<int, bool> func)
        {
            Console.WriteLine(text);
            string answer = Console.ReadLine();
            if (int.TryParse(answer, out int answerResult))
            {
                if (func.Invoke(answerResult))
                {
                    return true;
                }
            }

            return false;
        }

        private bool GetBoolAnswer(string text, Func<string, bool> func)
        {
            Console.WriteLine(text);
            string answer = Console.ReadLine();
            if (func.Invoke(answer))
                return true;
            return false;
        }
    }
}
