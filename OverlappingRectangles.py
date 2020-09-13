# Given two rectangles, find if the given two rectangles overlap or not.
# Note that a rectangle can be represented by two coordinates, top left and bottom right. So mainly we are given following four coordinates.
# l1: Top Left coordinate of first rectangle.
# r1: Bottom Right coordinate of first rectangle.
# l2: Top Left coordinate of second rectangle.
# r2: Bottom Right coordinate of second rectangle.


class Point:
    def __init__(self, x, y):
        self.x = x
        self.y = y


class Rectangle:
    def __init__(self, pt1, pt2):
        self.pt1 = pt1
        self.pt2 = pt2

    def isOverlappingAnotherRect(self, anotherRect):
        # Check if any of the rectangles are on top of another
        if self.pt1.y <= anotherRect.pt2.y or anotherRect.pt1.y <= self.pt2.y:
            return False

        # Check if any of the rectangles are on the left of another
        if self.pt2.x <= anotherRect.pt1.x or anotherRect.pt2.x <= self.pt1.x:
            return False

        return True


l1 = Point(0, 10)
r1 = Point(10, 0)

l2 = Point(5, 5)
r2 = Point(15, 0)

rect1 = Rectangle(l1, r1)
rect2 = Rectangle(l2, r2)

rect1.isOverlappingAnotherRect(rect2)