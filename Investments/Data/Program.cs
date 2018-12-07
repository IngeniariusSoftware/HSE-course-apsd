using System;
using System.Collections.Generic;
using System.Linq;

namespace Data
{
    using System.IO;

    class Program
    {
        private static List<List<double>> _projects = new List<List<int>>();

        private static double[,] _investments;
        
        private static double _money;

        private static void PrintProjects()
        {
            Console.WriteLine($"Размер инвестиций: {_money}\n");

            for (int y = 0; y < _projects.Count; y++)
            {
                for (int x = 0; x < _projects[y].Count; i++)
                {
                    if (y == 0)
                    {
                        Console.Write($"П{y + 1, 5}");
                    }
                    else
                    {
                        Console.Write($"{_projects[y][x], 5}");
                    }
                }
            }

            Console.WriteLine("\n");
        }

        private static void InvestmentsParser()
        {
            StreamReader input = new StreamReader("input.txt");
            _money = double.Parse(input.ReadLine());
            while (!input.EndOfStream)
            {
                string[] tokens = input.ReadLine().Split(' ');
                _projects.Add(new List<double>());
                for (int i = 0; i < tokens.Length; i++)
                {
                    _projects.Last().Add(double.Parse(tokens[i]));
                }
            }

            _investments = new double[_projects.Count, _projects.First().Count];
        }

        private static void DynamicInvest()
        {
            for (int x = 0; x < _projects.First().Count; x++)
            {
                for (int y = 0; y < _projects.Count; y++)
                {
                    double max;
                    if (x == 0)
                    {
                        _investments[y, x] = _projects[y][x];
                    }
                    else
                    {
                        
                    }
                }
            }
        }

        static void Main()
        {
            InvestmentsParser();
            PrintProjects();



        }
    }
}
