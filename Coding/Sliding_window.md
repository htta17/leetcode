- Given an integer array and a window of size w, find the current maximum value in the window as it slides through the entire array.
```javascript
export function findMaxSlidingWindow(nums, w) {
    // your code will replace this placeholder return statement
    var ans = [];
    var sWindow = []; //sWindow to save index of max and 2nd max of current window (maxLength of sWindow is 2)
    for (var i=0; i< nums.length; i++) {
        //pos: The position for answer 
        var pos = i - w + 1; 
        pos = pos < 0 ? 0 : pos; 
        
        //Remove current pos of sWindow if sWindow keep any position out of windows (pos to i)
        if (sWindow.length == 2 && sWindow[1] < pos) {
            sWindow.length = 1; //Remove sWindows[1]
        }
        if (sWindow.length && sWindow[0] < pos) {
            sWindow = sWindow.slice(1); //Remove sWindow[0], remaining can be empty or have 1 item
        }
        
        if (sWindow.length == 0) {
            sWindow.push(i); 
            ans[pos] = nums[i];
        }
        else {//sWindow.length == 1 || sWindow.length == 2
            if (nums[i] >= nums[sWindow[0]]) {
                //Save sWindows[0]
                sWindow[1] = sWindow[0]; 
                //Push i into sWindows[0]
                sWindow[0] = i; 
            }
            else if (sWindow.length == 1 || (sWindow.length == 2 && nums[i] > sWindow[1])) {
                sWindow[1] = i;
            }
        }
        ans[pos] = nums[sWindow[0]];
    }
    return ans;
}
```

- Best Time to Buy and Sell Stock. <br/>
Given an array where the element at the index i represents the price of a stock on day <code>i</code>, find the maximum profit that you can gain by buying the stock <i><b>once</b></i> and then selling it.


```javascript
export function maxProfit(array) {
    // Your code will replace this placeholder return statement.
    //Concept: 
    //    Assume we buy first stock (min = array[0]), 
    //    Loop from 1--> array.length - 1, 
    //              try to sell it with current price, means profit is (array[i] - min)
    //              meanwhile, we update min if min still greater than array[i]

    var maxProfit = 0 ; 
    var min = array[0]; 
    for (var i=1; i< array.length; i++) {
        if (maxProfit < array[i] - min) 
            maxProfit = array[i] - min;        
        if (min > array[i]) 
            min = array[i];        
    }
    return maxProfit;
}
```
- Given strings <code>str1</code> and <code>str2</code>, find the minimum (contiguous) substring <code>subStr</code> of <code>str1</code>, such that every character of <code>str2</code> appears in <code>subStr</code> in the same order as it is present in <code>str2</code>. <br/>

```cs
//Have not done.
```
- Given two strings s and t of lengths m and n respectively, return the minimum window substring of s such that every character in t (including duplicates) is included in the window. If there is no such substring, return the empty string "".
- https://leetcode.com/problems/minimum-window-substring/description/


```cs
public string MinWindow(string s, string t) {        
        var m = t.Length; //m is for length of t
        var n = s.Length;
        if (m > n)
            return ""; 
        
        var dicT = new Dictionary<char, int>(); 
        for (var i=0; i<m; i++) {
            var c = t[i];
            dicT[c] = dicT.ContainsKey(c) ? dicT[c] + 1 : 1; 
        }
        
        int finalL = 0, minLen = int.MaxValue, left =0, right =0, sameKeyCount =0;
        //sameKeyCount: Check to make sure how many keys in dicT has in dicS

        var dicS = new Dictionary<char, int>();

        while (right < n) {
            var c = s[right];
            dicS[c] = dicS.ContainsKey(c) ? dicS[c] + 1 : 1;
            
            //Check if dicS has character c, and if dicS has the same amount of c as dicT --> Inscrease sameKeyCount
            if (dicT.ContainsKey(c) && dicS[c] == dicT[c])
                sameKeyCount++; 

            while(sameKeyCount == dicT.Count && left <= right) {                
                if (minLen > right - left + 1 ) {
                    minLen =  right - left + 1;
                    finalL = left; 
                }
                //Move left 1 unit to the right, so dicS also remove s[left]
                var removeC = s[left];
                dicS[removeC]--;                 
                if (dicT.ContainsKey(removeC) && dicS[removeC] == dicT[removeC] - 1 ) 
                    sameKeyCount--;                                
                left++;
            }
            right++;            
        }
            
        return minLen == int.MaxValue ? "" : s.Substring(finalL, minLen) ;
    }
```

