<img width="738" alt="image" src="https://user-images.githubusercontent.com/12803690/229403134-af835120-9e42-4d0d-9392-299f1506cf15.png">

**solutions**

**iterative**
```
def get_node_value(head, index):
  count = 0
  current = head
  while current is not None:
    if count == index:
      return current.val
    
    current = current.next
    count += 1
    
  return None
```
n = number of nodes

Time: O(n)

Space: O(1)

**recursive**
```
def get_node_value(head, index):
  if head is None:
    return None
  
  if index == 0:
    return head.val
  
  return get_node_value(head.next, index - 1)
```
n = number of nodes

Time: O(n)

Space: O(n)
