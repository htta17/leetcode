![image](https://user-images.githubusercontent.com/12803690/228718348-f3425fc9-8156-4de7-8ed4-17fa9234922d.png)
**solution**
**using two pointers**
```
def five_sort(nums):
 i = 0
 j = len(nums) - 1
 while i < j:
  if nums[j] == 5:
   j -= 1
  elif nums[i] == 5:
   nums[i], nums[j] = nums[j], nums[i]
   i += 1
  else:
   i += 1
 return nums
```
n = array size
Time: O(n)
Space: O(1)
