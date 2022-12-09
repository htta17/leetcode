Write a function, compress, that takes in a string as an argument. The function should return a compressed version of the string where consecutive occurrences of the same characters are compressed into the number of occurrences followed by the character. Single character occurrences should not be changed.

'aaa' compresses to '3a'
'cc' compresses to '2c'
't' should remain as 't'
You can assume that the input only contains a

Use two pointers

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
