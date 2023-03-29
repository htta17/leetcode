![image](https://user-images.githubusercontent.com/12803690/228415330-963c4cd9-471c-4265-96fa-404ec75102a9.png)

**using a hashmap (dictionary)**
```
def most_frequent_char(s):
  count = {}
  for char in s:
    if char not in count:
      count[char] = 0    
    count[char] += 1
    
  best = None
  for char in s:
    if best is None or count[char] > count[best]:
      best = char
  return best
```
n = length of string
Time: O(n)
Space: O(n)

**using a hashmap (Counter)**
```
from collections import Counter

def most_frequent_char(s):
  count = Counter(s)
  best = None
  for char in s:
    if best is None or count[char] > count[best]:
      best = char
  return best
```
n = length of string
Time: O(n)
Space: O(n)
