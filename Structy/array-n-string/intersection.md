![image](https://user-images.githubusercontent.com/12803690/228712468-4e6f85a0-4206-4ca4-b7b5-b1347bc9c755.png)
**solutions brute force (timeout)**
```
def intersection(a, b):
  result = []
  for item in b:
    if item in a:
      result.append(item)
  return result
```
n = length of array a, m = length of array b
Time: O(n*m)
Space: O(min(n,m))
using set (pass)
```
def intersection(a, b):
  set_a = set(a)
  return [ item for item in b if item in set_a ]
n = length of array a, m = length of array b
```
Time: O(n+m)
Space: O(n)
