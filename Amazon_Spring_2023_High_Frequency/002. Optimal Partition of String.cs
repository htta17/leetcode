//https://leetcode.com/problems/optimal-partition-of-string/?envType=study-plan-v2&envId=amazon-spring-23-high-frequency


public class Solution {
    public int PartitionString(string s) {
        //Use dynamic programming 
        var pos = new int[26]; //keep last position 

        for (int i=0; i< 26; i++) {
            pos[i] = -1; 
        }

        pos[s[0] - 'a'] = 0; 

        var minarr = new int[s.Length]; 

        minarr[0] = 1; 

        for (int i=1; i< s.Length; i++) {

            var curCh = s[i]; 
            var lastPos = pos[curCh - 'a']; 

            if (lastPos >= 0) {                
                minarr[i] = Math.Max(minarr[lastPos] + 1, minarr[i-1]);
            }
            else {
                minarr[i] = minarr[i-1];
            }
            pos[curCh - 'a'] = i; 
        }

        return minarr[s.Length -1];
    }
}
