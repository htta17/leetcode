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
