//https://leetcode.com/problems/longest-common-subsequence/description/?envType=study-plan-v2&envId=amazon-spring-23-high-frequency


public class Solution {
    public int LongestCommonSubsequence(string text1, string text2) {
        //Use dynamic programming 
        var m = text1.Length; 
        var n = text2.Length; 

        var dp = new int[m,n]; //dp[i,j] = max common subsequence of i,j

        if (text1[0] == text2[0]) {
            dp[0,0 ] = 1;
        }

        for (int i=1; i<m; i++) {            
            dp[i, 0] = text2[0] == text1[i] ? 1 : dp[i-1,0];             
        }        

        for (int j=1; j<n; j++) {
            dp[0, j] = text1[0] == text2[j] ? 1 : dp[0,j-1];            
        }        

        for (int i=1; i<m; i++) {
            for (int j=1; j<n; j++) {
                if (text1[i] == text2[j]) {
                    dp[i,j] = dp[i-1, j-1] + 1; 
                }
                else {
                    dp[i,j] = Math.Max(Math.Max(dp[i-1, j], dp[i,j-1]), dp[i,j]);
                }
            }
        }
        return dp[m-1, n -1]; 
    }
}
