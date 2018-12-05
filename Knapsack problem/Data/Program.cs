namespace Data
{
    using System;
    using System.Collections.Generic;
    using System.IO;

    class Program
    {
        private static List<(string itemName, double cost, double weight, int count, double value)> _items =
            new List<(string itemName, double cost, double weight, int count, double value)>();

        private static (List<int> items, double sum, double weight) _bestKit = (null, -1, 0);

        private static double _backpackVolume = 0;

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
                            _backpackVolume = double.Parse(tokens[0]);
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
            if (backpackKit.Count > _items.Count)
            {
                if (_bestKit.sum < sum)
                {
                    _bestKit.items = backpackKit;
                    _bestKit.sum = sum;
                    _bestKit.weight = backpackWeight;
                }
            }
            else
            {
                if (backpackKit[backpackKit.Count - 1] < _items[backpackKit.Count - 1].count
                    && backpackWeight + _items[backpackKit.Count - 1].weight <= _backpackVolume)
                {
                    List<int> newBackpackItems1 = new List<int>(backpackKit);
                    newBackpackItems1[newBackpackItems1.Count - 1]++;
                    CollectBackpack(
                        newBackpackItems1,
                        sum + _items[backpackKit.Count - 1].cost,
                        backpackWeight + _items[backpackKit.Count - 1].weight);
                }

                List<int> newBackpackItems2 = new List<int>(backpackKit);
                newBackpackItems2.Add(0);
                CollectBackpack(newBackpackItems2, sum, backpackWeight);
            }
        }

        private static void PrintBackpack()
        {
            if (_bestKit.items != null)
            {
                Console.WriteLine($"Сумма: {_bestKit.sum}; Вес: {_bestKit.weight}\n");
                for (int i = 0; i < _bestKit.items.Count - 1; i++)
                {
                    if (_bestKit.items[i] != 0)
                    {
                        Console.WriteLine(
                            $"Название: {_items[i].itemName, 6}; Цена: {_items[i].cost, 4}; Вес: {_items[i].weight, 4}; Количество: {_bestKit.items[i], 3}; Суммарная стоимость: {_items[i].count * _items[i].cost, 4}, Суммарный вес: {_items[i].count * _items[i].weight}");
                    }
                }
            }
        }

        private static void PrintItems()
        {
            Console.WriteLine($"Вместимость рюкзака: {_backpackVolume}\n");
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
            CollectBackpack(backpackKit, 0, 0);
            PrintBackpack();
            Console.ReadKey();
        }
    }
}