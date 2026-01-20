using System;
using System.Collections.Generic;
using System.Linq;

namespace DemoLambda
{
    class DemoLambdaProgram
    {
        static void Main(string[] args)
        {
            // With the help of lambda expression we can write it in oneline like:
            Func<int, bool> IsEven = number => number % 2 == 0;

            // IN a collection if we want to implement lambda expression to find a number greater than 10
            List<int> numbers = new List<int> { 3, 5, 81, 45, 32, 15, 70 };

            // displaying elements of the list
            foreach (int number in numbers)
            {
                Console.WriteLine(number);
            }

            int result = numbers.Find(n => n > 10); // lambda expression C# 3.0
            Console.WriteLine("First number greater than 10 using lambda expression: " + result);

            // var is implicit type variable
            var evenNumber = numbers.Where(n => n % 2 == 0);

            Console.WriteLine("here are the list of even number in the house..");
            foreach (var item in evenNumber)
            {
                Console.WriteLine(item);
            }
        }
    }
}