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
        private static Dictionary<(string, bool), List<string>> Nodes = new Dictionary<(string, bool), List<string>>();

        private static void ParseNodes()
        {
            foreach (string lineNodes in File.ReadAllLines("input.txt"))
            {
                string[] inputNodes = lineNodes.Split(' ', ':', ',', ';');
                Nodes[(inputNodes[0], true)] = new List<string>();
                for (int i = 1; i < inputNodes.Length; i++)
                {
                    if (!Nodes.ContainsKey((inputNodes[i], false))) 
                    {
                        Nodes[(inputNodes[i], false)] = new List<string>();
                    }

                    Nodes[(inputNodes[0], true)].Add(inputNodes[i]);
                    Nodes[(inputNodes[i], false)].Add(inputNodes[0]);
                }
            }
        }

        private static void CunsAlgorithm()
        {
            foreach (var node in Nodes)
            {
                if (node.Key.Item2)
                {
                    
                }
            }
        }

        static void Main()
        {
            ParseNodes();

            Console.WriteLine("\n\tДля завершения работы нажмите любую клавишу...");
        }
    }
}
