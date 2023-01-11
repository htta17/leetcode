<details>
  <summary>https://leetcode.com/problems/longest-palindrome-by-concatenating-two-letter-words/description/
  </summary>
  
  You are given an array of strings words. Each element of words consists of two lowercase English letters.

Create the longest possible palindrome by selecting some elements from words and concatenating them in any order. Each element can be selected at most once.

Return the length of the longest palindrome that you can create. If it is impossible to create any palindrome, return 0.

A palindrome is a string that reads the same forward and backward.
  
  ```cs
  public int LongestPalindrome(string[] words) {
      //dictionary to store: 
      //  - Item1: This word can be in middle or not. Same character can be in middle, ex: 'aa', 'bb'. 'ab' or 'yz' cannot. 
      //  - Item2: The frequence of a word
      //  - Item3: The frequence of a REVERSED word
      //If a dic["te"] has value like (false, 3, 4) means 'te' appeared 3 times, and 'et' appeared 4 times
      //We can use 'tetete' and 'etetet' 
      var dic = new Dictionary<string, (bool, int, int)>();
      foreach(var word in words) {
          if (word[0] == word[1]) { //Can put anywhere
              dic[word] = (true, dic.ContainsKey(word) ? dic[word].Item2 + 1 : 1, 0);
          }
          else {
              var reverse = word[1].ToString() + word[0].ToString();
              if (dic.ContainsKey(word)) {
                  dic[word] = (false, dic[word].Item2 + 1, dic[word].Item3);
              }
              else if (dic.ContainsKey(reverse)) {
                  dic[reverse] = (false, dic[reverse].Item2 , dic[reverse].Item3 + 1);
              }
              else {
                  dic[word] = (false,1, 0);
              }
          }
      } 

      var pairs = 0;
      var middle = 0; 
      foreach(var item in dic) {
          if (item.Value.Item1) {
              if (item.Value.Item2 % 2 == 0) {
                  pairs += item.Value.Item2; //Use all 
              }
              else {
                  pairs += item.Value.Item2 - 1;// If 'aa' appear 5 times --> Use 4 pairs and middle
                  middle = 1;
              }
          } else {
              var min = Math.Min(item.Value.Item2, item.Value.Item3);
              pairs += min * 2;
          }
      }

      return (pairs + middle) * 2;

  }
  ```


</details>

<details>
  <summary>Reverse Words in a String II https://leetcode.com/explore/interview/card/microsoft/30/array-and-strings/213/
  </summary>
  
  ```cs
  public void ReverseWords(char[] s) {
      //Reverse whole array 
      for (int i=0; i< s.Length/2; i++) {
          var t = s[i]; 
          s[i] = s[s.Length - 1 - i];
          s[s.Length - 1 - i] = t;            
      }

      //Reverse each word
      int left = 0, right = 0; 
      while (right <= s.Length) {            
          if (right == s.Length || s[right] == ' ') {
              var mid = (right - left) /2;                
              for (int i=0; i< mid ; i++) {
                  var t = s[left + i]; 
                  s[left + i] = s[right - 1 - i]; 
                  s[right - 1 - i] = t;                    
              }
              left = right + 1; 
              right = left;
          }
          else {
              right++;
          }
      }
  }
  ```
  
 </details>


<details>
  <summary>https://leetcode.com/problems/first-missing-positive/description/
  </summary>

Given an unsorted integer array nums, return the smallest missing positive integer.

You must implement an algorithm that runs in O(n) time and uses constant extra space.

```cs
public int FirstMissingPositive(int[] nums) {
    //Concept: There is N numbers, 
    //The smallest missing number must be from 1 to N + 1
    //No larger than N + 1
    var N = nums.Length; 
    var marked = new bool[nums.Length + 2]; //0 --> N + 1 --> N + 2 items 
    var curr = 1; 
    for(var i=0; i< nums.Length; i++) {
        if (nums[i] <= 0    //Negative number 
            || nums[i] > N + 1   //Ignore  
            || marked[nums[i]]   ) { //Duplicated           
            continue;
        }
        else {
            marked[nums[i]] = true; 
            if (nums[i] == curr) {
                while (marked[curr]) {
                    curr++;
                }
            }                
        }
    }
    return curr;
}
```
  
</details>

<details>
  <summary>Subarray Sum Equals K https://leetcode.com/explore/interview/card/bloomberg/68/array-and-strings/2924/</summary>
  
  Given an array of integers <code>nums</code> and an integer <code>k</code>, return the total number of subarrays whose sum equals to <code>k</code>.

  A subarray is a contiguous non-empty sequence of elements within an array.

  ```cs
  public int SubarraySum(int[] nums, int k) {
        /*O (n^2) for time, O(1) for space*/
        /*
        var count = 0; 
        for (int i=0; i< nums.Length; i++) {
            var sum =0; 
            for (int j=i; j< nums.Length; j++) {
                sum += nums[j];                
                if (sum == k) {
                    count++;
                }
            }            
        }
        return count;
        */
        
        /*Best way*/
        /*O(n) for time, O(n) for space*/
        var dic = new Dictionary<int,int>();//store sum & count
        dic[0] = 1; //Set value
        var count =0;
        var sum = 0;
        for (int i=0; i< nums.Length; i++) {
            sum += nums[i];            
            if (dic.ContainsKey(sum - k)) {
                count += dic[sum -k];
            }            
            dic[sum] = dic.ContainsKey(sum) ? dic[sum] + 1 : 1; 
        }
        return count;
    }
    ```
  
</details>  
