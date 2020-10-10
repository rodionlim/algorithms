# Write a program to calculate pow(x,n) using a Divide and Conquer algorithm
# Given two integers x and n, write a function to compute xn. We may assume that x and n are small and overflow doesn’t happen.


def exp(x, n):
    if n == 0:
        return 1

    val = exp(x, n // 2)
    if n % 2 == 1:
        return x * val * val
    else:
        return val * val


exp(5, 200)
