//https://leetcode.com/problems/merge-operations-to-turn-array-into-a-palindrome/description/?envType=study-plan-v2&envId=amazon-spring-23-high-frequency

using Newtonsoft.Json; 
public class Solution {
    public int MinimumOperations(int[] nums) {
        var list = new List<int>(nums); 

        var left =0; 
        var right = list.Count - 1; 
        var count = 0; 

        while (left < right) {
            if (list[left] == list[right]) {
                left ++; 
                right --; 
            }
            else if (left == right - 1) {
                //Merge list[left] and list[right] to 1
                return count + 1; 
            }
            else if (list[left] < list[right]) {
                list[left] = list[left] + list[left + 1]; 
                right --; 
                list.RemoveAt(left + 1); 
                count += 1; 
            }
            else {
                list[right -1] += list[right]; 
                list.RemoveAt(right);
                right --; 
                count += 1; 
            }
            //Console.WriteLine(JsonConvert.SerializeObject(list));

        }

        return count;
    }
}
