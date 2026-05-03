using System;
using System.Collections; 
using System.IO;

namespace Lab9
{
    public static class Task3
    {
        public static void Run()
        {
            Console.WriteLine(" Виконання Завдання 3");

            string filePath = "students.txt";

            if (!File.Exists(filePath))
            {
                string[] defaultData = {
                    "Іваненко Іван Іванович КН-21 5 4 5",
                    "Петренко Петро Петрович КН-22 3 4 5",
                    "Сидоренко Ганна Сергіївна КН-21 5 5 5",
                    "Коваленко Олег Ігорович КН-22 2 3 4",
                    "Лиса Діана Олександрівна КН-21 5 5 4"
                };
                File.WriteAllLines(filePath, defaultData);
            }

            Console.WriteLine("\n[Частина 1: Backspace через ArrayList]");
            string input = "abc#d##c";
            ArrayList list = new ArrayList();

            foreach (char ch in input)
            {
                if (ch == '#')
                {
                    if (list.Count > 0) list.RemoveAt(list.Count - 1);
                }
                else
                {
                    list.Add(ch);
                }
            }
            Console.Write("Результат: ");
            foreach (var item in list) Console.Write(item);
            Console.WriteLine();


            Console.WriteLine("\n[Частина 2: Студенти через ArrayList]");
            ArrayList allStudents = ReadStudentsToArrayList(filePath);

            if (allStudents.Count == 0)
            {
                Console.WriteLine("Дані не знайдені або файл порожній.");
            }
            else
            {
                Console.WriteLine("Спершу успішні, потім інші:");

                foreach (Student s in allStudents)
                {
                    if (s.IsSuccessful) Console.WriteLine($"[Успішний] {s}");
                }

                foreach (Student s in allStudents)
                {
                    if (!s.IsSuccessful) Console.WriteLine($"[Інший] {s}");
                }
            }
        }

        private static ArrayList ReadStudentsToArrayList(string path)
        {
            ArrayList list = new ArrayList();
            if (!File.Exists(path)) return list;

            string[] lines = File.ReadAllLines(path);
            foreach (var line in lines)
            {
                if (string.IsNullOrWhiteSpace(line)) continue;

                string[] p = line.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                 if (p.Length >= 6)
                {
                    try
                    {
                        int n = p.Length;
                        list.Add(new Student
                        {
                            LastName = p[0],
                            FirstName = p[1],
                            Patronymic = n >= 7 ? p[2] : "",
                            GroupNumber = n >= 7 ? p[3] : p[2],
                            Grades = new int[] {
                                int.Parse(p[n - 3]),
                                int.Parse(p[n - 2]),
                                int.Parse(p[n - 1])
                            }
                        });
                    }
                    catch
                    {
                        continue;
                    }
                }
            }
            return list;
        }
    }
}