- Given a string s, find the length of the longest substring without repeating characters.
- https://leetcode.com/problems/longest-substring-without-repeating-characters/description/
```cs
public int LengthOfLongestSubstring(string s) {        
        //Concept: - Use a Dictionary (Hashtable) to keep LAST position of each characters
        //         - Loop for each character 
        //         -       If we have not seen character --> add to seen
        //         -       If we see a character again --> Find the start (of substring) 
        //         -            Why we need change start: "abcba" --> When we see "b", we changed start, so current substring is "cb", then
        //         -           when see "a" again, we don't need to change start
        //         -   
        var seen = new Dictionary<char, int>();
        int ans = 0, start = 0;  
        for (int i=0; i< s.Length; i++) {
            var c = s[i];            
            if (!seen.ContainsKey(c)) {
                ans = Math.Max(ans, i - start + 1);
                seen.Add(c, i);
            } else {
                var lastPos = seen[c]; 
                seen[c] = i;
                start = Math.Max(start, lastPos + 1); 
                ans = Math.Max(ans, i - start + 1);
            }            
        }
        return ans;
    }
```

- https://leetcode.com/problems/max-consecutive-ones/description/
- Given a binary array nums, return the maximum number of consecutive 1's in the array.
```cs
//1st way (Sliding windows)
public int FindMaxConsecutiveOnes(int[] nums) {
    int left =0, right =0, ans = -1; 

    while (right < nums.Length) {
        if (nums[right] == 0) {
            left = right + 1;
        }
        right++;
        ans = Math.Max(ans, right - left);
    }
    return ans;
}

//2 way
public int FindMaxConsecutiveOnes(int[] nums) {
    var max = 0; 
    var current = 0;         
    for (int i=0; i< nums.Length; i++) {
        if (nums[i] == 0) {
            max = Math.Max(max, current);
            current = 0;
        } else {
            current ++; 
        }
    }        
    return Math.Max(max, current);        
}
```

- Given a binary array nums, return the maximum number of consecutive 1's in the array if you can flip at most one 0.
- https://leetcode.com/problems/max-consecutive-ones-ii/description/ 
```cs
public int FindMaxConsecutiveOnes(int[] nums) {
        
        int n = nums.Length,longest = 0, left =0, right =0;         
        var flip_index = -1; //Track the index of flipped number

        while (right < n) {
            //If nums[right] == 1, we keep inscrease 
            if (nums[right] == 0) {               
                if (flip_index == -1) //Have not flipped any 0 yet
                    flip_index = right;
                else {
                    left = flip_index + 1; 
                    flip_index = right; 
                }
            }
            right++; 
            longest = Math.Max(longest, right - left);
        } 
        return longest; 
    }
```
- https://leetcode.com/problems/max-consecutive-ones-iii/description/
- Given a binary array nums and an integer k, return the maximum number of consecutive 1's in the array if you can flip at most k 0's.
- Code was get from https://youtu.be/3BWnIY97JbE
```cs
public int LongestOnes(int[] nums, int k) {
    int left =0, max = 0;
    int countOne = 0; 

    for (int right=0; right< nums.Length; right++) {
        if (nums[right] == 1) {
            countOne++;
        }
        //At position [right], the substring's length is [right - left + 1], and this substring contains 
        //[countOne] number 1, so it contains [right - left + 1 - countOne] number 0
        //Hence, we have to make sure number of 0 less than or equals k
        while (right - left + 1 - countOne > k) {
            if (nums[left] == 1) {
                countOne--;
            }
            left++;
        }
        max = Math.Max(max, right - left + 1);
    }
    return max; 
}
```
- Given an integer array and a window of size w, find the current maximum value in the window as it slides through the entire array.
```javascript
export function findMaxSlidingWindow(nums, w) {
    // your code will replace this placeholder return statement
    var ans = [];
    var sWindow = []; //sWindow to save index of max and 2nd max of current window (maxLength of sWindow is 2)
    for (var i=0; i< nums.length; i++) {
        //pos: The position for answer 
        var pos = i - w + 1; 
        pos = pos < 0 ? 0 : pos; 
        
        //Remove current pos of sWindow if sWindow keep any position out of windows (pos to i)
        if (sWindow.length == 2 && sWindow[1] < pos) {
            sWindow.length = 1; //Remove sWindows[1]
        }
        if (sWindow.length && sWindow[0] < pos) {
            sWindow = sWindow.slice(1); //Remove sWindow[0], remaining can be empty or have 1 item
        }
        
        if (sWindow.length == 0) {
            sWindow.push(i); 
            ans[pos] = nums[i];
        }
        else {//sWindow.length == 1 || sWindow.length == 2
            if (nums[i] >= nums[sWindow[0]]) {
                //Save sWindows[0]
                sWindow[1] = sWindow[0]; 
                //Push i into sWindows[0]
                sWindow[0] = i; 
            }
            else if (sWindow.length == 1 || (sWindow.length == 2 && nums[i] > sWindow[1])) {
                sWindow[1] = i;
            }
        }
        ans[pos] = nums[sWindow[0]];
    }
    return ans;
}
```

