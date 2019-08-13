using System;
using System.Collections.Generic;
using System.Text;

namespace GradeBook
{
    class Book
    {
        public void ShowStatistics()
        {
            var amount = 0.0;
            var highGrade = double.MinValue;
            var lowGrade = double.MaxValue;
            foreach (var number in grades)
            {
                highGrade = Math.Max(number, highGrade);
                lowGrade = Math.Min(number, lowGrade);
                amount += number;
            }
            double result = amount / grades.Count;
            Console.WriteLine(highGrade);
            Console.WriteLine(lowGrade);
            Console.WriteLine(result);
        }
        public Book(string name)
        {
            grades = new List<double>();
            this.name = name;
        }
        public void AddGrade(double grade)
        {
            grades.Add(grade);
        }

        private List<double> grades;
        private string name;
    }
}
