using System;
using System.Collections.Generic;

namespace GradeBook
{
    class Program
    {
        static void Main(string[] args)
        {
            var book = new Book("Vadim Gradebook");
            book.GradeAdded += OnGradeAdded;

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
                try
                {
                    var grade = double.Parse(input);
                    book.AddGrade(grade);
                }
                catch(Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

                var stats = book.GetStatistics();

                Console.WriteLine($"Для книги {book.Name}");
                Console.WriteLine($"Минимальная оценка равна {stats.Low}");
                Console.WriteLine($"Максимальная оценка равна {stats.High}");
                Console.WriteLine($"Средняя оценка равна {stats.Average:N1}");
                Console.WriteLine($"Буквенная средняя оценка равна {stats.Letter}");

            Console.ReadKey();
        }

        static void OnGradeAdded(object sender, EventArgs e)
        {
            Console.WriteLine("Оценка добавлена");
        }

    }
}
