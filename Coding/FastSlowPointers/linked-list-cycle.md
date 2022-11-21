https://www.youtube.com/watch?v=gBTe7lFR3vc&ab_channel=NeetCode

```py

from linked_list import LinkedList

def detect_cycle(head):

   slow, fast = head, head

   while fast and fast.next:

      slow = slow.next
      fast = fast.next.next

      if slow == fast:
         return True

   # Write your code here

   return False
   
```
