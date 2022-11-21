- https://leetcode.com/explore/interview/card/facebook/6/linked-list/319/
- You are given two non-empty linked lists representing two non-negative integers. 
The digits are stored in reverse order, and each of their nodes contains a single digit. 
Add the two numbers and return the sum as a linked list. <br/>
You may assume the two numbers do not contain any leading zero, except the number 0 itself.
```cs
//memo to store value if l1 + l2 > 10
int memo =0;
public ListNode AddTwoNumbers(ListNode l1, ListNode l2) {
    var _sum = (l1 != null ? l1.val : 0) + (l2 != null ? l2.val : 0)  + memo;
    memo = _sum /10;
    var nodeVal = _sum % 10;
    var ans = new ListNode(nodeVal); 
    
    //If current nothing for next one
    if ((l1 == null || l1.next == null) && (l2 == null || l2.next == null) && (memo > 0))
        ans.next =new ListNode(memo);
    
    else if ((l1 != null && l1.next != null) || (l2 != null && l2.next != null))
        ans.next = AddTwoNumbers(l1 == null ? null : l1.next, l2 ==null ? null : l2.next);        

    return ans;        
}
```
- https://leetcode.com/problems/linked-list-cycle/description/
- Given <code>head</code>, the head of a linked list, determine if the linked list has a cycle in it.
```cs
public bool HasCycle(ListNode head) {
    var set = new HashSet<ListNode>(); 
    while (head != null) {
        if(!set.Add(head)) {
            return true;
        }
        head = head.next;
    }
    return false;
}
```
- Given the <code>head</code> of a linked list, return the node where the cycle begins. If there is no cycle, return <code>null</code>. 
```cs
public ListNode DetectCycle(ListNode head) {
    var set = new HashSet<ListNode>(); 
    while (head != null) {
        if (set.Contains(head)) {
            return head;
        }
        set.Add(head);
        head = head.next;
    }
    return null; 
}
```
- You are given the head of a singly linked-list. The list can be represented as: </br>
<code>
L0 → L1 → … → Ln - 1 → Ln
</code></br>
Reorder the list to be on the following form:</br>
<code>
L0 → Ln → L1 → Ln - 1 → L2 → Ln - 2 →
</code> </br> </br>

```cs
public void ReorderList(ListNode head) {
    var nodes = new ListNode[50000];        
    var count = 0;        
    var running = head;        
    while (running != null) {
        nodes[count] = running; 
        running = running.next; 
        count++;
    }
    int left = 0, right = count - 1; 
    running = head; 
    var isLeftChange = true;
    while (left < right) {
        if (isLeftChange) {
            running.next = nodes[right]; 
            left++; 
        } 
        else {
            running.next = nodes[left]; 
            right--; 
        }
        running = running.next;    
        if (left == right) {
            running.next = null;
        }
        isLeftChange = !isLeftChange;
    } 
}
```
