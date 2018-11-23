using System;
using System.Collections.Generic;
using JM.LinqFaster;

public class Solver
{
    public int[,] Matrix;

    //public int MaxThread;
    private List<bool> used;

    public int[,] solution;

    public int n;

    private static int T;

    private Stack<(int, bool)> currentPath;

    private int min;
    public static void Main(string[] args)
    {

    }

    public Solver(int[,] arr)
    {
        Matrix = arr;
        n = Matrix.GetLength(0);
        T = n - 1;
        used = LinqFaster.RepeatListF(false, n);
        solution = new int[n, n];

        // пустое решение
        for (var i = 0; i < n; i++)
        for (var j = 0; j < n; j++)
            solution[i, j] = 0;
    }

    public (int[,], int) Solve()
    {
        currentPath = new Stack<(int, bool)>();

        min = int.MaxValue;

        // пока есть ребра
        while (DFS(0, true))
        {
            while (currentPath.Count != 1)
            {
                var to = currentPath.Pop();
                var from = currentPath.Peek();

                if (to.Item2)
                {
                    solution[from.Item1, to.Item1] += min;

                    Matrix[from.Item1, to.Item1] -= min;
                    // чтобы не хранить 2 матрицы
                    Matrix[to.Item1, from.Item1] -= min;
                }
                else
                {
                    solution[to.Item1, from.Item1] -= min;

                    Matrix[from.Item1, to.Item1] += min;
                    // так как берем модуль и храним - значения
                    Matrix[to.Item1, from.Item1] += min;
                }
            }

            //сбрасываем значения
            used = LinqFaster.RepeatListF(false, n);

            currentPath = new Stack<(int, bool)>();

            min = int.MaxValue;
        }

        //По последнему столбцу собираем
        var maxThread = 0;
        for (var i = 0; i < n; i++)
            maxThread += solution[i, n - 1];
        return (solution, maxThread);
    }

    private bool DFS(int index, bool isExistingPath)
    {
        if (used[index])
            return false;

        currentPath.Push((index, isExistingPath));

        //если пришли в конец
        if (index == T)
            return true;

        used[index] = true;

        // идем прямо
        for (var i = 0; i < n; i++)
        {
            if (Matrix[index, i] <= 0 || !DFS(i, true)) continue;

            // минимальный поток по пути
            if (Matrix[index, i] < min)
                min = Matrix[index, i];

            return true;
        }

        //идем по обратным
        for (var i = 0; i < n; i++)
            if (Matrix[index, i] < 0 && DFS(i, false))
            {
                if (Math.Abs(Matrix[index, i]) < min)
                    min = Math.Abs(Matrix[index, i]);
                return true;
            }

        // убираем когда вышли
        currentPath.Pop();

        return false;
    }
}