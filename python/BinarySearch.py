# Given a sorted array arr[] of n elements, write a function to search a given element x in arr[].
# A simple approach is to do linear search.The time complexity of above algorithm is O(n). 
# Another approach to perform the same task is using Binary Search.

# Binary Search: Search a sorted array by repeatedly dividing the search interval in half. 
# Begin with an interval covering the whole array. If the value of the search key is less than the item 
# in the middle of the interval, narrow the interval to the lower half. Otherwise narrow it to the upper half. 
# Repeatedly check until the value is found or the interval is empty.

def binSearch(sortedArray, start, end, element):
    # start is first index
    # end is len of array
    mid = (start + end) // 2
    midVal = sortedArray[mid]

    if element > sortedArray[end - 1] or element < sortedArray[start]:
        return -1

    if midVal == element:
        return mid
    elif element < midVal:
        return binSearch(sortedArray, start, mid, element)
    else:
        return binSearch(sortedArray, mid, end, element)


array = [1, 3, 5, 7, 8, 13, 20]
binSearch(array, 0, len(array), 20)
