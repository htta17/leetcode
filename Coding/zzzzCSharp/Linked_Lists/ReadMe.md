<details>
<summary>https://leetcode.com/explore/interview/card/facebook/6/linked-list/319/</summary>
    
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
</details>

<details>
<summary>https://leetcode.com/problems/linked-list-cycle/description/</summary>
    
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
</details>
    

<details>
<summary>Given the <code>head</code> of a linked list, return the node where the cycle begins. If there is no cycle, return <code>null</code>. 
    </summary>
    
```cs
public ListNode DetectCycle(ListNode head) {
    var set = new HashSet<ListNode>(); 
    while (head != null) {
        if (!set.Add(head)) {
            return head;
        }
        head = head.next;
    }
    return null; 
}
```
</details>
    
<details>
<summary>https://leetcode.com/problems/reorder-list/</summary>
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
</details>
<details>
<summary>https://leetcode.com/problems/maximum-twin-sum-of-a-linked-list/description/</summary>

- In a linked list of size n, where n is even, the ith node (0-indexed) of the linked list is known as the twin of the (n-1-i)th node, if 0 <= i <= (n / 2) - 1. <br> 
The twin sum is defined as the sum of a node and its twin.
Given the head of a linked list with even length, return the maximum twin sum of the linked list.

```cs
public int PairSum(ListNode head) {
    var dic = new Dictionary<int, int>();
    var index = 0;  
    while (head != null) {
        dic[index] = head.val; 
        index++; 
        head = head.next;
    }
    var ans =0;
    for (int i=0; i< index / 2; i++) {
        ans = Math.Max(ans, dic[i] + dic[index - 1 - i]);
    }
    return ans;        
}
```
</details>

<details>
<summary>https://leetcode.com/problems/middle-of-the-linked-list/description/</summary>
    
- Given the head of a singly linked list, return the middle node of the linked list. If there are two middle nodes, return the second middle node.
    
```cs
public ListNode MiddleNode(ListNode head) {
   var index =0; 
    ListNode node = head; 
    while (head != null) {            
        index++; 
        if (index % 2 == 0) {
            node = node.next;
        }
        head = head.next; 
    }
    return node;
}
```
</details>

<details>
<summary>https://leetcode.com/explore/interview/card/microsoft/32/linked-list/169/</summary>

- Given the head of a singly linked list, reverse the list, and return the reversed list.

```cs
//Using stack to store the list, and pop to reverse
public ListNode ReverseList(ListNode head) {
    Stack<int> st = new Stack<int>();        
    if (head == null)
        return null;        
    while(head != null) {
        st.Push(head.val); 
        head = head.next;
    }        
    var newNode = new ListNode();        
    head = newNode;        
    while (st.Count > 0) {
        var val = st.Pop();
        newNode.val = val; 
        if (st.Count > 0) {
            newNode.next = new ListNode();
            newNode = newNode.next;
        }
    }        
    return head;
}
```

</details>
