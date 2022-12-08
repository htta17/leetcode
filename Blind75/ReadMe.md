https://leetcode.com/discuss/general-discussion/460599/blind-75-leetcode-questions

<details>
  <summary>https://leetcode.com/problems/product-of-array-except-self/
  </summary>
  
  You are given an array of strings words. Each element of words consists of two lowercase English letters.

Create the longest possible palindrome by selecting some elements from words and concatenating them in any order. Each element can be selected at most once.

Return the length of the longest palindrome that you can create. If it is impossible to create any palindrome, return 0.

A palindrome is a string that reads the same forward and backward.
  
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
