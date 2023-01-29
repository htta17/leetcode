<details>
  <summary>Count and Say: https://leetcode.com/problems/count-and-say</summary>
  
  
 ```cs
public string CountAndSay(int n) {
    if (n == 1) return "1";
    var prev = CountAndSay(n-1);
    var ans = "";
    var currDigit = prev[0];
    var cntCurr = 1; 
    for (int i=1; i<prev.Length; i++) {
        if (prev[i] == prev[i-1]) {
            cntCurr ++; 
        }
        else {
            ans += string.Format("{0}{1}", cntCurr, prev[i-1]); 
            cntCurr = 1;
        }
    } 
    return  string.Format("{0}{1}{2}", ans, cntCurr, prev[prev.Length-1]);
}
 ```
  </details>
  
  
  <details>
  <summary>Sqrt(x): https://leetcode.com/problems/sqrtx</summary>
  
  ```cs
  public int MySqrt(int x) {        
        if (x <= 1)
            return x;
        var left = 1; 
        var right = 65536;
        while (left < right -1) {
            var mid = (left + right) /2; 
            long midS =(long) mid *(long) mid;             
            if (midS == x) {
                return mid; 
            }
            else if (midS > x) {
                right = mid; 
            }
            else {
                left = mid; 
            }
        } 
        return left;         
    }
  ```
</details>

<details>
<summary>Strobogrammatic Number II: https://leetcode.com/explore/interview/card/google/62/recursion-4/399/</summary>
    
```cs
public class Solution {
Dictionary<int, int> dic = new  Dictionary<int, int>() {
    {0, 0}, {1, 1}, {6, 9}, {8, 8}, {9, 6}        
};     
int n;     
IList<string> Strobogrammatic(int k) {
    var ans = new List<string>(); 
    if (k == 0) {
        ans.Add("");
        return ans;
    }
    else if (k == 1) {
        foreach (var key in dic.Keys) 
            if (key == dic[key]) 
                ans.Add(key.ToString());                
        return ans;
    } 
    else {
        var prvResult = Strobogrammatic(k-2); 
        foreach (var result in prvResult) 
            foreach(var key in dic.Keys)
                if (k != n || (key > 0)) 
                    ans.Add(string.Format("{0}{1}{2}", key, result, dic[key]));                    
        return ans;
    }
}    
public IList<string> FindStrobogrammatic(int n) {
    this.n = n; 
    return Strobogrammatic(n);
}
}
```
</details>
