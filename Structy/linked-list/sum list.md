![image](https://user-images.githubusercontent.com/12803690/229020293-9e09befb-3411-403c-9fbc-3458e8fe99a9.png)
**solutions**

**iterative**
```
def sum_list(head):
  total_sum = 0
  current = head
  while current is not None:
    total_sum += current.val
    current = current.next
  return total_sum
```
n = number of nodes
Time: O(n)
Space: O(1)

**recursive**

```
def sum_list(head):
  if head is None:
    return 0
  return head.val + sum_list(head.next)
n = number of nodes
```
Time: O(n)
Space: O(n)
