using System;
using System.Collections.Generic;

namespace GradeBook
{
    class Program
    {
        static void Main(string[] args)
        {
            var book = new Book("Vadim Gradebook");
            book.AddGrade(89.1);
            book.AddGrade(90.5);
            book.AddGrade(77.5);

            var stats = book.GetStatistics();

            Console.WriteLine($"Минимальная оценка равна {stats.Low}");
            Console.WriteLine($"Максимальная оценка равна {stats.High}");
            Console.WriteLine($"Средняя оценка равна {stats.Average:N1}");
            Console.WriteLine($"Буквенная средняя оценка равна {stats.Letter}");

            Console.ReadKey();
        }
    }
}
