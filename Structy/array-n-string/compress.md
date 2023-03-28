![image](https://user-images.githubusercontent.com/12803690/228117601-3f7ee5d9-e853-49fe-92ff-6754fa101e4a.png)

**Use two pointers**

```py
def compress(s):
    #insert ! at the end of the string to handle edge case
    s += '!'
    
    result = ''
    
    sliding_pointer = 0
    new_char_pointer = 0
    
    while sliding_pointer < len(s):
      if s[sliding_pointer] == s[new_char_pointer]:
        sliding_pointer += 1
      else:
        num = sliding_pointer - new_char_pointer
        
        if num == 1:
          result += s[new_char_pointer]
        else:
          
          result += str(num) + s[new_char_pointer]
        new_char_pointer = sliding_pointer

    return result
```
n = length of string
Time: O(n)
Space: O(n)
