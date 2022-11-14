import re
def reverse_words(sentence):
   sentence = re.sub(' +',' ',sentence.strip())
   sentence = list(sentence)
   str_len = len(sentence)
   
   str_reverse(sentence, 0, len(sentence)-1)

   start = 0
   end =0
   
   while True:
        # Find the start index of each word by detecting spaces.
        while start < len(sentence) and sentence[start] == ' ':
            start += 1

        if start == str_len:
            break

        # Find the end index of the word.
        end = start + 1
        while end < str_len and sentence[end] != ' ':
            end += 1

        # Let's call our helper function to reverse the word in-place.
        str_reverse(sentence, start, end - 1)
        start = end
    
   return ''.join(sentence)
         

def str_reverse(_str, start, end):
   while start < end:
      temp = _str[start]
      _str[start] = _str[end]
      _str[end] = temp
      start += 1
      end -= 1
   

