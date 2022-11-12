def find_longest_substring(input_string):
   #use set to track character already passed
   res = 0
   charSet = set()
   #initiating window
   l = 0

   for r in range(len(input_string)):
      while input_string[r] in charSet:
         charSet.remove(input_string[l])
         l += 1
      charSet.add(input_string[r])
      res = max(res, r-l+1)
   return res
