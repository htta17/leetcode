- https://leetcode.com/explore/interview/card/facebook/6/linked-list/319/
- You are given two non-empty linked lists representing two non-negative integers. 
The digits are stored in reverse order, and each of their nodes contains a single digit. 
Add the two numbers and return the sum as a linked list. <br/>
You may assume the two numbers do not contain any leading zero, except the number 0 itself.
```cs
int memo =0;
public ListNode AddTwoNumbers(ListNode l1, ListNode l2) {
    var x = (l1 != null ? l1.val : 0) + (l2 != null ? l2.val : 0)  + memo;
    memo = x /10; 
    var nodeVal = x % 10;        
    var ans = new ListNode(nodeVal);         

    if ((l1 == null || l1.next == null) && (l2 == null || l2.next == null) && (memo > 0))
        ans.next =new ListNode(memo); 

    else if ((l1 != null && l1.next != null) || (l2 != null && l2.next != null))
        ans.next = AddTwoNumbers(l1 == null ? null : l1.next, l2 ==null ? null : l2.next);        

    return ans;        
}
```
