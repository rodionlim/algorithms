namespace InsertionSort
{
    class InsertionSort
    // Insertion sort is a simple sorting algorithm that works similar to the way you sort playing cards in your hands. 
    // The array is virtually split into a sorted and an unsorted part. Values from the unsorted part are 
    // picked and placed at the correct position in the sorted part.
    {
        public int[] sort(int[] array)
        {
            for (int i = 1; i < array.Length; i++)
            {
                int key = array[i];
                for (int j = i - 1; j >= 0; j--)
                {
                    if (key < array[j])
                    {
                        array[j + 1] = array[j];
                        array[j] = key;
                    }
                    else
                        break;
                }
            }
            return array;
        }
    }
}
