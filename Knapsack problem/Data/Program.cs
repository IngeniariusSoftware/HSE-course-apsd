namespace Data
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    class Program
    {
        private static List<(string itemName, double cost, double weight, int count, double value)> ParserItems()
        {
            var items = new List<(string itemName, double cost, double weight, int count, double value)>();
            StreamReader input = new StreamReader("input.txt");
            while (!input.EndOfStream)
            {
                string[] tokens = input.ReadLine().Split(' ');
                switch (tokens.Length)
                {
                    case 2:
                        {
                            items.Add(
                                (items.Count.ToString(), double.Parse(tokens[0]), double.Parse(tokens[1]), 1,
                                    double.Parse(tokens[0]) / double.Parse(tokens[1])));
                            break;
                        }

                    case 3:
                        {
                            items.Add(
                                (items.Count.ToString(), double.Parse(tokens[0]), double.Parse(tokens[1]),
                                    int.Parse(tokens[2]), double.Parse(tokens[0]) / double.Parse(tokens[1])));
                            break;
                        }

                    case 4:
                        {
                            items.Add(
                                (tokens[0], double.Parse(tokens[1]), double.Parse(tokens[2]), int.Parse(tokens[2]),
                                    double.Parse(tokens[1]) / double.Parse(tokens[2])));
                            break;
                        }
                }
            }

            input.Close();
            return items;
        }

        static void Main()
        {
            var items = ParserItems();
            items.Sort();

        }
    }
}
