# Bubble Sort is the simplest sorting algorithm that works by
# repeatedly swapping the adjacent elements if they are in wrong order.


def bubbleSort(array):
    completionStatus = True
    for i in range(len(array) - 1):
        x1 = array[i]
        x2 = array[i + 1]
        if x2 < x1:
            array[i] = x2
            array[i + 1] = x1
            completionStatus = False
    if not completionStatus:
        return bubbleSort(array)
    else:
        return array


bubbleSort([5, 3, 1, 7, 9, 2, 3398, 3397])