- Best Time to Buy and Sell Stock. <br/>
Given an array where the element at the index i represents the price of a stock on day <code>i</code>, find the maximum profit that you can gain by buying the stock <i><b>once</b></i> and then selling it.


```javascript
export function maxProfit(array) {
    // Your code will replace this placeholder return statement.
    //Concept: 
    //    Assume we buy first stock (min = array[0]), 
    //    Loop from 1--> array.length - 1, 
    //              try to sell it with current price, means profit is (array[i] - min)
    //              meanwhile, we update min if min still greater than array[i]

    var maxProfit = 0 ; 
    var min = array[0]; 
    for (var i=1; i< array.length; i++) {
        if (maxProfit < array[i] - min) 
            maxProfit = array[i] - min;        
        if (min > array[i]) 
            min = array[i];        
    }
    return maxProfit;
}
```
- Given strings <code>str1</code> and <code>str2</code>, find the minimum (contiguous) substring <code>subStr</code> of <code>str1</code>, such that every character of <code>str2</code> appears in <code>subStr</code> in the same order as it is present in <code>str2</code>. <br/>

```cs
//Have not done.
```
- Given two strings s and t of lengths m and n respectively, return the minimum window substring of s such that every character in t (including duplicates) is included in the window. If there is no such substring, return the empty string "".
- https://leetcode.com/problems/minimum-window-substring/description/


```cs
public string MinWindow(string s, string t) {        
        var m = t.Length; //m is for length of t
        var n = s.Length;
        if (m > n)
            return ""; 
        
        var dicT = new Dictionary<char, int>(); 
        for (var i=0; i<m; i++) {
            var c = t[i];
            dicT[c] = dicT.ContainsKey(c) ? dicT[c] + 1 : 1; 
        }
        
        int finalL = 0, minLen = int.MaxValue, left =0, right =0, sameKeyCount =0;
        //sameKeyCount: Check to make sure how many keys in dicT has in dicS

        var dicS = new Dictionary<char, int>();

        while (right < n) {
            var c = s[right];
            dicS[c] = dicS.ContainsKey(c) ? dicS[c] + 1 : 1;
            
            //Check if dicS has character c, and if dicS has the same amount of c as dicT --> Inscrease sameKeyCount
            if (dicT.ContainsKey(c) && dicS[c] == dicT[c])
                sameKeyCount++; 

            while(sameKeyCount == dicT.Count && left <= right) {                
                if (minLen > right - left + 1 ) {
                    minLen =  right - left + 1;
                    finalL = left; 
                }
                //Move left 1 unit to the right, so dicS also remove s[left]
                var removeC = s[left];
                dicS[removeC]--;                 
                if (dicT.ContainsKey(removeC) && dicS[removeC] == dicT[removeC] - 1 ) 
                    sameKeyCount--;                                
                left++;
            }
            right++;            
        }
            
        return minLen == int.MaxValue ? "" : s.Substring(finalL, minLen) ;
    }
```

