namespace Data
{
    using System;
    using System.Collections.Generic;
    using System.IO;

    class Program
    {
        private static List<(string itemName, double cost, double weight, int count, double value)> _items =
            new List<(string itemName, double cost, double weight, int count, double value)>();

        private static (List<int> items, double sum, double weight) bestKit = (null, -1, 0);

        private static double backpackVolume = 0;

        private static void ParserItems()
        {
            StreamReader input = new StreamReader("input.txt");
            while (!input.EndOfStream)
            {
                string[] tokens = input.ReadLine().Split(' ');
                switch (tokens.Length)
                {
                    case 1:
                        {
                            backpackVolume = double.Parse(tokens[0]);
                            break;
                        }

                    case 2:
                        {
                            _items.Add(
                                ((_items.Count + 1).ToString(), double.Parse(tokens[0]), double.Parse(tokens[1]), 1,
                                    double.Parse(tokens[0]) / double.Parse(tokens[1])));
                            break;
                        }

                    case 3:
                        {
                            _items.Add(
                                ((_items.Count + 1).ToString(), double.Parse(tokens[0]), double.Parse(tokens[1]),
                                    int.Parse(tokens[2]), double.Parse(tokens[0]) / double.Parse(tokens[1])));
                            break;
                        }

                    case 4:
                        {
                            _items.Add(
                                (tokens[0], double.Parse(tokens[1]), double.Parse(tokens[2]), int.Parse(tokens[3]),
                                    double.Parse(tokens[1]) / double.Parse(tokens[2])));
                            break;
                        }
                }
            }

            input.Close();
        }

        private static void CollectBackpack(List<int> backpackKit, double sum, double backpackWeight)
        {
            if (sum > bestKit.sum)
            {
                bestKit.sum = sum;
                bestKit.items = backpackKit;
                bestKit.weight = backpackWeight;
            }

            if (backpackKit.Count <= _items.Count)
            {
                // Проверяем, что еще остались предметы этого типа
                bool isLeft = backpackKit[backpackKit.Count - 1] < _items[backpackKit.Count - 1].count;

                // Проверяем, что хватает вместимости рюкзака для предмета
                bool isEmpty = backpackWeight + _items[backpackKit.Count - 1].weight <= backpackVolume;

                if (isEmpty && isLeft)
                {
                    if ((backpackVolume - backpackWeight) * _items[backpackKit.Count - 1].value + sum > bestKit.sum)
                    {
                        // Склонируем содержимое рюкзака, чтобы изменять в дальнейшем
                        List<int> newBackpackItems1 = new List<int>(backpackKit);

                        // Добавим предмет в рюкзак
                        newBackpackItems1[newBackpackItems1.Count - 1]++;

                        // Соберем рюкзак с учетом того, что положили этот предмет
                        CollectBackpack(
                            newBackpackItems1,
                            sum + _items[backpackKit.Count - 1].cost,
                            backpackWeight + _items[backpackKit.Count - 1].weight);
                    }
                }
                else
                {
                    // Склонируем содержимое рюкзака, чтобы изменять в дальнейшем
                    List<int> newBackpackItems2 = new List<int>(backpackKit);

                    // Переходим к следующему типу предметов
                    newBackpackItems2.Add(0);

                    // Соберем рюкзак для данного набора
                    CollectBackpack(newBackpackItems2, sum, backpackWeight);
                }
            }
        }

        private static void PrintBackpack()
        {
            if (bestKit.items != null)
            {
                Console.WriteLine($"Сумма: {bestKit.sum}; Вес: {bestKit.weight}\n");
                for (int i = 0; i < bestKit.items.Count - 1; i++)
                {
                    if (bestKit.items[i] != 0)
                    {
                        Console.WriteLine(
                            $"Название: {_items[i].itemName,6}; Цена: {_items[i].cost,4}; Вес: {_items[i].weight,4}; Количество: {bestKit.items[i],3}; Суммарная стоимость: {_items[i].count * _items[i].cost,4}, Суммарный вес: {_items[i].count * _items[i].weight}");
                    }
                }
            }
        }

        private static void PrintItems()
        {
            Console.WriteLine($"Вместимость рюкзака: {backpackVolume}\n");
            for (int i = 0; i < _items.Count - 1; i++)
            {
                Console.WriteLine(
                    $"Название: {_items[i].itemName,6}; Цена: {_items[i].cost,4}; Вес: {_items[i].weight,4}; Количество: {_items[i].count,3}; Удельная стоимость: {_items[i].value}");
            }

            Console.WriteLine("\n");
        }

        static void Main()
        {
            ParserItems();
            _items.Sort((x, y) => y.value.CompareTo(x.value));
            PrintItems();
            var backpackKit = new List<int>();
            backpackKit.Add(0);
            CollectBackpack(backpackKit, -1, 0);
            PrintBackpack();
            Console.ReadKey();
        }
    }
}