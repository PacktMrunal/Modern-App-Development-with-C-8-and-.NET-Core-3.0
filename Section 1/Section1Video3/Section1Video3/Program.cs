using System;
using System.Text;

namespace Section1Video3
{
    class Program
    {
        static void Main(string[] args)
        {
            testRanges();
        }

        private static void testRanges()
        {
            string[] letters = new string[]
            {
                "A", "B", "C", "D", "E", "F", "G", "H",
                "I", "J", "K", "L", "M", "N", "O", "P",
                "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z"
            };
            StringBuilder builder = new StringBuilder();
            Range range = 1..5;
            Range range2 = 10..^2;
            Range range3 = 10..;
            foreach(var letter in letters[range3])
            {
                builder.Append($"{letter}");
            }
            Console.WriteLine(builder.ToString());
        }
    }
}
