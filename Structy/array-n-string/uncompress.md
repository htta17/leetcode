using two pointers
```py
def uncompress(s):
  numbers = '0123456789'
  result = []
  i = 0
  j = 0
  while j < len(s):
    if s[j] in numbers:
      j += 1
    else:      
      num = int(s[i:j])
      result.append(s[j] * num)
      j += 1
      i = j
      
  return ''.join(result)
```

n = number of groups

m = max num found in any group

Time: O(n*m)

Space: O(n*m)

![image](https://user-images.githubusercontent.com/12803690/206103844-c0bc7a94-5b34-4b6d-a69b-6df8882b9f5f.png)
