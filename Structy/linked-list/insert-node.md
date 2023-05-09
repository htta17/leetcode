![image](https://user-images.githubusercontent.com/12803690/236991088-83227b80-cfd1-41e9-a898-95d38423ad72.png)
### solutions
## iterative
```python
def insert_node(head, value, index):
  if index == 0:
    new_head = Node(value)
    new_head.next = head
    return new_head
    
  count = 0
  current = head
  while current is not None:
    if count == index - 1:
      temp = current.next
      current.next = Node(value)
      current.next.next = temp
    
    count += 1
    current = current.next
  return head
```
* n = number of nodes
* Time: O(n)
* Space: O(1)
## recursive
```python
def insert_node(head, value, index, count = 0):
  if index == 0:
    new_head = Node(value)
    new_head.next = head
    return new_head
  
  if head is None:
    return None
  
  if count == index - 1:
      temp = head.next
      head.next = Node(value)
      head.next.next = temp
      return 
  
  insert_node(head.next, value, index, count + 1)
  return head
```
* n = number of nodes
* Time: O(n)
* Space: O(n)
