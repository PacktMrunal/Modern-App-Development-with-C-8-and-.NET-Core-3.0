using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Section1Video2
{
    class Program
    {
        async static Task Main(string[] args)
        {
            await foreach (var student in GetStudentsAsync())
            {
                Console.WriteLine($"{student.FirstName} {student.LastName}");
            }
        }

        async static IAsyncEnumerable<Student> GetStudentsAsync()
        {
            var list = new List<Student>()
            {
                new Student() { FirstName = "John", LastName = "Doe", Email = "john.doe@gmail.com", Gpa = 2.98 },
                new Student() { FirstName = "Elizabeth", LastName = "Cooper", Email ="elizabeth@outlook.com", Gpa = 3.5 },
                new Student() { FirstName = "Mike", LastName = "Olson", Email = "mike@gmail.com", Gpa = 3.22 }
            };
            foreach(var student in list)
            {
                await Task.Delay(3000);
                yield return student;
            }
        }
    }
}
