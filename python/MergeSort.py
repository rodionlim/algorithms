# Like QuickSort, Merge Sort is a Divide and Conquer algorithm. 
# It divides input array in two halves, calls itself for the two halves and then merges the two sorted halves. 
# The merge() function is used for merging two halves. The merge(arr, l, m, r) is key process that assumes that 
# arr[l..m] and arr[m+1..r] are sorted and merges the two sorted sub-arrays into one. 

def mergeSort(array):
    l = len(array)
    lArray = rArray = []

    if l > 1:
        lArray = array[: l // 2]
        rArray = array[l // 2 :]

        lArray = mergeSort(lArray)
        rArray = mergeSort(rArray)
    else:
        return array

    tmpArray = []
    i = j = 0

    for k in range(len(lArray) + len(rArray)):

        if j == len(rArray):
            return [*tmpArray, *lArray[i:]]
        elif i == len(lArray):
            return [*tmpArray, *rArray[j:]]

        if rArray[j] < lArray[i]:
            tmpArray.append(rArray[j])
            j += 1
        else:
            tmpArray.append(lArray[i])
            i += 1
    return tmpArray


mergeSort([5, 3, 1])
