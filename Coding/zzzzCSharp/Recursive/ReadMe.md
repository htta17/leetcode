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
