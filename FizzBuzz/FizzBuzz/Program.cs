using System;

namespace FizzBuzz
{
    class Program
    {
        static void Main(string[] args)
        {
            // nu e necesar sa pui '\n'  ca sa treci la linie noua

            for(int i= 1; i<=100; i++)
            {
                if ((i % 3 == 0) && (i % 5 == 0))
                {
                    Console.WriteLine("\n FizzBuzz");
                }
                else if (i % 3 == 0)
                {
                    Console.WriteLine("\n Fizz");
                }
                else if (i % 5 == 0)
                {
                    Console.WriteLine("\n Buzz");
                }
                else
                {
                    Console.WriteLine("\n " + i);
                }
            }
        }
    }
}
