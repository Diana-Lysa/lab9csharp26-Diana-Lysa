using System;
using System.Collections.Generic;
using System.IO;

namespace Lab9
{
    public static class Task2
    {
        public static void Run()
        {
            Console.WriteLine("Виконання Завдання 2 ");

            string filePath = "students.txt";

            CreateSampleFile(filePath);

            Queue<Student> otherStudents = new Queue<Student>();

            Console.WriteLine("Результат сортування за один прохід:");

            try
            {
                using (StreamReader sr = new StreamReader(filePath))
                {
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        string[] parts = line.Split(' ');
                        if (parts.Length < 7) continue;

                        Student student = new Student
                        {
                            LastName = parts[0],
                            FirstName = parts[1],
                            Patronymic = parts[2],
                            GroupNumber = parts[3],
                            Grades = new int[] { int.Parse(parts[4]), int.Parse(parts[5]), int.Parse(parts[6]) }
                        };

                        if (student.IsSuccessful)
                        {
                            Console.WriteLine(student.ToString());
                        }
                        else
                        {
                            otherStudents.Enqueue(student);
                        }
                    }
                }

                while (otherStudents.Count > 0)
                {
                    Console.WriteLine(otherStudents.Dequeue().ToString());
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Помилка при роботі з файлом: {ex.Message}");
            }
        }

        private static void CreateSampleFile(string path)
        {
            string[] lines = {
                "Іваненко Іван Іванович КН-21 5 4 5",
                "Петренко Петро Петрович КН-22 3 4 5",
                "Сидоренко Ганна Сергіївна КН-21 5 5 5",
                "Коваленко Олег Ігорович КН-22 2 3 4",
                "Лиса Діана Олександрівна КН-21 5 5 4"
            };
            File.WriteAllLines(path, lines);
        }
    }
}
