using System;

namespace GradeBook
{
    class Program
    {
        static void Main(string[] args)
        {
            IBook book = new inMemoryBook("Vadim Gradebook");
            book.GradeAdded += delegate
            {
                Console.WriteLine("Оценка добавлена");
            };

            EnterGrades(book);

            var stats = book.GetStatistics();

            Console.WriteLine($"For book {book.Name}");
            Console.WriteLine($"Minimal grade equals {stats.Low}");
            Console.WriteLine($"Maximal grade equals {stats.High}");
            Console.WriteLine($"Average grade equals {stats.Average:N1}");
            Console.WriteLine($"Letter grade equals {stats.Letter}");

            Console.ReadKey();
        }

        private static void EnterGrades(IBook book)
        {
            while (true)
            {
                Console.WriteLine("Enter number or 'q' for exit");
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

    }
}
