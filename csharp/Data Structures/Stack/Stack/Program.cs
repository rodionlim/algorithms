using System;
using System.Collections.Generic;
using System.Text;

namespace Stack
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine(ReverseString("abcd"));
            //Console.WriteLine(BalancedExpression("ab{<>}cd"));

            var customStack = new CustomStack(5);

            Console.WriteLine($"IsEmpty?: {customStack.IsEmpty()}");

            customStack.Push(5);
            customStack.Push(10);
            customStack.Push(15);
            Console.WriteLine("Before Pop: ");
            customStack.Print();

            Console.WriteLine($"Pop triggered: {customStack.Pop()}");
            
            Console.WriteLine("After Pop: ");
            customStack.Print();

            Console.WriteLine($"Peek triggered: {customStack.Peek()}");
            Console.WriteLine($"IsEmpty?: {customStack.IsEmpty()}");
        }

        private static string ReverseString(string input)
        {
            var stack = new Stack<char>();
            foreach (char c in input)
                stack.Push(c);

            // Here, we choose to use a string builder instead of concatenating strings
            // Strings are immutable and everytime we do a concatenation, a new string has to be created and memory allocated
            StringBuilder output = new StringBuilder();
            while (stack.Count > 0)
                output.Append(stack.Pop());

            return output.ToString();
        }

        private static bool BalancedExpression(string input)
        {
            var stack = new Stack<char>();
            var open = "([<{";
            var close = ")]>}";

            foreach (var c in input)
            {
                if (open.Contains(c))
                    stack.Push(c);
                else if (close.Contains(c))
                {
                    if (stack.Count == 0) return false;

                    var idx = close.IndexOf(c);
                    if (stack.Pop() != open[idx]) return false;
                }
            }

            return (stack.Count > 0) ? false : true;
        }
    }
}
