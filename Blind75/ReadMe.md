https://leetcode.com/discuss/general-discussion/460599/blind-75-leetcode-questions

<h2>Array</h2>

<details>
  <summary>https://leetcode.com/problems/two-sum/
  </summary>
  
Given an array of integers nums and an integer target, return indices of the two numbers such that they add up to target.

You may assume that each input would have exactly one solution, and you may not use the same element twice.

You can return the answer in any order.
 ```cs
 public int[] TwoSum(int[] nums, int target) {        
      int[] ans = new int[2]; 
      var dic = new Dictionary<int, int>();
      for (int i=0; i< nums.Length; i++) {
          if (dic.ContainsKey(target - nums[i])) {
              ans = new int[]{ dic[target - nums[i]], i };
          }
          else {
              if (!dic.ContainsKey(nums[i]))
                  dic.Add(nums[i], i); 
          }
      }        
      return ans;        
  }
 ```
  
</details>

<details>
  <summary>https://leetcode.com/problems/product-of-array-except-self/
  </summary>
  
  Given an integer array <code>nums</code>, return an array answer such that <code>answer[i]</code> <i>is equal to the product of all the elements of</i> <code>nums</code> <i>except</i> <code>nums[i]</code>.

  The product of any prefix or suffix of nums is guaranteed to fit in a <b>32-bit</b> integer.

You must write an algorithm that runs in O(n) time and without using the division operation.
  
  ```cs 
  public int[] ProductExceptSelf(int[] nums) {
      var n = nums.Length;         
      var L = new int[n]; //At i: L[i] = nums[0] * nums[1] * ... * nums[i - 1]
      var R = new int[n]; //At i: R[i] = num[n-1] * nums[n-2]
      var ans = new int[n]; //At i: ans[i] = L[i] * R[i];        
      L[0] = 1; 
      for (int i=1; i< n; i++) {
          L[i] = L[i -1] * nums[i-1]; 
      }        
      R[n-1] = 1; 
      for (int i= n-2; i>=0; i--) {
          R[i] = R[i+1] * nums[i+1];
      }        
      for (int i=0; i< n; i++) {
          ans[i] = R[i] * L[i];
      }        
      return ans;
  }
  ```
  
</details>
