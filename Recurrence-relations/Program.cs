using System;
using System.Diagnostics;

namespace Recurrence_relations
{
    using System.Collections.Generic;

    public class Recurrence
    {
        public double X0, X1;

        public Recurrence(double x0, double x1)
        {
            X0 = x0;
            X1 = x1;
        }

        public double Recursion(int n)
        {
            switch (n)
            {
                case 0:
                    {
                        return X0;
                    }

                case 1:
                    {
                        return X1;
                    }

                default:
                    {
                        return 12 * n - 2 * Recursion(n - 1) - Recursion(n - 2);
                    }
            }
        }

        public double Iteratively(int n)
        {

            switch (n)
            {
                case 0:
                    {
                        return X0;
                    }

                case 1:
                    {
                        return X1;
                    }

                default:
                    {
                        double x1 = X0, x2 = X1, shelf;
                        for (int i = 2; i <= n; i++)
                        {
                            shelf = x2;
                            x2 = 12 * i - 2 * x2 - x1;
                            x1 = shelf;
                        }

                        return x2;
                    }
            }
        }

        public double Formula(int n)
        {
            return (9 * n - 4) * Math.Pow(-1, n) + 3 * n + 3;
        }
    }

    class Program
    {
        public static void VvodNonNegative(out int numberZahlen)
        {
            Console.WriteLine("\n\tПожалуйста, введите целое неотрицательное число:");
            bool rightNonNegative;
            do
            {
                rightNonNegative = int.TryParse(Console.ReadLine(), out numberZahlen);
                if (numberZahlen < 0)
                {
                    rightNonNegative = false;
                }

                if (!rightNonNegative)
                {
                    Console.WriteLine("\n\t\aК сожалению, вы можете ввести только неотрицательное число.");
                    Console.WriteLine("\n\tПопробуйте ввести число ещё раз:.");
                }
            }
            while (!rightNonNegative);
        }

        static void Main()
        {
            Recurrence recurrence = new Recurrence(-1, 1);
            Console.WriteLine("\n\tВвод номера члена последовательности");
            VvodNonNegative(out int n);
            Stopwatch stopWatch = new Stopwatch();
            Console.WriteLine("\n\tРезультат выполнения формулой:");
            stopWatch.Start();
            Console.WriteLine("\n\tРезультат: {0}, Время: {1}", recurrence.Formula(n), stopWatch.Elapsed);
            stopWatch.Reset();
            Console.WriteLine("\n\tРезультат выполнения циком:");
            stopWatch.Start();
            Console.WriteLine("\n\tРезультат: {0}, Время: {1}", recurrence.Iteratively(n), stopWatch.Elapsed);
            stopWatch.Reset();
            Console.WriteLine("\n\tРезультат выполнения рекурсией:");
            stopWatch.Start();
            Console.WriteLine("\n\tРезультат: {0}, Время: {1}", recurrence.Recursion(n), stopWatch.Elapsed);
            stopWatch.Reset();
            Console.WriteLine("\n\tДля завершения работы нажмите любую кнопку...");
            Console.ReadKey();
        }
    }
}
