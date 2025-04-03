// Есть "сервер" в виде статического класса.
// У него есть переменная count (тип int) и два метода, которые позволяют эту
// переменную читать и писать: GetCount() и AddToCount(int value).
// К классу–"серверу" параллельно обращаются множество клиентов, которые в основном
// читают, но некоторые добавляют значение к count.
// Нужно реализовать статический класс с методами GetCount / AddToCount так,
// чтобы:
//  читатели могли читать параллельно, не блокируя друг друга;
//  писатели писали только последовательно и никогда одновременно;
//  пока писатели добавляют и пишут, читатели должны ждать окончания записи.


using System;
using System.Collections.Generic;
using System.Threading;

namespace Server
{
    class Program
    {
        private static void MyEventHandler(object sender, EventArgs e)
        {
            Console.WriteLine("Начало хэндлера");
            Thread.Sleep(5000);
            Console.WriteLine("Конец хэндлера");
        }


        static void Main(string[] args)
        {
            Console.WriteLine("Выберите задачу: \n(1) - запуск записи/чтения на \"сервере\"");
            int number = Int32.Parse(Console.ReadLine());
            switch (number)
            {
                case 1: Task1(); break;
                
                default: Console.WriteLine("Такого задания нет!"); break;
            }
        }

       


        private static void Task1()
        {
            Thread thread1 = new Thread(() =>
            {
                for (int i = 0; i < 20; i++)
                {
                    ReadFromServer(1);
                }
            });

            Thread thread2 = new Thread(() =>
            {
                for (int i = 0; i < 20; i++)
                {
                    ReadFromServer(2);
                }
            });

            Thread thread3 = new Thread(() =>
            {
                for (int i = 0; i < 10; i++)
                {
                    Thread.Sleep(10000);
                    int count = new Random().Next(1, 100);
                    WriteFromServer(1, count);
                }
            });

            thread1.Start();
            thread2.Start();
            thread3.Start();
        }

        private static void ReadFromServer(int ThreadNumber)
        {
            Thread.Sleep(2000); //Имитация частоты запроса
            Console.WriteLine(DateTime.Now.ToString("H:mm:ss") + " | " + "Читатель " + ThreadNumber + " пытается получить значение значение...");
            int s = Server.GetCount();
            Console.WriteLine(DateTime.Now.ToString("H:mm:ss") + " | " + "Читатель " + ThreadNumber + " получил значение: " + "\"" + s + "\"");
        }

        private static void WriteFromServer(int ThreadNumber, int count)
        {
            Console.WriteLine(DateTime.Now.ToString("H:mm:ss") + " | " + "Писатель " + ThreadNumber + " записывает новое значение: " + "\"" + count + "\"");
            Server.AddToCount(count);
            Console.WriteLine(DateTime.Now.ToString("H:mm:ss") + " | " + "Писатель " + ThreadNumber + " записал новое значение: " + "\"" + count + "\"");

        }
    }
}