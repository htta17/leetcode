![image](https://user-images.githubusercontent.com/12803690/229689765-344d4c6d-057a-4314-831a-104ef450fdb4.png)
We need a tail node to track the tail of our zipped list:
![image](https://user-images.githubusercontent.com/12803690/231336222-5b165481-089d-4483-927a-16fb876c8e5a.png)
![image](https://user-images.githubusercontent.com/12803690/231336283-085eb1c4-57d3-4054-82b4-e3c489b8c29f.png)
![image](https://user-images.githubusercontent.com/12803690/231336376-02bb48fa-7750-4270-a248-1c035c3a298f.png)
![image](https://user-images.githubusercontent.com/12803690/231336425-55c7f180-eaf5-4e0d-9fd0-d6f1e510e239.png)

**solutions**
**iterative**
```python
def zipper_lists(head_1, head_2):
  tail = head_1
  current_1 = head_1.next
  current_2 = head_2
  count = 0
  while current_1 is not None and current_2 is not None:
    if count % 2 == 0:
      tail.next = current_2
      current_2 = current_2.next
    else:
      tail.next = current_1
      current_1 = current_1.next
    tail = tail.next
    count += 1
    
  if current_1 is not None:
    tail.next = current_1
  if current_2 is not None:
    tail.next = current_2
    
  return head_1
```

n = length of list 1

m = length of list 2

Time: O(min(n, m))

Space: O(1)

**recursive**
```python
def zipper_lists(head_1, head_2):
  if head_1 is None and head_2 is None:
    return None
  if head_1 is None:
    return head_2
  if head_2 is None:
    return head_1
  next_1 = head_1.next
  next_2 = head_2.next
  head_1.next = head_2
  head_2.next = zipper_lists(next_1, next_2)
  return head_1  
```
n = length of list 1

m = length of list 2

Time: O(min(n, m))

Space: O(min(n, m))
