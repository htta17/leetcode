![image](https://user-images.githubusercontent.com/12803690/235831668-20dc924a-59cb-47e8-b478-4276b67bf0a3.png)
# solutions
## iterative
```python
def longest_streak(head):
  max_streak = 0
  current_streak = 0
  prev_val = None
  
  current_node = head
  while current_node is not None:
    if current_node.val == prev_val:
      current_streak += 1
    else:
      current_streak = 1
  
    prev_val = current_node.val
    if current_streak > max_streak:
      max_streak = current_streak
    
    current_node = current_node.next
    
  return max_streak
```
n = number of nodes

Time: 
* O(n)
* Space: O(1)
