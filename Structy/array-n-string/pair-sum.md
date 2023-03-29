![image](https://user-images.githubusercontent.com/12803690/228421548-f9b8c7a4-3f30-4aeb-9385-bb27460f01db.png)
**using a hashmap (dictionary)**
```
def pair_product(numbers, target_product):
  previous_nums = {}
  
  for index, num in enumerate(numbers):
    complement = target_product / num
    
    if complement in previous_nums:
      return (index, previous_nums[complement])
    
    previous_nums[num] = index
```
n = length of numbers list
Time: O(n)
Space: O(n)
