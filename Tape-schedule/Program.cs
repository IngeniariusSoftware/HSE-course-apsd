using System;
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
            Console.WriteLine("\n\tПожалуйста, введите целое неотрицательное число:");
            bool rightNonNegative;
            do
            {
                rightNonNegative = int.TryParse(Console.ReadLine(), out int numberZahlen);
                if (numberZahlen < 0)
                {
                    rightNonNegative = false;
                }

                if (!rightNonNegative)
                {
                    Console.WriteLine("\n\t\aК сожалению, вы можете ввести только неотрицательное число.");
                    Console.WriteLine("\n\tПопробуйте ввести число ещё раз:.");
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
            Console.WriteLine((int)'A');

            Console.WriteLine("\n\tВвод количества работ");
            int workCount = VvodNonNegative();
            int [] workTime = new int[workCount];
            for (int i = 0; i < workCount; i++)
            {
                Console.WriteLine("\n\tВвод количества работ");
                workTime[i] = VvodNonNegative();

            }


        }
    }
}
