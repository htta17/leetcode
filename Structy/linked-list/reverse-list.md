<img width="736" alt="image" src="https://user-images.githubusercontent.com/12803690/229406486-223785df-add9-4bb0-b201-ab15a3e01f8e.png">
<img width="389" alt="image" src="https://user-images.githubusercontent.com/12803690/229406536-d087ac97-5c86-4258-968c-5590ff3a90fc.png">
<img width="388" alt="image" src="https://user-images.githubusercontent.com/12803690/229406639-b196f3db-5715-4dfd-91e1-943595f002d4.png">
<img width="391" alt="image" src="https://user-images.githubusercontent.com/12803690/229406687-f56bc320-9989-48a4-8124-e3c649a046b3.png">
<img width="380" alt="image" src="https://user-images.githubusercontent.com/12803690/229406743-252d4d79-4689-4b75-9d73-ecdb53de04dd.png">
<img width="390" alt="image" src="https://user-images.githubusercontent.com/12803690/229406787-623f1fa0-6578-4eae-911c-8c0969189ccb.png">
<img width="462" alt="image" src="https://user-images.githubusercontent.com/12803690/229406856-ae1719e1-916e-4bdb-8872-ff4c241380c6.png">
<img width="461" alt="image" src="https://user-images.githubusercontent.com/12803690/229406896-3ed027f9-d316-4133-8250-c6236e3b1c79.png">
<img width="506" alt="image" src="https://user-images.githubusercontent.com/12803690/229406937-6838de4a-b165-4af3-bfa0-69fa69812774.png">

**solutions**

**iterative**
```python
def reverse_list(head):
  prev = None
  current = head
  while current is not None:
    next = current.next
    current.next = prev
    prev = current
    current = next
  return prev
```

n = number of nodes
Time: O(n)
Space: O(1)

**recursive**
```python
def reverse_list(head, prev = None):
  if head is None:
    return prev
  next = head.next
  head.next = prev
  return reverse_list(next, head)
```  
n = number of nodes
Time: O(n)
Space: O(n)
