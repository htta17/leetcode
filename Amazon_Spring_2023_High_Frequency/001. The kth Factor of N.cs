//https://leetcode.com/problems/the-kth-factor-of-n/?envType=study-plan-v2&envId=amazon-spring-23-high-frequency

public class Solution {
    public int KthFactor(int n, int k) {
        if (k == 1) {
            return 1; 
        }

        var num = 2; 
        var count = 1; 
        while (n > 1 && num <= n) {
            if (n % num == 0) {
                count++; 
                if (count == k) {
                    return num; 
                }
            }
            num++;
        }
        return -1; 
    }
}
