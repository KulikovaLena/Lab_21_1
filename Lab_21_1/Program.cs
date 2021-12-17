using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Lab_21_1
{
    class Program
    {
        static int[,] pole;
        static object locker = new object();
        static void sadovnik1()
        {
            lock(locker)
            {
                for (int i = 0; i < 4; i++)
                {
                    for (int j = 0; j < 4; j++)
                    {
                        if (pole[i, j] == 0)
                            pole[i, j] = 1;
                        Thread.Sleep(1);
                    }
                }
            }
        }
        static void sadovnik2()
        {
            for (int i = 3; i > 0; i--)
            {
                for (int j = 3; j >= 0; j--)
                {
                    if (pole[j, i] == 0)
                        pole[j, i] = 2;
                    Thread.Sleep(1);
                }
            }
        }
        static void Main(string[] args)
        {
            pole = new int[4, 4];
            ThreadStart threadStart = new ThreadStart(sadovnik1);
            Thread thread = new Thread(threadStart);
            thread.Start();
            sadovnik2();

            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    Console.Write(pole[i, j]);
                }
                Console.WriteLine();
            }
            Console.ReadLine();
        }
    }
}
