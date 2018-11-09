namespace Data
{
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;

    class Program
    {
        private static Dictionary<(string, bool), List<string>> Nodes = new Dictionary<(string, bool), List<string>>();

        private static List<(string, string)> CurrentPars = new List<(string, string)>();

        private static void ParseNodes()
        {
            foreach (string lineNodes in File.ReadAllLines("input.txt"))
            {
                string[] inputNodes = lineNodes.Split(' ', ':', ';', ',');
                Nodes[(inputNodes[0], true)] = new List<string>();
                for (int i = 1; i < inputNodes.Length; i++)
                {
                    if (inputNodes[i] != string.Empty)
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
        }

        private static void KunAlgorithm()
        {
            foreach (var node in Nodes)
            {
                if (node.Key.Item2 && node.Value.Count > 0)
                {
                    var shelfNodes = new List<(string, string)>(CurrentPars);
                    if (!CheckNode((node.Key.Item1, "")))
                    {
                        CurrentPars = new List<(string, string)>(shelfNodes);
                    }
                }
            }
        }

        private static bool CheckNode((string, string) node)
        {
            int indexKey = CurrentPars.FindIndex(x => x.Item1 != node.Item1 && x.Item2 == node.Item2);
            if (indexKey != -1)
            {
                (string, string) currentNode = CurrentPars[indexKey];
                int indexNextNodes = Nodes[(currentNode.Item1, true)].FindIndex(x => x == node.Item2);
                if (indexNextNodes < Nodes[(currentNode.Item1, true)].Count - 1)
                {
                    currentNode.Item2 = Nodes[(CurrentPars[indexKey].Item1, true)][indexNextNodes + 1];
                    CurrentPars[indexKey] = currentNode;
                    return CheckNode(currentNode);
                }
                else
                {
                    return false;
                }
            }
            else
            {
                if (CurrentPars.FindIndex(x => x.Item1 == node.Item1) == -1)
                {
                    CurrentPars.Add((node.Item1, Nodes[(node.Item1, true)][0]));
                    if (CurrentPars.FindIndex(x => x.Item2 == Nodes[(node.Item1, true)][0] && x.Item1 != node.Item1) != -1)
                    {
                        return CheckNode((node.Item1, Nodes[(node.Item1, true)][0]));
                    }
                    else
                    {
                        return true;
                    }
                }
                else
                {
                   return true;
                }
            }
        }

        static void Main()
        {
            ParseNodes();
            KunAlgorithm();
            StreamWriter output = new StreamWriter("output.txt");
            foreach ((string, string) currentPar in CurrentPars)
            {
                output.WriteLine("{0} - {1}", currentPar.Item1, currentPar.Item2);
            }
            output.Close();
        }
    }
}
