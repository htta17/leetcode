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
  <summary>First Missing Positive https://leetcode.com/problems/first-missing-positive/description/
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


<details>
<summary>Longest Substring with At Most Two Distinct Characters https://leetcode.com/explore/interview/card/google/59/array-and-strings/3054/</summary>

Given a string s, return the length of the longest substring that contains at most two distinct characters.

```cs
public int LengthOfLongestSubstringTwoDistinct(string s) {
    int ans =0, left = 0, right =0;
    var dic = new Dictionary<char, int>(); //Save last character position
                                            //make sure dic always contains 2 items
                                            //If there is a new characters, try to remove item 
                                            //with smaller value
    while (right < s.Length) {
        var c = s[right];             
        if (!dic.ContainsKey(c) && dic.Count >= 2) { 
            var keys = dic.Keys.ToList();
            var removedKey = dic[keys[0]] < dic[keys[1]] ? keys[0] : keys[1];
            left = dic[removedKey] + 1; 
            dic.Remove(removedKey);                    
        }
        dic[c] = right;
        ans = Math.Max(ans, right - left + 1);            
        right++;
    }        
    return ans;
}
```
</details>
  
<details>
  <summary>  Missing Ranges: https://leetcode.com/explore/interview/card/google/59/array-and-strings/3055/</summary>
  
  ```cs
  string Range(int left, int right) {
        if (left < right) 
            return $"{left}->{right}";
        else if (left == right)
            return $"{left}";
        else 
            return "";
    }
    public IList<string> FindMissingRanges(int[] nums, int lower, int upper) {
        var ans = new List<string>();         
        if (nums.Length == 0) {
            var s1 = Range(lower, upper);
            if (s1 != "")
                ans.Add(s1);
            return ans;
        }        
        //Add from lower to nums[0]
        var s = Range(lower, nums[0] - 1);
        if (s != "")
            ans.Add(s);        
        //Add from nums[0] to nums[ n - 1]
        for (int i=0; i< nums.Length - 1; i++) {
            s = Range(nums[i] + 1, nums[i +1] - 1);
            if (s != "")
                ans.Add(s);
        }        
        //Add from nums[n-1] to upper
        s = Range(nums[nums.Length - 1] + 1, upper);
        if (s != "")
                ans.Add(s);
        return ans; 
    }
  ```
</details>

  
  <details>
    <summary>Valid Parentheses: https://leetcode.com/explore/interview/card/google/59/array-and-strings/467/ </summary>
    
    
```cs
public bool IsValid(string s) {
    //Time: O(n). 
    //Space: O(n)
    var stack = new Stack<char>(); 
    foreach(var c in s) {
        if (c == '(' || c == '[' || c == '{') {
            stack.Push(c);
        }
        else { //Close } ) ]
            if (stack.Count == 0) {
                return false; 
            }
            else {
                var open = stack.Pop();
                if ((open == '[' && c != ']') || (open == '{' && c != '}') 
                    || (open == '(' && c != ')'))                      
                    return false;
            }
        }
    }
    return stack.Count == 0;
}
```
  </details>
    
    
<details>
  <summary>Maximize Distance to Closest Person: https://leetcode.com/explore/interview/card/google/59/array-and-strings/3058/</summary>
  
  
```cs
public int MaxDistToClosest(int[] seats) {
    //Find the max distance betwwen 2 existing persons
    //The distant between Alex to close person is = maxDistance / 2
    //For example: Distant is 5 --> max = 2
    //And need to take the left or right as well 
    // Something like this: 0 0 0 1 0 0 --> solve below
    var max = 0;        
    int left = 0;
    while (left < seats.Length && seats[left] == 0) {
        left++;
    }        
    max = Math.Max(max, left);
    //// Something like this: 0 1 0 0 0 0--> solve below
    int right = seats.Length - 1; 
    while (right >=0 && seats[right] == 0) {
        right--; 
    }
    max = Math.Max(max, seats.Length - right -1);      
    //Find the max between 2 nearest 1
    var index = left + 1;
    while (index < right) {
        index = left + 1;              
        while (seats[index] == 0) 
            index++;
        max = Math.Max(max, (index - left) / 2);            
        left = index;            
    }        
    return max;
}
```
</details>


<details>
<summary>Next Closest Time: https://leetcode.com/explore/interview/card/google/59/array-and-strings/471/</summary>

```cs
public string NextClosestTime(string time) {
        var values = time.Split(':');
        var currentHour = int.Parse(values[0]);
        var currentTime = int.Parse(values[1]);
        var posChar = new char[4] {values[0][0], values[0][1], values[1][0], values[1][1]}; 
        var set = new HashSet<int>(); 
        //All possible value 
        for (int i=0; i<4; i++) {
            for (int j =0; j<4; j++) {
                var val = (posChar[i] - '0') * 10 + posChar[j] - '0'; 
                set.Add(val);
            }
        }
        
        //Order: minTime < ... (Other values) < currentTime < greaterCurrentMin < ... (Other values) < 59
        var minTime = 60;  
        var greaterCurrentMin = 60; 
        
        //Order: minHour < ... (Other values) < currentHour < greaterCurrentHour < ... (Other values) < 24
        var minHour = 24; 
        var greaterCurrentHour = 24; 
        
        foreach(var item in set) {     
            if (item < 60) {
                minTime = Math.Min(minTime, item);
                if (item > currentTime && greaterCurrentMin > item) {
                    greaterCurrentMin = item;
                }
            }
            if (item < 24) {
                minHour = Math.Min(minHour, item);
                if (item > currentHour && greaterCurrentHour > item) {
                    greaterCurrentHour = item;
                }
            }
        }
        
        return string.Format("{0:d2}:{1:d2}", 
                                greaterCurrentMin < 60 ? currentHour 
                                : greaterCurrentHour < 24 ? greaterCurrentHour 
                                : minHour, 
                                greaterCurrentMin < 60 ? greaterCurrentMin : minTime);
    }
```

