using System;
using System.Collections.Generic;

namespace Dictionary
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(FindFirstNonRepeatCharacter("A Green Apple"));
            Console.WriteLine(FirstRepeatedCharacter("green apple"));

            var dict = new CustomDictionary(10);
            dict.Put(15, "test 1");
            dict.Put(10, "hello");
            dict.Put(5, "test 2");
            dict.Put(5, "Expected string");

            Console.WriteLine(dict.Get(5));

            dict.Remove(10);
            Console.WriteLine(dict.Get(10));
        }

        private static char FirstRepeatedCharacter(string input)
        {
            // Here, a set is more relevant as we do not care about the number of times the char is repeated
            var set = new HashSet<char>();
            foreach (var c in input)
            {
                if (set.Contains(c))
                    return c;
                set.Add(c);
            }
            return Char.MinValue;
        }

        private static char FindFirstNonRepeatCharacter(string input)
        {
            // Here, we use a dictionary to store non repeated characters
            // Then, we iterate the input value to check if they exist in the non repeated dictionary
            var noRepeatDict = new Dictionary<char,bool>();
            var repeatDict = new Dictionary<char, bool>();
            input = input.ToLower();

            if (input.Length == 0) throw new System.InvalidOperationException("Empty string not accepted");

            foreach (var c in input)
            {
                if (c == ' ') continue;
                if (noRepeatDict.ContainsKey(c))
                { 
                    noRepeatDict.Remove(c);
                    repeatDict.Add(c,true);
                }
                else
                    noRepeatDict.Add(c, true);
            }

            foreach (var c in input)
            {
                if (noRepeatDict.ContainsKey(c)) return c;
            }
            return Char.MinValue;
        }
    }
}
