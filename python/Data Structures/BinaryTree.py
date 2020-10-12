# Binary Tree: A tree whose elements have at most 2 children is called a binary tree.
# Since each element in a binary tree can have only 2 children, we typically name them the left and right child.


class Node:
    def __init__(self, val):
        self.left = None
        self.right = None
        self.val = val


"""4 becomes left child of 2 
           1 
       /       \ 
      2          3 
    /   \       /  \ 
   4    None  None  None 
  /  \ 
None None"""
root = Node(1)
root.left = Node(2)
root.right = Node(3)
root.left.left = Node(4)
