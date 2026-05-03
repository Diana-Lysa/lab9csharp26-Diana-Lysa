using System;
using System.Text;

namespace Lab9
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.InputEncoding = Encoding.UTF8;

            bool exit = false;

            // Виведемо заголовок лише один раз при запуску
            Console.WriteLine("===============================================");
            Console.WriteLine("    ЛАБОРАТОРНА РОБОТА №9: КОЛЕКЦІЇ В C#");
            Console.WriteLine("    Виконав: Студентка групи (твоя група)");
            Console.WriteLine("===============================================");

            while (!exit)
            {
                // Прибрано Console.Clear(), щоб текст не зникав
                Console.WriteLine("\n--- ГОЛОВНЕ МЕНЮ ---");
                Console.WriteLine("1. Завдання 1 (Stack)");
                Console.WriteLine("2. Завдання 2 (Queue)");
                Console.WriteLine("3. Завдання 3 (ArrayList)");
                Console.WriteLine("4. Завдання 4 (Hashtable)");
                Console.WriteLine("0. Вихід");
                Console.Write("Ваш вибір: ");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        Task1.Run();
                        break;
                    case "2":
                        Task2.Run();
                        break;
                    case "3":
                        Task3.Run();
                        break;
                    case "4":
                        Task4.Run();
                        break;
                    case "0":
                        exit = true;
                        Console.WriteLine("Завершення роботи.");
                        break;
                    default:
                        Console.WriteLine("Помилка! Оберіть пункт від 0 до 4.");
                        break;
                }

            }
        }
    }
}