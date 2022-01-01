using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Task_23
{
    internal class Program
    {
        static byte n;
        static long result = 1;
        static int f = 0;

        static long FactorialRecursion(int n)
        {
            if (n == 1)
            {
                result = 1;
                if (n < f)
                {
                    Console.WriteLine($"Промежуточное значение, вычисленное в рекурсивном методе, равно: {result}");
                    Thread.Sleep(100);
                }
            }
            else
            {
                result = n * FactorialRecursion(n - 1);
                if (n < f)
                {
                    Console.WriteLine($"Промежуточное значение, вычисленное в рекурсивном методе, равно: {result}");
                    Thread.Sleep(100);
                }
            }
            return result;
        }

        static void FactorialCycle(int n)
        {
            long res = 1;
            if (n != 0 && n != 1)
            {
                for (int i = 1; i < n + 1; i++)
                {
                    res *= i;
                    if (i <= n - 1)
                    {
                        Console.WriteLine($"Промежуточное значение, вычисленное в циклическом методе, равно: {res}");
                        Thread.Sleep(200);
                    }
                }
            }
            else res = 1;

            Console.WriteLine($"Факториал числа {n}, вычисленный в циклическом методе, равен: {res}");
        }

        static async void FactorialCycleAsync(int n)
        {
            await Task.Run(() => FactorialCycle(n));
        }

        static async void FactorialRecursionAsync(int n)
        {
            f = n;
            long r = await Task.Run(() => FactorialRecursion(n));
            Console.WriteLine($"Факториал числа {n}, вычисленный в рекурсивном методе, равен: {r}");
        }

        static void Main(string[] args)
        {
            Console.Write("Введите целое положительное число не более 20 для вычисления факториала этого числа: ");
            try
            {
                n = Convert.ToByte(Console.ReadLine());

                if (n > 1)
                {
                    if (n > 20)
                    {
                        Console.WriteLine("Введено число больше 20. Присвоено значение по умолчанию - 20.");
                        n = 20;
                    }
                    Console.WriteLine();
                    FactorialCycleAsync(n);
                    FactorialRecursionAsync(n);
                }
                else
                    Console.WriteLine($"Факториал {n} равен 1");
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }

            Console.ReadKey();
        }
    }
}
