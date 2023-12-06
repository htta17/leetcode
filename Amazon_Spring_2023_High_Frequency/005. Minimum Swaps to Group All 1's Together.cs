//https://leetcode.com/problems/minimum-swaps-to-group-all-1s-together/description/?envType=study-plan-v2&envId=amazon-spring-23-high-frequency

/*
Concept: The subarray with all '1' has the length = number of '1' in array. 
*/

public class Solution {
    public int MinSwaps(int[] data) {
        //Find how many '1' in the array 
        var count1 = 0; 
        foreach(var datum in data) {
            count1 += datum; 
        }       

        //And find the 
        var thisWindow = 0;        
        for (int i=0; i< count1; i++) {
            thisWindow += data[i];
        }
        var max = thisWindow; 
        for (var next = 1; next <= data.Length - count1; next++) {
            thisWindow = thisWindow - data[next -1 ] + data[next + count1 -1]; 
            max = Math.Max(thisWindow, max);
        }
        return count1 - max; 
    }
}
