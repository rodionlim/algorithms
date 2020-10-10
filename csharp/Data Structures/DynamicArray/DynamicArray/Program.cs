using System;

namespace DynamicArray
{
    class Program
    {
        static void Main(string[] args)
        {
            var array = new DynamicArray(3);
            array.Insert(1);
            array.Insert(5);
            array.Insert(7);
            array.Insert(10);
            array.Delete(1);
            array.Print();
            Console.WriteLine(array.IndexOf(13));
        }
    }
}
