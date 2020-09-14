namespace InsertionSort
{
    class InsertionSort
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
