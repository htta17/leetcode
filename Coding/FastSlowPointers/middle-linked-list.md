Fast pointer will always move twice the speed of slow pointer. When fast pointer reach the end of the list, slow pointer will be at half position

```py

from linked_list import LinkedList

def get_middle_node(head):
    
    slow = head
    fast = head

    while fast and fast.next:

        slow = slow.next
        fast = fast.next.next
   
    return slow
```

