![image](https://user-images.githubusercontent.com/12803690/236656988-db610026-e4b6-41ef-b1d7-911ac2394dcb.png)
![image](https://user-images.githubusercontent.com/12803690/236994432-9ebe6bce-6ba8-4fb6-87af-9defd3d1d658.png)

# solutions
### iterative
```python
def remove_node(head, target_val):
  if head.val == target_val:
    return head.next

  current = head
  prev = None
  while current is not None:
    if current.val == target_val:
      prev.next = current.next
      break
    prev = current
    current = current.next
  return head
```  
* n = number of nodes
* Time: O(n)
* Space: O(1)

### recursive
```python
def remove_node(head, target_val):
  if head is None:
    return None

  if head.val == target_val:
    return head.next

  head.next = remove_node(head.next, target_val)
  return head
```

* n = number of nodes
* Time: O(n)
* Space: O(n)