</details>
  
  <details>
    <summary>Expressive Words: https://leetcode.com/explore/interview/card/google/59/array-and-strings/3056/</summary>
    
```cs
  public class Solution {
    bool Compare(string s, string word) {
        int index_S = 0;
        int index_W = 0;         
        while (index_S  < s.Length && index_W  < word.Length) {
            if (s[index_S] != word[index_W]) //Different character
                return false;             
            var countS = 1;
            while (index_S + 1 < s.Length && s[index_S] == s[index_S + 1]) {
                index_S++; 
                countS++;
            }            
            var countW = 1;
            while (index_W + 1 < word.Length && word[index_W] == word[index_W + 1]) {
                index_W++; 
                countW++; 
            }
            //2 cases cannot be converted: 
            //s=hello (2 L) and word = helo (1 L), 1 L cannot repeat to 2 L
            //s=hello (2 L) and word = helllo (2 L) 
            if ((countS == 2 && countW == 1) || (countS < countW)) {
                return false;
            }            
            //Increase as regular
            index_S++; 
            index_W++;            
        }
        return (index_S  == s.Length && index_W  == word.Length); //One of those not finish           
    }
    public int ExpressiveWords(string s, string[] words) {        
        var ans = 0; 
        foreach(var word in words) 
            if (Compare(s, word)) ans ++;
        return ans;       
    }
}
```
  </details>
    
    
<details>
  <summary>Container With Most Water: https://leetcode.com/explore/interview/card/google/59/array-and-strings/3048/</summary>
  
  ```cs
  public int MaxArea(int[] height) {
        int maxArea = 0;
        //Concept: 
        //The current area = min(height[left], height[right]) * (right - left), 
        //  which left and right 2 "walls" for the water 
        //The area will be bigger than current when min(height[left], height[right]) inscrease.
        int left = 0; 
        int right = height.Length - 1;
        while(left < right) {
            var currentArea = Math.Min(height[left], height[right]) * (right - left);
            maxArea = Math.Max(maxArea, currentArea);            
            if (height[left] < height[right]) {
                left++; 
            }
            else {
                right--;
            }
        }
        return maxArea; 
    }
  ```
</details>
    
    
<details>
  <summary>Find And Replace in String: https://leetcode.com/explore/interview/card/google/59/array-and-strings/3057/</summary>
  
```cs
  public string FindReplaceString(string s, int[] indices, string[] sources, string[] targets) {
        var queue = new PriorityQueue<int, int>();        
        for (int i=0; i< indices.Length; i++) {
            queue.Enqueue(i, indices[i]);
        }        
        string ans = "";
        int indexOfS = 0;         
        for (int i=0; i< indices.Length; i++) {
            var _index = queue.Dequeue(); 
            if (indexOfS < indices[_index]) {
                //Append ans with substring from indexOfS to indices[i] ([indices[i] - indexOfS] characters)
                ans += s.Substring(indexOfS, indices[_index] - indexOfS);
                //Set indexOfS = indices[i]
                indexOfS = indices[_index];
            }            
            if (indexOfS + sources[_index].Length <= s.Length) {
                //Take sources[i].Length characters
                var replacingText = s.Substring(indexOfS, sources[_index].Length); 
                
                if (replacingText == sources[_index]){ //If this text can be replaced
                    ans += targets[_index];       
                }
                else {
                    ans += replacingText;
                }
                //Update indexOfS            
                indexOfS = indexOfS + replacingText.Length;
            }
        }
        //Append the rest of string
        if (indexOfS < s.Length ) {
            ans += s.Substring(indexOfS);
        }
        return ans; 
    }
```
 </details>
  
<details>
  <summary>Multiply Strings: https://leetcode.com/explore/interview/card/google/59/array-and-strings/3051/</summary>
  
```cs
public class Solution {
    public string Multiply(string num1, string num2) {
        if (num1 == "0" || num2 == "0") {
            return "0"; 
        }        
        var result = "0";         
        var zeroAppend = 0;         
        for (int i= num2.Length -1 ; i>=0; i--) {
            var tmp = Multiply(num1, num2[i]);             
            for (int j=0; j<zeroAppend; j++)
                tmp += "0";            
            result = Plus(result, tmp);            
            zeroAppend++; 
        }        
        return result;
    }
    //Multiple a number with a character
    public string Multiply(string num, char c) {        
        var num2 = c - '0';         
        if (num2 == 0) 
            return "0";        
        var memo = 0;         
        var s = "";
        
        for (int len = num.Length - 1; len >=0; len --) {
            var result = (num[len] - '0') * num2 + memo; 
            if (result >= 10) {                
                memo = result / 10; 
                result = result % 10; 
            }
            else {
                memo = 0;
            }            
            s = result.ToString() + s;
        }        
        if (memo > 0) {
            s = memo.ToString() + s;
        }
        return s; 
    }
    
    string Plus(string num1, string num2) {   
        while (num1.Length < num2.Length)  num1 = "0" + num1;
        while (num2.Length < num1.Length)  num2 = "0" + num2;
        var memo = 0;         
        string s = "";        
        for (int i=num1.Length -1; i>=0; i--){
            var sum = (num1[i] - '0') + (num2[i] - '0') + memo; 
            if (sum >=  10) {
                memo = 1; 
                sum = sum - 10; 
            }
            else {
                memo = 0;
            }            
            s = sum.ToString() + s;             
        }        
        if (memo > 0) {
            s = memo.ToString() + s;
        }         
        return s;
    } 
}
```
  
  
</details>
