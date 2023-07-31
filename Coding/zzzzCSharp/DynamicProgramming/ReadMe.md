<details> 
  <summary>https://leetcode.com/problems/decode-ways</summary>
  
   ```cs
  public class Solution {
  
    public int NumDecodings(string s) {
        var n = s.Length;        
        var count = new int[n];

        //Init for first count
        //If s[0]=='0' --> No way to get it
        //If s[0]==[1,9] --> 1 way
        count[0] = s[0] == '0' ? 0 : 1; 
        for (int i=1; i<n; i++) {
            var count_i_1 = s[i] == '0' ? 0 : count[i-1]; //If s[i] from [1,9], get count[i-1] 
            var count_i_2 = (s[i-1] == '1' || (s[i-1] == '2' && s[i]>='0' &&s[i] <= '6')) //s[i-1] & s[i] make a number from 10 to 26
                        ? (i==1 ? 1 : count[i-2]) 
                        : 0; 
            count[i] = count_i_1 + count_i_2; 
        }
        return count[n -1];        
    }
}
  ```
</details>

<details> 
  <summary>Word Break https://leetcode.com/problems/word-break </summary>
  
  ```cs
  public class Solution {
    //Concept: Using dynamic programming
    //Assume there is a position J of string s which all characters (from 1) to J are possible. 
    //If we have a way from J to I, so we will have a way from 0 to I    
    HashSet<string> words; //For checking 
    public bool WordBreak(string s, IList<string> wordDict) {
        var n = s.Length;
        words = new HashSet<string>(wordDict);        
        var mark = new bool[n + 1];        
        for (int i=1; i<=n ;i++) {
            mark[i] = words.Contains(s.Substring(0, i));             
            if (!mark[i]) {
                for (int j=1; j<i; j++) {
                    if (mark[j] && (words.Contains(s.Substring(j, i - j)))) {
                        mark[i] = true;
                        break;
                    }
                }  
            }
        }   
        return mark[n];
    }
}
  ```
</details>
<details>
  <summary>Minimum Window Subsequence https://leetcode.com/problems/minimum-window-subsequence/description/ </summary>
  
  We can use dynamic programming <br/>
  Use a memo[len1, len2] with len1 is length of s1 and len2 is the length of s2 <br/>
  <code>memo[i,j] = memo[i-1, j-1] + 1</code> if s1[i] == s2[j] <br/>
  <code>memo[i,j] = memo[i -1, j]</code> if s1[i] != s2[j]
  
 ```cs
  public string MinWindow(string s1, string s2) {
        //Use dynamic programming
        //(i,j): Find match string with s1 from 0--> i and s2 from 0-->j        
        var len1 = s1.Length; 
        var len2 = s2.Length;
        var memo = new int[len1,len2];
        var pos = new int[len1,len2]; //keep position of start 
        for (int i=0; i< len1; i++) {             
            for (int j=0; j< len2; j++) { 
                memo [i,j] = -1; 
                pos[i,j] = -1; 
            }
        } 
        if (s1[0] == s2[0]) {
            memo[0,0] =  1; 
            pos[0,0] = 0;
        }        
        for (int i=1; i< len1; i++) {
            if (s1[i] == s2[0]) {
                memo[i, 0] = 1; 
                pos[i,0] = i; 
            }
            else {
                memo[i, 0] = memo[i-1, 0]; 
                pos[i,0] = pos[i-1, 0];
            }
        }
        for (int i=1; i< len1; i++) {             
            for (int j=1; j< len2; j++) {
                if (s1[i] == s2[j]) {
                    memo[i,j] = memo[i -1, j-1] + 1; 
                    pos[i,j] = pos[i-1, j-1]; 
                }
                else {
                    memo[i,j] = memo[i-1, j ];
                    pos[i,j] = pos[i-1, j]; 
                }
            }
        }       
        var minLen = int.MaxValue;
        var ans = ""; 
        for (int i=0; i< len1; i++) {           
            var left = pos[i, len2 - 1];   
            if (memo[i, len2 -1] == len2 && minLen > i - left) {                
                minLen = i - left; 
                ans = s1.Substring(left, i - left + 1);
            }
        }
        return ans;  
    }
  
 ```
  
  
</details>

<details>
<summary>Maximum Product Subarray https://leetcode.com/explore/interview/card/google/64/dynamic-programming-4/3087/ </summary>


```cs
public int MaxProduct(int[] nums) {
        //If all numbers are positive, we just need to multiple all items
        //If there is a 0, we restart the substring from next position 
        //For negative number, we need to store another sub array with negative number, 
        //      and hope it will flip when see this number        
        int answer = nums[0], minSub = nums[0], maxSub = nums[0];        
        for (int i=1; i< nums.Length; i++) {           
            var currMinSub = minSub; 
            var currMaxSub = maxSub; 
            //Get MIN of 3 values for minSub: nums[i], minSub * nums[i] and maxSub * nums[i]
            //Why we need to compare with nums[i], because 0 will reset 
            minSub = Math.Min(nums[i], Math.Min(currMinSub * nums[i], currMaxSub * nums[i]));             
            //Get MAX of 3 values for maxSub: nums[i], minSub * nums[i] and maxSub * nums[i]
            maxSub = Math.Max(nums[i], Math.Max(currMinSub * nums[i], currMaxSub * nums[i]));   
            //Update answer
            answer = Math.Max(answer, Math.Max(minSub, maxSub));            
        }       
        return answer;   
    }
```
</details>


<details>
<summary>Maximal Square: https://leetcode.com/explore/featured/card/dynamic-programming/631/strategy-for-solving-dp-problems/4046/ </summary>


```cs
public int MaximalSquare(char[][] matrix) {
    var m = matrix.Length; 
    var n = matrix[0].Length;
    int[,] arr = new int[m + 1,n + 1]; 
    var max = 0;        
    for (int i=1; i <= m; i++) {
        for (int j=1; j<=n; j++) {
            if (matrix[i-1][j-1] == '1') {                    
                arr[i,j] = Math.Min(Math.Min(arr[i, j-1], arr[i-1, j-1] ), arr[i-1, j]) + 1;
                max = Math.Max(arr[i,j], max);
            }
        }            
    }        
    return max * max;
}
```
</details>
