using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace HeirachicalTimetable
{
    using System.Drawing.Drawing2D;
    using System.Dynamic;
    using System.Linq;

    public class Point
    {
        public string Name;

        public List<string> Sheets = new List<string>();

        public Point(string name)
        {
            Name = name;
        }
    }

    public static class Reader
    {
        public static List<List<string>> Sheduler(List<Point> points, List<(string, string)> ribs, int workerCount)
        {
            List<List<string>> workStack = new List<List<string>>();
            List<(string, string)> ribsClone = ribs.GetRange(0, ribs.Count);
            int depth = 0;
            while (ribsClone.Count > 0)
            {
                List<Point> removePoints = new List<Point>();

                for (int j = 0; j < ribsClone.Count; j++)
                {
                    if (ribsClone.Count(x => x.Item1 == ribsClone[j].Item2) == 0)
                    {
                        removePoints.Add(points.Find(x => x.Name == ribsClone[j].Item2));
                    }
                }

                foreach (Point removePoint in removePoints)
                {
                    foreach (var rib in ribsClone.FindAll(x => x.Item2 == removePoint.Name))
                    {
                        points.Find(x => x.Name == rib.Item1).Sheets.AddRange(removePoint.Sheets);
                        points.Find(x => x.Name == rib.Item1).Sheets.Add(removePoint.Name);
                    }

                    ribsClone.RemoveAll(x => x.Item2 == removePoint.Name);
                }

                removePoints.Clear();
                depth++;
            }

            foreach (Point point in points)
            {
                point.Sheets = point.Sheets.Distinct().ToList();
            }

            while (ribs.Count > 0 || points.Count > 0)
            {
                workStack.Add(new List<string>());
                int countOkWork = 0;
                List<Point> needList = new List<Point>();
                foreach (var valueTuple in ribs)
                {
                    if (ribs.Count(x => x.Item2 == valueTuple.Item1) == 0)
                    {
                        needList.Add(points.Find(x => x.Name == valueTuple.Item1));
                    }
                }

                List<Point> removePoints = new List<Point>();
                needList = needList.Distinct().ToList();
                while (countOkWork < workerCount && (needList.Count > 0 || (ribs.Count == 0 && points.Count > 0)))
                {
                    Point bestPoint = null;
                    if (ribs.Count == 0)
                    {
                        foreach (Point point in points)
                        {
                            if (bestPoint == null)
                            {
                                bestPoint = point;
                            }
                            else
                            {
                                if (bestPoint.Sheets.Count < point.Sheets.Count)
                                {
                                    bestPoint = point;
                                }
                            }
                        }
                    }
                    else
                    {
                        foreach (Point point in needList)
                        {
                            if (bestPoint == null)
                            {
                                bestPoint = point;
                            }
                            else
                            {
                                if (bestPoint.Sheets.Count < point.Sheets.Count)
                                {
                                    bestPoint = point;
                                }
                            }
                        }
                    }

                    removePoints.Add(bestPoint);
                    workStack[workStack.Count - 1].Add(bestPoint.Name);
                    needList.Remove(bestPoint);
                    points.Remove(bestPoint);
                    countOkWork++;
                }

                foreach (Point removePoint in removePoints)
                {
                    ribs.RemoveAll(x => x.Item1 == removePoint.Name);
                }
            }

            return workStack;
        }

        public static List<(string, string)> Read()
        {
            OpenFileDialog ofd = new OpenFileDialog();

            var values = new List<string>();
            var chars = new List<(string, string)>();
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                var path = ofd.FileName;
                var text = File.ReadAllText(path);
                values = text.Split('\n').ToList();
                foreach (var line in values)
                {
                    var l = line.Replace("\n", String.Empty);
                    chars.Add((l[0].ToString(), l[2].ToString()));
                }
            }

            return chars;
        }

        public static List<string> GetUniquChars(List<(string, string)> chars)
        {
            var list = new List<string>();
            list.AddRange(chars.Select(x => x.Item1));
            list.AddRange(chars.Select(x => x.Item2));
            return list.Distinct().Where(x => x != null).Select(x => x).ToList();
        }
    }
}