- Given a string s, find the length of the longest substring without repeating characters.
- https://leetcode.com/problems/longest-substring-without-repeating-characters/description/
```cs
public int LengthOfLongestSubstring(string s) {        
        //Concept: - Use a Dictionary (Hashtable) to keep LAST position of each characters
        //         - Loop for each character 
        //         -       If we have not seen character --> add to seen
        //         -       If we see a character again --> Find the start (of substring) 
        //         -            Why we need change start: "abcba" --> When we see "b", we changed start, so current substring is "cb", then
        //         -           when see "a" again, we don't need to change start
        //         -   
        var seen = new Dictionary<char, int>();
        int ans = 0, start = 0;  
        for (int i=0; i< s.Length; i++) {
            var c = s[i];            
            if (!seen.ContainsKey(c)) {
                ans = Math.Max(ans, i - start + 1);
                seen.Add(c, i);
            } else {
                var lastPos = seen[c]; 
                seen[c] = i;
                start = Math.Max(start, lastPos + 1); 
                ans = Math.Max(ans, i - start + 1);
            }            
        }
        return ans;
    }
```

- https://leetcode.com/problems/max-consecutive-ones/description/
- Given a binary array nums, return the maximum number of consecutive 1's in the array.
```cs
//1st way (Sliding windows)
public int FindMaxConsecutiveOnes(int[] nums) {
    int left =0, right =0, ans = -1; 

    while (right < nums.Length) {
        if (nums[right] == 0) {
            left = right + 1;
        }
        right++;
        ans = Math.Max(ans, right - left);
    }
    return ans;
}

//2 way
public int FindMaxConsecutiveOnes(int[] nums) {
    var max = 0; 
    var current = 0;         
    for (int i=0; i< nums.Length; i++) {
        if (nums[i] == 0) {
            max = Math.Max(max, current);
            current = 0;
        } else {
            current ++; 
        }
    }        
    return Math.Max(max, current);        
}
```

- Given a binary array nums, return the maximum number of consecutive 1's in the array if you can flip at most one 0.
- https://leetcode.com/problems/max-consecutive-ones-ii/description/ 
```cs
public int FindMaxConsecutiveOnes(int[] nums) {
        
        int n = nums.Length,longest = 0, left =0, right =0;         
        var flip_index = -1; //Track the index of flipped number

        while (right < n) {
            //If nums[right] == 1, we keep inscrease 
            if (nums[right] == 0) {               
                if (flip_index == -1) //Have not flipped any 0 yet
                    flip_index = right;
                else {
                    left = flip_index + 1; 
                    flip_index = right; 
                }
            }
            right++; 
            longest = Math.Max(longest, right - left);
        } 
        return longest; 
    }
```
- https://leetcode.com/problems/max-consecutive-ones-iii/description/
- Given a binary array nums and an integer k, return the maximum number of consecutive 1's in the array if you can flip at most k 0's.
- Code was get from https://youtu.be/3BWnIY97JbE
```cs
public int LongestOnes(int[] nums, int k) {
    int left =0, max = 0;
    int countOne = 0; 

    for (int right=0; right< nums.Length; right++) {
        if (nums[right] == 1) {
            countOne++;
        }
        //At position [right], the substring's length is [right - left + 1], and this substring contains 
        //[countOne] number 1, so it contains [right - left + 1 - countOne] number 0
        //Hence, we have to make sure number of 0 less than or equals k
        while (right - left + 1 - countOne > k) {
            if (nums[left] == 1) {
                countOne--;
            }
            left++;
        }
        max = Math.Max(max, right - left + 1);
    }
    return max; 
}
```
- Given an integer array and a window of size w, find the current maximum value in the window as it slides through the entire array.
```javascript
export function findMaxSlidingWindow(nums, w) {
    // your code will replace this placeholder return statement
    var ans = [];
    var sWindow = []; //sWindow to save index of max and 2nd max of current window (maxLength of sWindow is 2)
    for (var i=0; i< nums.length; i++) {
        //pos: The position for answer 
        var pos = i - w + 1; 
        pos = pos < 0 ? 0 : pos; 
        
        //Remove current pos of sWindow if sWindow keep any position out of windows (pos to i)
        if (sWindow.length == 2 && sWindow[1] < pos) {
            sWindow.length = 1; //Remove sWindows[1]
        }
        if (sWindow.length && sWindow[0] < pos) {
            sWindow = sWindow.slice(1); //Remove sWindow[0], remaining can be empty or have 1 item
        }
        
        if (sWindow.length == 0) {
            sWindow.push(i); 
            ans[pos] = nums[i];
        }
        else {//sWindow.length == 1 || sWindow.length == 2
            if (nums[i] >= nums[sWindow[0]]) {
                //Save sWindows[0]
                sWindow[1] = sWindow[0]; 
                //Push i into sWindows[0]
                sWindow[0] = i; 
            }
            else if (sWindow.length == 1 || (sWindow.length == 2 && nums[i] > sWindow[1])) {
                sWindow[1] = i;
            }
        }
        ans[pos] = nums[sWindow[0]];
    }
    return ans;
}
```

