using System;

namespace Heap
{
    class Program
    {
        static void Main(string[] args)
        {
            var heap = new CustomHeap(10);
            heap.Insert(10);
            heap.Insert(5);
            heap.Insert(17);
            heap.Insert(4);
            heap.Insert(22);

            // Ascending Heap Sort via a heap
            var heapSortResults = new int[heap.next];
            int i = heap.next -1;
            while (!heap.IsEmpty()) heapSortResults[i--] = heap.Delete();

            Array.ForEach(heapSortResults, Console.WriteLine);

            // Heapify
            var intArray = new int[] { 5, 3, 8, 4, 1, 2 };
            CustomHeap.Heapify(intArray);

            // K Largest Value
            var heapKLargestValue = new CustomHeap(10);
            foreach (var item in intArray )
                heapKLargestValue.Insert(item);
            Console.WriteLine($"K Largest Value: {heapKLargestValue.KLargestValue(1)}");
        }
    }
}
