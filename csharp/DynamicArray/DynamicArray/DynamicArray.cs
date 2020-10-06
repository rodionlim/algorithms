using System;
using System.Collections.Generic;
using System.Text;

namespace DynamicArray
{
    class DynamicArray
    {
        private int size;
        private int[] items;
        private int length = 0;
        public DynamicArray(int sizeOfArray) 
        {
            size = sizeOfArray;
            items = new int[sizeOfArray];
        }

        public void Print()
        {
            for (int i=0; i<length; i++) Console.WriteLine(items[i]);
        }


        public void Insert(int item)
        {
            // If the array is full, resize it. Else, insert item into array
            int[] itemsNew;

            if (length == size)
            {
                Console.WriteLine($"Array size has peaked. Resizing array from size {size} to {size*2}");
                itemsNew = new int[size * 2];
                items.CopyTo(itemsNew, 0);
                items = itemsNew;
            }

            items[length] = item;
            Console.WriteLine($"Inserted {item} in index {length}");
            length++;
        }

        public void Delete(int index)
        {
            // Check if index is out of range, else, shift positions of elements after index to the left by 1
            if (index > length-1 || index < 0) throw new System.ArgumentException("Index is invalid");

            Console.WriteLine($"Deleting element at index {index}");
            for (int i = index; i < length-1; i++) items[i] = items[i + 1];
            length--;
        }

        public int IndexOf(int val)
        {
            int i = 0;
            foreach (var item in items)
            { 
                if (item == val) return i;
                i++;
            }
            return -1;
        }
    }
}
