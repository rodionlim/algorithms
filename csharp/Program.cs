using System;

class Program
{
    static void Main(string[] args)
    {
        var isort = new InsertionSort.InsertionSort();
        var sorted = isort.sort(new int[] { 5, 3, 1, 2, 77, 89 });

        foreach (var num in sorted)
        {
            Console.WriteLine(num.ToString());
        }
    }
}
