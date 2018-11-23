using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace Data
{
    using System.IO;

    [TestClass]
    public class UnitTestAlgorithm
    {
        public static Random Rnd = new Random();

        public static StreamWriter Output = new StreamWriter("log.txt");

        [TestMethod]
        public void TestingAlgorithm()
        {
            bool isRight = true;
            for (int i = 1; i < 10000; i++)
            {
                (int[,], int) resultGenerator = GenerateFlowMatrix();
                var solver = new Solver((int[,])resultGenerator.Item1.Clone());
                (int[,], int) resultAlgorithm = solver.Solve();
                PrintMatrixInFile(resultGenerator, resultAlgorithm, i);
                if (resultAlgorithm.Item2 != resultGenerator.Item2)
                {
                    isRight = false;
                }
            }

            Output.Close();
            Assert.IsTrue(isRight);
        }

        public static (int[,], int) GenerateFlowMatrix()
        {
            int length = Rnd.Next(2, 20);
            int flow = 0;
            int[,] matrix = new int[length, length];
            int board = (int)Math.Floor(length / 2.0);
            for (int y = 0; y <= board; y++)
            {
                for (int x = board + 1; x < length; x++)
                {
                    matrix[y, x] = Rnd.Next(0, 20);
                    flow += matrix[y, x];
                }
            }

            for (int y = 0; y < length; y++)
            {
                for (int x = y + 1; x < length; x++)
                {
                    if (x < board + 1 || y > board)
                    {
                        matrix[y, x] = flow + Rnd.Next(0, 100);
                    }
                }
            }

            if (length < 3 && length > 0)
            {
                matrix[0, length - 1] = Rnd.Next(0, 100);
                flow = matrix[0, length - 1];
            }

            return (matrix, flow);
        }

        public static void PrintMatrix((int[,], int) resultGenerator, (int[,], int) resultAlgorithm, int testNumber)
        {
            Console.WriteLine("\nНомер теста: {0}", testNumber);
            Console.WriteLine("\nВремя: {0}", testNumber);
            Console.WriteLine("\nМатрица имеет вид:");
            for (int y = 0; y < resultGenerator.Item1.GetLength(0); y++)
            {
                for (int x = 0; x < resultGenerator.Item1.GetLength(1); x++)
                {
                    Console.Write("{0, 5} ", resultGenerator.Item1[y, x]);
                }

                Console.WriteLine();
            }

            Console.WriteLine("\nМатрица потоков вид:");
            for (int y = 0; y < resultAlgorithm.Item1.GetLength(0); y++)
            {
                for (int x = 0; x < resultAlgorithm.Item1.GetLength(1); x++)
                {
                    Console.Write("{0, 5} ", resultAlgorithm.Item1[y, x]);
                }

                Console.WriteLine();
            }

            Console.WriteLine("\nМаксимальный поток генератора: {0}", resultGenerator.Item2);
            Console.WriteLine("\nМаксимальный поток алгоритма: {0}", resultAlgorithm.Item2);
            if (resultAlgorithm.Item2 != resultGenerator.Item2)
            {
                Console.WriteLine("\nРезультат: Ошибка");
            }
            else
            {
                Console.WriteLine("\nРезультат: Успешно");
            }
        }

        public static void Main(string[] args)
        {

        }

        public static void PrintMatrixInFile((int[,], int) resultGenerator, (int[,], int) resultAlgorithm, int testNumber)
        {
            Output.WriteLine("\nНомер теста: {0}", testNumber);
            Output.WriteLine("\nВремя: {0}", DateTime.Now);
            Output.WriteLine("\nМатрица имеет вид:");
            for (int y = 0; y < resultGenerator.Item1.GetLength(0); y++)
            {
                for (int x = 0; x < resultGenerator.Item1.GetLength(1); x++)
                {
                    Output.Write("{0, 5} ", resultGenerator.Item1[y, x]);
                }

                Output.WriteLine();
            }

            Output.WriteLine("\nМатрица потоков вид:");
            for (int y = 0; y < resultAlgorithm.Item1.GetLength(0); y++)
            {
                for (int x = 0; x < resultAlgorithm.Item1.GetLength(1); x++)
                {
                    Output.Write("{0, 5} ", resultAlgorithm.Item1[y, x]);
                }

                Output.WriteLine();
            }

            Output.WriteLine("\nМаксимальный поток генератора: {0}", resultGenerator.Item2);
            Output.WriteLine("\nМаксимальный поток алгоритма: {0}", resultAlgorithm.Item2);
            if (resultAlgorithm.Item2 != resultGenerator.Item2)
            {
                Output.WriteLine("\nРезультат: Ошибка");
            }
            else
            {
                Output.WriteLine("\nРезультат: Успешно");
            }
        }
    }
}