- Best Time to Buy and Sell Stock. <br/>
Given an array where the element at the index i represents the price of a stock on day <code>i</code>, find the maximum profit that you can gain by buying the stock <i><b>once</b></i> and then selling it.


```javascript
export function maxProfit(array) {
    // Your code will replace this placeholder return statement.
    //Concept: 
    //    Assume we buy first stock (min = array[0]), 
    //    Loop from 1--> array.length - 1, 
    //              try to sell it with current price, means profit is (array[i] - min)
    //              meanwhile, we update min if min still greater than array[i]

    var maxProfit = 0 ; 
    var min = array[0]; 
    for (var i=1; i< array.length; i++) {
        if (maxProfit < array[i] - min) 
            maxProfit = array[i] - min;        
        if (min > array[i]) 
            min = array[i];        
    }
    return maxProfit;
}
```
- Given strings <code>str1</code> and <code>str2</code>, find the minimum (contiguous) substring <code>subStr</code> of <code>str1</code>, such that every character of <code>str2</code> appears in <code>subStr</code> in the same order as it is present in <code>str2</code>. <br/>

```cs
//Have not done.
```
- Given two strings s and t of lengths m and n respectively, return the minimum window substring of s such that every character in t (including duplicates) is included in the window. If there is no such substring, return the empty string "".
- https://leetcode.com/problems/minimum-window-substring/description/


```cs
public string MinWindow(string s, string t) {        
        var m = t.Length; //m is for length of t
        var n = s.Length;
        if (m > n)
            return ""; 
        
        var dicT = new Dictionary<char, int>(); 
        for (var i=0; i<m; i++) {
            var c = t[i];
            dicT[c] = dicT.ContainsKey(c) ? dicT[c] + 1 : 1; 
        }
        
        int finalL = 0, minLen = int.MaxValue, left =0, right =0, sameKeyCount =0;
        //sameKeyCount: Check to make sure how many keys in dicT has in dicS

        var dicS = new Dictionary<char, int>();

        while (right < n) {
            var c = s[right];
            dicS[c] = dicS.ContainsKey(c) ? dicS[c] + 1 : 1;
            
            //Check if dicS has character c, and if dicS has the same amount of c as dicT --> Inscrease sameKeyCount
            if (dicT.ContainsKey(c) && dicS[c] == dicT[c])
                sameKeyCount++; 

            while(sameKeyCount == dicT.Count && left <= right) {                
                if (minLen > right - left + 1 ) {
                    minLen =  right - left + 1;
                    finalL = left; 
                }
                //Move left 1 unit to the right, so dicS also remove s[left]
                var removeC = s[left];
                dicS[removeC]--;                 
                if (dicT.ContainsKey(removeC) && dicS[removeC] == dicT[removeC] - 1 ) 
                    sameKeyCount--;                                
                left++;
            }
            right++;            
        }
            
        return minLen == int.MaxValue ? "" : s.Substring(finalL, minLen) ;
    }
```

- Given a string s, find the length of the longest substring without repeating characters.
- https://leetcode.com/problems/longest-substring-without-repeating-characters/description/
```cs
public int LengthOfLongestSubstring(string s) {        
        //Concept: - Use a Dictionary (Hashtable) to keep LAST position of each characters
        //         - Loop for each character 
        //         -       If we have not seen character --> add to seen
        //         -       If we see a character again --> Find the start (of substring) 
        //         -            Why we need change start: "abcba" --> When we see "b", we changed start, so current substring is "cb", then
        //         -           when see "a" again, we don't need to change start
        //         -   
        var seen = new Dictionary<char, int>();
        int ans = 0, start = 0;  
        for (int i=0; i< s.Length; i++) {
            var c = s[i];            
            if (!seen.ContainsKey(c)) {
                ans = Math.Max(ans, i - start + 1);
                seen.Add(c, i);
            } else {
                var lastPos = seen[c]; 
                seen[c] = i;
                start = Math.Max(start, lastPos + 1); 
                ans = Math.Max(ans, i - start + 1);
            }            
        }
        return ans;
    }
```

