![image](https://user-images.githubusercontent.com/12803690/236994044-3c639543-d093-4073-82d1-47598b50c86e.png)
![image](https://user-images.githubusercontent.com/12803690/236994108-869f98f4-e7bb-4827-bab1-7c147c2e14e4.png)
![image](https://user-images.githubusercontent.com/12803690/236994135-96c6e069-f136-4c28-9b80-9d8932a19707.png)
### solutions
```python
def create_linked_list(values):
  dummy_head = Node(None)
  tail = dummy_head
  for val in values:
    tail.next = Node(val)
    tail = tail.next
  return dummy_head.next
```
* n = length of values
* Time: O(n)
* Space: O(n)
### recursive
```python
def create_linked_list(values, i = 0):
  if i == len(values):
    return None
  head = Node(values[i])
  head.next = create_linked_list(values, i + 1)
  return head
```
* n = length of values
* Time: O(n)
* Space: O(n)
