using System;

namespace Section1Video1
{
    class Program
    {
        static void Main(string[] args)
        {
            Student st = new Student()
            {
                FirstName = "John",
                LastName = "Doe"
            };
            Console.WriteLine($"First name: {st.FirstName.ToUpper()}");
        }
    }
}
