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
        private static List<(string itemName, int weight, int count)> ParserItems()
        {
            var items = new List<(string itemName, int weight, int count)>();
            StreamReader input = new StreamReader("input.txt");
            while (!input.EndOfStream)
            {
                string[] tokens = input.ReadLine().Split(' ');
                switch (tokens.Length)
                {
                    case 1:
                        {
                            items.Add((items.Count.ToString(), int.Parse(tokens[0]), 1));
                            break;
                        }

                    case 2:
                        {
                            items.Add((items.Count.ToString(), int.Parse(tokens[0]), int.Parse(tokens[1])));
                            break;
                        }

                    case 3:
                        {
                            items.Add((tokens[0], int.Parse(tokens[1]), int.Parse(tokens[2])));
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
            

        }
    }
}
