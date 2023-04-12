![image](https://user-images.githubusercontent.com/12803690/231341004-df66f319-c4ca-48e9-a752-df63af3c0d53.png)
**solutions**

**iterative**

```python
def is_univalue_list(head):
  current = head
  while current is not None:
    if current.val != head.val:
      return False
    current = current.next
  return True
```

n = number of nodes

Time: O(n)

Space: O(1)

**recursive**

```python
def is_univalue_list(head, prev_val = None):
  if head is None:
    return True
  if prev_val is None or head.val == prev_val:
    return is_univalue_list(head.next, head.val)
  else:
    return False
```

n = number of nodes

Time: O(n)

Space: O(n)