- https://leetcode.com/problems/max-consecutive-ones/description/
- Given a binary array nums, return the maximum number of consecutive 1's in the array.
```cs
//1st way (Sliding windows)
public int FindMaxConsecutiveOnes(int[] nums) {
    int left =0, right =0, ans = -1; 

    while (right < nums.Length) {
        if (nums[right] == 0) {
            left = right + 1;
        }
        right++;
        ans = Math.Max(ans, right - left);
    }
    return ans;
}

//2 way
public int FindMaxConsecutiveOnes(int[] nums) {
    var max = 0; 
    var current = 0;         
    for (int i=0; i< nums.Length; i++) {
        if (nums[i] == 0) {
            max = Math.Max(max, current);
            current = 0;
        } else {
            current ++; 
        }
    }        
    return Math.Max(max, current);        
}
```

- Given a binary array nums, return the maximum number of consecutive 1's in the array if you can flip at most one 0.
- https://leetcode.com/problems/max-consecutive-ones-ii/description/ 
```cs
public int FindMaxConsecutiveOnes(int[] nums) {
        
        int n = nums.Length,longest = 0, left =0, right =0;         
        var flip_index = -1; //Track the index of flipped number

        while (right < n) {
            //If nums[right] == 1, we keep inscrease 
            if (nums[right] == 0) {               
                if (flip_index == -1) //Have not flipped any 0 yet
                    flip_index = right;
                else {
                    left = flip_index + 1; 
                    flip_index = right; 
                }
            }
            right++; 
            longest = Math.Max(longest, right - left);
        } 
        return longest; 
    }
```
- https://leetcode.com/problems/max-consecutive-ones-iii/description/
- Given a binary array nums and an integer <span style="color:red">k</span>, return the maximum number of consecutive <span style="color:red">1's</span> in the array if you can flip at most k <span style="color:red">0's</span>.
- Code was get from https://youtu.be/3BWnIY97JbE
```cs
public int LongestOnes(int[] nums, int k) {
    int left =0, max = 0;
    int countOne = 0; 

    for (int right=0; right< nums.Length; right++) {
        if (nums[right] == 1) {
            countOne++;
        }
        //At position [right], the substring's length is [right - left + 1], and this substring contains 
        //[countOne] number 1, so it contains [right - left + 1 - countOne] number 0
        //Hence, we have to make sure number of 0 less than or equals k
        while (right - left + 1 - countOne > k) {
            if (nums[left] == 1) {
                countOne--;
            }
            left++;
        }
        max = Math.Max(max, right - left + 1);
    }
    return max; 
}
```
- Given an integer array and a window of size w, find the current maximum value in the window as it slides through the entire array.
```javascript
export function findMaxSlidingWindow(nums, w) {
    // your code will replace this placeholder return statement
    var ans = [];
    var sWindow = []; //sWindow to save index of max and 2nd max of current window (maxLength of sWindow is 2)
    for (var i=0; i< nums.length; i++) {
        //pos: The position for answer 
        var pos = i - w + 1; 
        pos = pos < 0 ? 0 : pos; 
        
        //Remove current pos of sWindow if sWindow keep any position out of windows (pos to i)
        if (sWindow.length == 2 && sWindow[1] < pos) {
            sWindow.length = 1; //Remove sWindows[1]
        }
        if (sWindow.length && sWindow[0] < pos) {
            sWindow = sWindow.slice(1); //Remove sWindow[0], remaining can be empty or have 1 item
        }
        
        if (sWindow.length == 0) {
            sWindow.push(i); 
            ans[pos] = nums[i];
        }
        else {//sWindow.length == 1 || sWindow.length == 2
            if (nums[i] >= nums[sWindow[0]]) {
                //Save sWindows[0]
                sWindow[1] = sWindow[0]; 
                //Push i into sWindows[0]
                sWindow[0] = i; 
            }
            else if (sWindow.length == 1 || (sWindow.length == 2 && nums[i] > sWindow[1])) {
                sWindow[1] = i;
            }
        }
        ans[pos] = nums[sWindow[0]];
    }
    return ans;
}
```

