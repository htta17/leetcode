Solving using properties of set, not fast and slow pointers

https://www.youtube.com/watch?v=ljz85bxOYJ0&ab_channel=NeetCode

```py

def is_happy_number(n):
    visit = set()
    while n not in visit:
        visit.add(n)
        n = sumofSquares(n)
        if n == 1:
            return True
    return False

def sumofSquares(n):
    result =0

    while n:
        digits = n % 10
        result += digits ** 2
        n //= 10
    return result

```
