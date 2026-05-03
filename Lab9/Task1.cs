using System;
using System.Collections.Generic;

namespace Lab9
{
    public static class Task1
    {
        public static void Run()
        {
            Console.WriteLine("Виконання Завдання 1");

            string input = "abc#d##c";
            string result = ProcessBackspace(input);

            Console.WriteLine($"Вхідний рядок: {input}");
            Console.WriteLine($"Результат: {result}");
        }

        private static string ProcessBackspace(string text)
        {
            Stack<char> stack = new Stack<char>();

            foreach (char ch in text)
            {
                if (ch == '#')
                {
                    if (stack.Count > 0) stack.Pop();
                }
                else
                {
                    stack.Push(ch);
                }
            }

            char[] resultArray = stack.ToArray();
            Array.Reverse(resultArray);
            return new string(resultArray);
        }
    }
}