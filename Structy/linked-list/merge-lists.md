![image](https://user-images.githubusercontent.com/12803690/231335401-d3240637-ac1b-4a9e-9fd8-f877eb29cd31.png)
We want to create a dummy node so that we can link it to the smaller first node of the two lists:
![image](https://user-images.githubusercontent.com/12803690/231335478-fa63b6c0-bc6e-4731-879c-ebd3cef93894.png)
![image](https://user-images.githubusercontent.com/12803690/231335543-4fcfcdb2-586b-40b3-a716-2bf6c3213a0c.png)

**solutions**

**iterative**
```python
def merge_lists(head_1, head_2):
  dummy_head = Node(None)
  tail = dummy_head
  current_1 = head_1
  current_2 = head_2
  
  while current_1 is not None and current_2 is not None:
    if current_1.val < current_2.val:
      tail.next = current_1
      current_1 = current_1.next
    else:
      tail.next = current_2
      current_2 = current_2.next
    tail = tail.next
  
  if current_1 is not None: tail.next = current_1
  if current_2 is not None: tail.next = current_2
    
  return dummy_head.next
```

n = length of list 1

m = length of list 2

Time: O(min(n, m))

Space: O(1)

**recursive**

```python
def merge_lists(head_1, head_2):
  if head_1 is None and head_2 is None:
    return None
  if head_1 is None:
    return head_2
  if head_2 is None:
    return head_1
  if head_1.val < head_2.val:
    next_1 = head_1.next
    head_1.next = merge_lists(next_1, head_2)
    return head_1
  else:
    next_2 = head_2.next
    head_2.next = merge_lists(head_1, next_2)
    return head_2
```

n = length of list 1

m = length of list 2

Time: O(min(n, m))

Space: O(min(n, m))
