using System;

namespace Lab9
{
    public class Student : IComparable, ICloneable
    {
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string Patronymic { get; set; }
        public string GroupNumber { get; set; }
        public int[] Grades { get; set; }

        public bool IsSuccessful => Grades[0] >= 4 && Grades[1] >= 4 && Grades[2] >= 4;

        public int CompareTo(object obj)
        {
            if (obj == null) return 1;
            Student other = obj as Student;
            return string.Compare(this.LastName, other.LastName);
        }

        public object Clone()
        {
            return new Student
            {
                LastName = this.LastName,
                FirstName = this.FirstName,
                GroupNumber = this.GroupNumber,
                Grades = (int[])this.Grades.Clone()
            };
        }

        public override string ToString() => $"{LastName} {FirstName}, Гр: {GroupNumber}";
    }
}