- Best Time to Buy and Sell Stock. <br/>
Given an array where the element at the index i represents the price of a stock on day <code>i</code>, find the maximum profit that you can gain by buying the stock <i><b>once</b></i> and then selling it.


```javascript
export function maxProfit(array) {
    // Your code will replace this placeholder return statement.
    //Concept: 
    //    Assume we buy first stock (min = array[0]), 
    //    Loop from 1--> array.length - 1, 
    //              try to sell it with current price, means profit is (array[i] - min)
    //              meanwhile, we update min if min still greater than array[i]

    var maxProfit = 0 ; 
    var min = array[0]; 
    for (var i=1; i< array.length; i++) {
        if (maxProfit < array[i] - min) 
            maxProfit = array[i] - min;        
        if (min > array[i]) 
            min = array[i];        
    }
    return maxProfit;
}
```
- Given strings <code>str1</code> and <code>str2</code>, find the minimum (contiguous) substring <code>subStr</code> of <code>str1</code>, such that every character of <code>str2</code> appears in <code>subStr</code> in the same order as it is present in <code>str2</code>. <br/>

```cs
//Have not done.
```
- Given two strings s and t of lengths m and n respectively, return the minimum window substring of s such that every character in t (including duplicates) is included in the window. If there is no such substring, return the empty string "".
- https://leetcode.com/problems/minimum-window-substring/description/


```cs
public string MinWindow(string s, string t) {        
        var m = t.Length; //m is for length of t
        var n = s.Length;
        if (m > n)
            return ""; 
        
        var dicT = new Dictionary<char, int>(); 
        for (var i=0; i<m; i++) {
            var c = t[i];
            dicT[c] = dicT.ContainsKey(c) ? dicT[c] + 1 : 1; 
        }
        
        int finalL = 0, minLen = int.MaxValue, left =0, right =0, sameKeyCount =0;
        //sameKeyCount: Check to make sure how many keys in dicT has in dicS

        var dicS = new Dictionary<char, int>();

        while (right < n) {
            var c = s[right];
            dicS[c] = dicS.ContainsKey(c) ? dicS[c] + 1 : 1;
            
            //Check if dicS has character c, and if dicS has the same amount of c as dicT --> Inscrease sameKeyCount
            if (dicT.ContainsKey(c) && dicS[c] == dicT[c])
                sameKeyCount++; 

            while(sameKeyCount == dicT.Count && left <= right) {                
                if (minLen > right - left + 1 ) {
                    minLen =  right - left + 1;
                    finalL = left; 
                }
                //Move left 1 unit to the right, so dicS also remove s[left]
                var removeC = s[left];
                dicS[removeC]--;                 
                if (dicT.ContainsKey(removeC) && dicS[removeC] == dicT[removeC] - 1 ) 
                    sameKeyCount--;                                
                left++;
            }
            right++;            
        }
            
        return minLen == int.MaxValue ? "" : s.Substring(finalL, minLen) ;
    }
```

- Given a string s, find the length of the longest substring without repeating characters.
- https://leetcode.com/problems/longest-substring-without-repeating-characters/description/
```cs
public int LengthOfLongestSubstring(string s) {        
        //Concept: - Use a Dictionary (Hashtable) to keep LAST position of each characters
        //         - Loop for each character 
        //         -       If we have not seen character --> add to seen
        //         -       If we see a character again --> Find the start (of substring) 
        //         -            Why we need change start: "abcba" --> When we see "b", we changed start, so current substring is "cb", then
        //         -           when see "a" again, we don't need to change start
        //         -   
        var seen = new Dictionary<char, int>();
        int ans = 0, start = 0;  
        for (int i=0; i< s.Length; i++) {
            var c = s[i];            
            if (!seen.ContainsKey(c)) {
                ans = Math.Max(ans, i - start + 1);
                seen.Add(c, i);
            } else {
                var lastPos = seen[c]; 
                seen[c] = i;
                start = Math.Max(start, lastPos + 1); 
                ans = Math.Max(ans, i - start + 1);
            }            
        }
        return ans;
    }
```

