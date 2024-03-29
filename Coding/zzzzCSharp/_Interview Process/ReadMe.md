<details>
  <summary>Unique Email Addresses https://leetcode.com/explore/interview/card/google/67/sql-2/3044/</summary>
  
  ```cs
 public int NumUniqueEmails(string[] emails) {
        
        var dic = new Dictionary<string, HashSet<string>>(); 
        foreach(var email in emails) {
            var analyze = email.Split('@'); //Split email to local & domain 
            
            var domain = analyze[1]; 
            if (!dic.ContainsKey(domain)) {
                dic.Add(domain, new HashSet<string>());
            }
            var local = analyze[0]; 
            var plusIndex = local.IndexOf('+');
            if (plusIndex > 0) {
                local = local.Substring(0, plusIndex);
            }
            local =  local.Replace(".","");
            dic[analyze[1]].Add(local);
        }
        
        var sum = 0;        
        foreach(var key in dic.Keys) {
            sum += dic[key].Count;
        }
        return sum;
    }
  ```
</details>


<details>
  <summary>License Key Formatting: https://leetcode.com/explore/interview/card/google/67/sql-2/472/</summary>
  
  ```cs
public string LicenseKeyFormatting(string s, int k) {
    var ans = "";
        var count = 0;
        for (int i=s.Length -1; i>=0; i--) { 
            if (s[i] != '-') {    
                var c = s[i] <= 'z' && s[i] >= 'a' ? (char)(s[i] - 32) : s[i];
                ans = c + ans;                 
                count++;
                if (count == k) {
                    ans = '-' + ans;
                    count = 0;
                }
            }            
        }
        if (ans.Length > 0 && ans[0] == '-') {
            ans = ans.Substring(1);
        }
        return ans;
}  
  
  ```
  
</details>

<details>
<summary>Extra long factorials: https://www.hackerrank.com/challenges/extra-long-factorials</summary>

```cs
public static string multiply1Digit(string s, int digit) {
        var ans = "";
        var memo =0;  
        for (int i=s.Length-1; i>=0; i--) {            
            var num = s[i] - '0'; 
            var result = num * digit + memo; 
            memo = result / 10; 
            ans = (result % 10).ToString() + ans;
        }
        if (memo > 0) {
            ans = memo.ToString() + ans;
        }
        return ans;
    }
    
    public static string plus2Strings(string a, string b) {
        while (a.Length < b.Length) a = "0" + a; 
        while (a.Length > b.Length) b = "0" + b; 
        var ans = ""; 
        var memo = 0; 
        
        for (int i=a.Length - 1; i>=0; i--) {
            var result = a[i] - '0' + b[i] - '0' + memo; 
            memo = result / 10; 
            ans = (result % 10).ToString() + ans;
        }        
        if (memo > 0) {
            ans = memo.ToString() + ans;
        }
        return ans;
    }

    public static void extraLongFactorials(int n)
    {
        var ans = "1"; 
        for (int i=2; i<=n; i++) {
            if (i < 10) {
                ans = multiply1Digit(ans, i);
            }
            else if (i >=10 && i <= 99) {
                var r1 = multiply1Digit(ans, i / 10) + "0" ;
                var r2 = multiply1Digit(ans, i % 10) ;
                ans = plus2Strings(r1, r2);
            }
            else if (i >= 100 && i <= 999) {
                var r1 = multiply1Digit(ans, i / 100) + "00" ;
                var r2 = multiply1Digit(ans, (i % 100)/10) + "0";
                var r3 = multiply1Digit(ans, i % 10) ;
                ans = plus2Strings(plus2Strings(r1, r2), r3);
            }
        }
        Console.WriteLine(ans);
    }
```

</details>

<details>
<summary>Isomorphic Strings: https://leetcode.com/explore/interview/card/google/66/others-4/3098/</summary>


```cs
public bool IsIsomorphic(string s, string t) {
    var mapS = new Dictionary<char,char>();        
    var mapT = new Dictionary<char,char>();        
    for (int i=0; i< s.Length; i++) {
        if (!mapS.ContainsKey(s[i]) &&  !mapT.ContainsKey(t[i])) {
            mapS[s[i]] = t[i];
            mapT[t[i]] = s[i];
        }
        else if (!mapS.ContainsKey(s[i]) ||  !mapT.ContainsKey(t[i])) {
            return false;
        }
        else if (mapS[s[i]] != t[i] || mapT[t[i]] != s[i]) {
            return false;
        }            
    }
    return true;
}
```
</details>

<details>
  <summary>Strobogrammatic Number: https://leetcode.com/explore/interview/card/google/66/others-4/3099/</summary>

```cs
Dictionary<char,char> dic = new Dictionary<char,char>
    {
        {'0', '0'},
        {'1', '1'},
        {'8', '8'},
        {'6', '9'},        
        {'9', '6'} 
    }; 
    public bool IsStrobogrammatic(string num) {
        var n = num.Length;
        var ans = true; 
        if (n % 2 == 1) { //
            var middleChar =  num[n / 2]; 
            ans =  middleChar == '0' ||  middleChar == '8' || middleChar == '1'; 
        }
        if (n > 1) {
            ans = ans && dic.ContainsKey(num[0]) 
                    && dic[num[0]] == num[num.Length - 1]
                    && (num[0] - '0' > 0); 
            for (int i=1; i< n/2; i++) {
                ans = ans && dic.ContainsKey(num[i])
                          && dic[num[i]] == num[num.Length - 1 - i]; 
            }            
        }        
        return ans;
    }

```

</details>
