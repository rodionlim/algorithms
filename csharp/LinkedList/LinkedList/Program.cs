using System;

namespace LinkedList
{
    class Program
    {
        static void Main(string[] args)
        {
            var linkedList = new LinkedList();
            Console.WriteLine($"Initial Size: {linkedList.Size()}");

            linkedList.AddFirst(15);
            linkedList.AddFirst(10);
            linkedList.AddFirst(5);
            linkedList.AddLast(20);
            linkedList.DeleteLast();

            Console.WriteLine();
            Console.WriteLine($"Contains? {linkedList.Contains(15)}");
            Console.WriteLine($"Contains? {linkedList.Contains(16)}");
            Console.WriteLine($"IndexOf? {linkedList.IndexOf(15)}");
            Console.WriteLine($"IndexOf? {linkedList.IndexOf(16)}");
            Console.WriteLine($"Final Size: {linkedList.Size()}");
            Console.WriteLine($"To Array: {string.Join(",", linkedList.ToArray())}");
            Console.WriteLine();


            Console.WriteLine("Printing Array: ");
            linkedList.Print();
            
            linkedList.Reverse();
            Console.WriteLine();

            Console.WriteLine("Printing Array after reversing: ");
            linkedList.Print();
        }
    }
}
