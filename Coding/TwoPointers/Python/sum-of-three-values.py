def find_sum_of_three(nums, target):
   nums.sort()
   for i in range(len(nums)-2):
      low = i+1
      high = len(nums) - 1

      while low < high:
         triple = nums[i] + nums[low] + nums[high] 
         if triple == target:
            return True
         elif triple < target:
            low += 1
         else:
            high -= 1
   return False
