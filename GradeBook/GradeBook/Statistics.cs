using System;
using System.Linq;
using System.Collections.Generic;

namespace GradeBook
{
    public class Statistics
    {
        public double Average;
        public double High;
        public double Low;
        public char Letter;
    }

    public class InMemoryBook : Book
    {
        public InMemoryBook(string name) : base(name)
        {
            _grades = new List<double>();
            Name = name;
        }

        public override void AddGrade(double grade)
        {
            switch (grade)
            {
                case <= 100 and >= 0:
                    _grades.Add(grade);
                    GradeAdded?.Invoke(this, EventArgs.Empty);
                    break;
                case < 0:
                    Console.WriteLine("Invalid value! The value must be more than 0!");
                    break;
                case > 100:
                    Console.WriteLine("Invalid value! The value must be not more than 100!");
                    break;
            }
        }

        public override event GradeAddedDelegate GradeAdded;
        public override Statistics GetStatistics()
        {
            var result = new Statistics
            {
                Average = _grades.Average(),
                High = _grades.Max(),
                Low = _grades.Min()
            };

            result.Letter = result.Average switch
            {
                >= 90 => 'A',
                >= 80 => 'B',
                >= 70 => 'C',
                >= 60 => 'D',
                _ => 'F'
            };

            return result;
        }

        private readonly List<double> _grades;
    }
}
