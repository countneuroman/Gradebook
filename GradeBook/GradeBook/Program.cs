using System;
using System.Collections.Generic;

namespace GradeBook
{
    class Program
    {
        static void Main(string[] args)
        {
            var book = new InMemoryBook("Vadim Gradebook");
            book.GradeAdded += OnGradeAdded;

            EnterGrades(book);

            var stats = book.GetStatistics();

            Console.WriteLine($"Для книги {book.Name}");
            Console.WriteLine($"Минимальная оценка равна {stats.Low}");
            Console.WriteLine($"Максимальная оценка равна {stats.High}");
            Console.WriteLine($"Средняя оценка равна {stats.Average:N1}");
            Console.WriteLine($"Буквенная средняя оценка равна {stats.Letter}");

            Console.ReadKey();
        }

        private static void EnterGrades(InMemoryBook book)
        {
            while (true)
            {
                Console.WriteLine("Введи число или 'q' для выхода");
                var input = Console.ReadLine();

                if (input == "q")
                {
                    break;
                }
                try
                {
                    var grade = double.Parse(input);
                    book.AddGrade(grade);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

        }

        static void OnGradeAdded(object sender, EventArgs e)
        {
            Console.WriteLine("Оценка добавлена");
        }

    }
}
