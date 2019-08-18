using System;
using System.Collections.Generic;

namespace GradeBook
{
    class Program
    {
        static void Main(string[] args)
        {
            var book = new Book("Vadim Gradebook");

            var done = false;

            while (!done)
            {
                Console.WriteLine("Введи число или 'q' для выхода");
                var input = Console.ReadLine();

                if (input == "q")
                {
                    done = true;
                    continue;
                }
                var grade = double.Parse(input);
                book.AddGrade(grade);
            }

                var stats = book.GetStatistics();

                Console.WriteLine($"Минимальная оценка равна {stats.Low}");
                Console.WriteLine($"Максимальная оценка равна {stats.High}");
                Console.WriteLine($"Средняя оценка равна {stats.Average:N1}");
                Console.WriteLine($"Буквенная средняя оценка равна {stats.Letter}");

            Console.ReadKey();
        }
    }
}
