using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace GradeBook
{
    public class Statistics
    {
        public double Average;
        public double High;
        public double Low;
        public char Letter;
    }

    public class inMemoryBook : Book
    {
        public inMemoryBook(string name) : base(name)
        {
            grades = new List<double>();
            Name = name;
        }


        public void AddGrade(char letter)
        {
            switch (letter)
            {
                case 'A':
                    AddGrade(90);
                    break;
                case 'B':
                    AddGrade(80);
                    break;
                case 'C':
                    AddGrade(70);
                    break;
                case 'D':
                    AddGrade(60);
                    break;
                case 'F':
                    AddGrade(50);
                    break;
                default:
                    AddGrade(0);
                    break;
            }
        }

        public override void AddGrade(double grade)
        {
            if (grade <= 100 && grade >= 0)
            {
                grades.Add(grade);
                if (GradeAdded != null)
                {
                    GradeAdded(this, new EventArgs());
                }
            }
            else
            {
                Console.WriteLine("Invalid value!");
            }
        }

        public override event GradeAddedDelegate GradeAdded;
        public override Statistics GetStatistics()
        {
            var result = new Statistics();
            //Используем LINQ для вычисления условий.
            result.Average = grades.Average();
            result.High = grades.Max();
            result.Low = grades.Min();

            switch (result.Average)
            {
                case var d when d >= 90:
                    result.Letter = 'A';
                    break;
                case var d when d >= 80:
                    result.Letter = 'B';
                    break;
                case var d when d >= 70:
                    result.Letter = 'C';
                    break;
                case var d when d >= 60:
                    result.Letter = 'D';
                    break;
                default:
                    result.Letter = 'F';
                    break;
            }

            return result;
        }


        private List<double> grades;
    }
}