- https://leetcode.com/problems/max-consecutive-ones/description/
- Given a binary array nums, return the maximum number of consecutive 1's in the array.
```cs
//1st way (Sliding windows)
public int FindMaxConsecutiveOnes(int[] nums) {
    int left =0, right =0, ans = -1; 

    while (right < nums.Length) {
        if (nums[right] == 0) {
            left = right + 1;
        }
        right++;
        ans = Math.Max(ans, right - left);
    }
    return ans;
}

//2 way
public int FindMaxConsecutiveOnes(int[] nums) {
    var max = 0; 
    var current = 0;         
    for (int i=0; i< nums.Length; i++) {
        if (nums[i] == 0) {
            max = Math.Max(max, current);
            current = 0;
        } else {
            current ++; 
        }
    }        
    return Math.Max(max, current);        
}
```

- Given a binary array nums, return the maximum number of consecutive 1's in the array if you can flip at most one 0.
- https://leetcode.com/problems/max-consecutive-ones-ii/description/ 
```cs
public int FindMaxConsecutiveOnes(int[] nums) {
        
        int n = nums.Length,longest = 0, left =0, right =0;         
        var flip_index = -1; //Track the index of flipped number

        while (right < n) {
            //If nums[right] == 1, we keep inscrease 
            if (nums[right] == 0) {               
                if (flip_index == -1) //Have not flipped any 0 yet
                    flip_index = right;
                else {
                    left = flip_index + 1; 
                    flip_index = right; 
                }
            }
            right++; 
            longest = Math.Max(longest, right - left);
        } 
        return longest; 
    }
```
- https://leetcode.com/problems/max-consecutive-ones-iii/description/
- Given a binary array nums and an integer k, return the maximum number of consecutive 1's in the array if you can flip at most k 0's.
- Code was get from https://youtu.be/3BWnIY97JbE
```cs
public int LongestOnes(int[] nums, int k) {
    int left =0, max = 0;
    int countOne = 0; 

    for (int right=0; right< nums.Length; right++) {
        if (nums[right] == 1) {
            countOne++;
        }
        //At position [right], the substring's length is [right - left + 1], and this substring contains 
        //[countOne] number 1, so it contains [right - left + 1 - countOne] number 0
        //Hence, we have to make sure number of 0 less than or equals k
        while (right - left + 1 - countOne > k) {
            if (nums[left] == 1) {
                countOne--;
            }
            left++;
        }
        max = Math.Max(max, right - left + 1);
    }
    return max; 
}
```
- Given two strings s and t, return true if they are both one edit distance apart, otherwise return false.

A string s is said to be one distance apart from a string t if you can:

- Insert exactly one character into s to get t.<br/>
- Delete exactly one character from s to get t. <br/>
- Replace exactly one character of s with a different character to get t. <br/>
- https://leetcode.com/explore/interview/card/facebook/5/array-and-strings/3015/

```cs
public class Solution {
    public bool IsOneEditDistance(string s, string t) {
        if (s == t)
            return false; 
        
        if (Math.Abs(s.Length - t.Length) > 1)
            return false;
        
        int left_s = -1, left_t = -1, right_s = s.Length, right_t = t.Length;
        
        while (left_s + 1 < s.Length && left_t + 1 < t.Length && s[left_s + 1] == t[left_t + 1]) {
            left_s++; 
            left_t++;
        }
        
        while (right_s - 1 >=0 && right_t - 1 >=0 && s[right_s - 1] == t[right_t- 1]) {
            right_s--; 
            right_t--;
        }
        
        if (s.Length > t.Length) {
            if (left_t == t.Length - 1 || right_t == 0 || left_t == right_t - 1) 
                return true;
        }
        else if (s.Length < t.Length) {
            if (left_s == s.Length - 1 || right_s == 0 || left_s == right_s - 1) 
                return true;
        }
        else {
            if (left_t == t.Length - 2 || right_t == 1 || left_t == right_t - 2) 
                return true;
        }
        return false;        
    }
}
```

- Given an integer array nums, move all 0's to the end of it while maintaining the relative order of the non-zero elements.

- <b>Note</b>: that you must do this in-place without making a copy of the array.
- https://leetcode.com/explore/interview/card/facebook/5/array-and-strings/262/
  
```cs
public void MoveZeroes(int[] nums) {  
    //Move all non-zero numbers to the left
    var index =0;
    for (int i=0; i< nums.Length; i++) {
        if (nums[i] != 0) {
            if (i != index) {
                nums[index] = nums[i]; 
            }
            index++; 
        }
    }
    //and set all remains are 0
    for (int i=index; i< nums.Length; i++) {
        nums[i] = 0;
    }
}
```