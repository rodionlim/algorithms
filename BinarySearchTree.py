from BinaryTree import Node

# Driver program to test the binary tree functions
# Let us create the following BST
#    8
#  /   \
# 3    10
# / \ / \
# 1 6 60 80
#  / \    \
# 4   7   14
#         /
#        13
bTree = Node(8)
bTree.left = Node(3)
bTree.right = Node(10)
bTree.left.left = Node(1)
bTree.left.right = Node(6)
bTree.left.right.left = Node(4)
bTree.left.right.right = Node(7)
bTree.right.right = Node(14)
bTree.right.right.left = Node(13)


def search(root, key, traverse=False):
    if traverse:
        print(root.val)
    if root == None:
        return root
    if root.val == key:
        return root
    elif key < root.val:
        return search(root.left, key, traverse)
    else:
        return search(root.right, key, traverse)


search(bTree, 13)  # Binary search
path = search(bTree, 7, True)  # Print out the path traversed
