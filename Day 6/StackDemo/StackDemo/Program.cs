using System;
using System.Collections.Generic;

namespace Demo_Collection_Stack_Queue
{
    class Program
    {
        static void Main(string[] args)
        {
            // Step 1: Define a stack to hold integer values
            Stack<int> stack = new Stack<int>(); // Stack that can hold integer

            // Step 2: Push some values onto the stack
            // In list we were using Add() method to add values
            stack.Push(10);
            stack.Push(20);
            stack.Push(30);

            // Step 3: Pop a value from the stack and display it
            int poppedValue = stack.Pop();
            Console.WriteLine("Popped Value: " + poppedValue);

            // Step 4: Peek at the top value of the stack without removing it
            int topValue = stack.Peek();
            Console.WriteLine("Top Value: " + topValue);

            // Step 5: Check if the stack contains a specific value
            bool contains20 = stack.Contains(20);
            Console.WriteLine("Stack contains 20: " + contains20);

            // Step 6: Display the current count of items in the stack
            int count = stack.Count; // this is same as other collection classes
            Console.WriteLine("Current Count: " + count);

            // Step 7: Clear the stack of all items
            stack.Clear();
            Console.WriteLine("Stack cleared. Current Count after clearing: " + stack.Count);

            // To keep the console window open
            Console.ReadLine();
        }
    }
}