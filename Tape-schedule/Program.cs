﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tape_schedule
{
    class Program
    {
        public static int VvodNonNegative()
        {
            Console.WriteLine("\n\tПожалуйста, введите натуральное число:");
            bool rightNonNegative;
            do
            {
                rightNonNegative = int.TryParse(Console.ReadLine(), out int numberZahlen);
                if (numberZahlen < 1)
                {
                    rightNonNegative = false;
                }

                if (!rightNonNegative)
                {
                    Console.WriteLine("\n\t\aК сожалению, вы можете ввести только натуральное число.");
                    Console.WriteLine("\n\tПопробуйте ввести число ещё раз:");
                }
                else
                {
                    return numberZahlen;
                }
            }
            while (!rightNonNegative);

            return 0;
        }

        static void Main()
        {
            Console.WriteLine("\n\tВвод количества работ");
            int workCount = VvodNonNegative();
            int[] workTime = new int[workCount];
            for (int i = 0; i < workCount; i++)
            {
                Console.WriteLine("\n\tВведите время выполенния работы {0}", (char)(65 + i));
                workTime[i] = VvodNonNegative();
            }

            Console.WriteLine("\n\tВвод количества работников");
            int workerCount = VvodNonNegative();
            int maxWorkTime;
            if (workTime.Last() > workTime.Sum() / workerCount)
            {
                maxWorkTime = workTime.Last();

            }
            else
            {
                maxWorkTime = workTime.Sum() / workerCount;
            }

            int j = -1;
            for (int i = 0; i < workerCount; i++)
            {
                if (j == -1 || workTime[j] == 0)
                {
                    j = Array.BinarySearch(workTime, workTime.Max());
                }

                Console.Write("\tРаботник {0}:", i + 1);
                int deltaWorkTime = maxWorkTime;
                while (workTime.Sum() > 0 && deltaWorkTime > 0)
                {
                    if (deltaWorkTime >= workTime[j])
                    {
                        Console.Write(
                            " {0} ({1} - {2});",
                            (char)(65 + j),
                            maxWorkTime - deltaWorkTime,
                            maxWorkTime - deltaWorkTime + workTime[j]);
                        deltaWorkTime -= workTime[j];
                        workTime[j] = 0;
                        j--;
                    }
                    else
                    {
                        Console.Write(
                            " {0} ({1} - {2});",
                            (char)(65 + j),
                            maxWorkTime - deltaWorkTime,
                            maxWorkTime);
                        workTime[j] -= deltaWorkTime;
                        deltaWorkTime = 0;
                    }
                }

                Console.WriteLine("\n");
            }

            Console.WriteLine("\tДля завершения работы нажите любую клавишу...");
            Console.ReadKey();
        }
    }
}
