https://leetcode.com/discuss/general-discussion/460599/blind-75-leetcode-questions

<h2>Array</h2>

<details>
  <summary>https://leetcode.com/problems/two-sum/
  </summary>
  
Given an array of integers nums and an integer target, return indices of the two numbers such that they add up to target.

You may assume that each input would have exactly one solution, and you may not use the same element twice.

You can return the answer in any order.
 ```cs
 public int[] TwoSum(int[] nums, int target) {        
      int[] ans = new int[2]; 
      var dic = new Dictionary<int, int>();
      for (int i=0; i< nums.Length; i++) {
          if (dic.ContainsKey(target - nums[i])) {
              ans = new int[]{ dic[target - nums[i]], i };
          }
          else {
              if (!dic.ContainsKey(nums[i]))
                  dic.Add(nums[i], i); 
          }
      }        
      return ans;        
  }
 ```
  
</details>

<details>
  <summary>https://leetcode.com/problems/product-of-array-except-self/
  </summary>
  
  Given an integer array <code>nums</code>, return an array answer such that <code>answer[i]</code> <i>is equal to the product of all the elements of</i> <code>nums</code> <i>except</i> <code>nums[i]</code>.

  The product of any prefix or suffix of nums is guaranteed to fit in a <b>32-bit</b> integer.

You must write an algorithm that runs in O(n) time and without using the division operation.
  
  ```cs 
  public int[] ProductExceptSelf(int[] nums) {
      var n = nums.Length;         
      var L = new int[n]; //At i: L[i] = nums[0] * nums[1] * ... * nums[i - 1]
      var R = new int[n]; //At i: R[i] = num[n-1] * nums[n-2]
      var ans = new int[n]; //At i: ans[i] = L[i] * R[i];        
      L[0] = 1; 
      for (int i=1; i< n; i++) {
          L[i] = L[i -1] * nums[i-1]; 
      }        
      R[n-1] = 1; 
      for (int i= n-2; i>=0; i--) {
          R[i] = R[i+1] * nums[i+1];
      }        
      for (int i=0; i< n; i++) {
          ans[i] = R[i] * L[i];
      }        
      return ans;
  }
  ```
  
</details>


<h2>Heap</h2>
<details>
<summary>https://leetcode.com/problems/merge-k-sorted-lists/</summary>

You are given an array of k linked-lists lists, each linked-list is sorted in ascending order.

Merge all the linked-lists into one sorted linked-list and return it.

```cs
public ListNode MergeKLists(ListNode[] lists) {  
        //Convert to List so we can remove when the list (of lists) is null
        var lList = lists.Where(c => c != null).ToList(); //Remove null list
        if (lList.Count == 0) {
            return null;
        }        
        var ans = new ListNode(); //Find next Node
        var fAn = ans; //Final answer
        while (lList.Count > 0) {
            var min = int.MaxValue; //Find the smallest value
            int minNodeIndex = -1;  //Mark the index of the list which has smallest value
            for(var i=0; i< lList.Count; i++) {
                if (min > lList[i].val) {
                    min = lList[i].val; 
                    minNodeIndex = i;
                }
            }
            lList[minNodeIndex] = lList[minNodeIndex].next; //When found the list, go to next one
            if (lList[minNodeIndex] == null) { //If this list reach the end, remove the list
                lList.RemoveAt(minNodeIndex);
            }
            ans.val = min;
            if (lList.Count > 0) {
                ans.next = new ListNode();
                ans = ans.next;
            }
        }
        return fAn;  
    }
```

</details>
  
<details>
  <summary>https://leetcode.com/problems/top-k-frequent-elements</summary> 
  
  Given an integer array nums and an integer k, return the k most frequent elements. You may return the answer in any order.
  
  ```cs
  public int[] TopKFrequent(int[] nums, int k) {         
      var dic = new Dictionary<int, int>();
      //Count the frequency of each elements
      for (int i=0; i< nums.Length; i++) {
          dic[nums[i]] = dic.ContainsKey(nums[i]) ? dic[nums[i]] + 1 : 1;
      }        
      var queue = new PriorityQueue<int,int>(); 
      foreach (var key in dic.Keys) {
          queue.Enqueue(key, -dic[key]);  //Add -dic[key] to order descending (most frequent)
      }        
      var ans = new int[k];
      int j =0; 
      while (j < k) {            
          ans[j] = queue.Dequeue(); 
          j++;
      }
      return ans;        
  }
  ```
</details>
  
<details>
  <summary>https://leetcode.com/problems/find-median-from-data-stream</summary>
  
  ```cs
  public class MedianFinder {   
    /*
    Concept: We use 2 priority queue
    First one is accending for big number
    And the other is decending for small number 
    */
    PriorityQueue<int,int> bigNumber; 
    PriorityQueue<int,int> smallNumber; 
    public MedianFinder() {
        bigNumber = new PriorityQueue<int,int>();
        smallNumber = new PriorityQueue<int,int>(Comparer<int>.Create((a,b) => b -a));
    }
    
    public void AddNum(int num) {         
        if (smallNumber.Count > bigNumber.Count) { //Try to add to bigNumber
            var biggestOfSmall = smallNumber.Peek(); 
            if (biggestOfSmall <= num) {   //Can add directly to big list
                bigNumber.Enqueue(num, num);
            }
            else {   
                //Need to move biggest element in small queue to big list, 
                //because new element is belong to small list
                smallNumber.Dequeue();
                smallNumber.Enqueue(num, num);
                bigNumber.Enqueue(biggestOfSmall, biggestOfSmall);
            }
        }
        else { //Add to smallNumber
            if (smallNumber.Count == 0) {
                smallNumber.Enqueue(num, num);
            }
            else {
                var smallestOfBig = bigNumber.Peek(); 
                if (smallestOfBig < num) {
                    bigNumber.Dequeue(); 
                    bigNumber.Enqueue(num, num);
                    smallNumber.Enqueue(smallestOfBig, smallestOfBig);
                }
                else {
                    smallNumber.Enqueue(num, num);
                }
            }
        }        
    }
    
    public double FindMedian() {
        if (smallNumber.Count > bigNumber.Count) {
            return smallNumber.Peek() * 1.0;
        }
        else {
            return (smallNumber.Peek() + bigNumber.Peek()) / 2.0; 
        }
    }
}
  ```
  </details>
  

