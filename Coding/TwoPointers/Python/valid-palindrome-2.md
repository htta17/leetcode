Problem: Write a function that takes a string as input and checks whether it can be a valid palindrome by removing at most one character from it.

https://www.educative.io/courses/grokking-coding-interview-patterns-python/YVPpWzRQpEn

https://www.youtube.com/watch?v=JrxRYBwG6EI&ab_channel=NeetCode

```Py
def is_palindrome(s):
  
  l = 0
  r = len(s) - 1
  while  l < r:
    if s[l] != s[r]:
      #python exclude the right most index when slicing so needs to add 1 to 
      #right index to return the correct position of r
      skipL = s[l+1:r+1]
      skipR = s[l:r]
      return (skipL == skipL[::-1] or skipR == skipR[::-1])
    l += 1
    r -= 1

  return True
  ```
