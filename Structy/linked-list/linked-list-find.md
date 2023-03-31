![image](https://user-images.githubusercontent.com/12803690/229168788-543f16cb-a5ba-4959-86e9-1f2af444e944.png)

**solutions**

**iterative**
```
def linked_list_find(head, target):
  current = head
  while current is not None:
    if current.val == target:
      return True
    current = current.next
  return False
```
n = number of nodes
Time: O(n)
Space: O(1)

**recursive**
```
def linked_list_find(head, target):
  if head is None:
    return False
  if head.val == target:
    return True
  return linked_list_find(head.next, target)
```
n = number of nodes
Time: O(n)
Space: O(n)
