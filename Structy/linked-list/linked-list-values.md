![image](https://user-images.githubusercontent.com/12803690/229018380-a6a567a0-821b-452a-bb7c-690ae063f655.png)
**solutions**

**iterative**

```
def linked_list_values(head):
  values = []
  current = head
  while current is not None:
    values.append(current.val)
    current = current.next
  return values
```
n = number of nodes
Time: O(n)
Space: O(n)

**recursive**

```
def linked_list_values(head):
  values = []
  _linked_list_values(head, values)
  return values

def _linked_list_values(head, values):
  if head is None:
    return
  values.append(head.val)
  _linked_list_values(head.next, values)
```
n = number of nodes
Time: O(n)
Space: O(n)
