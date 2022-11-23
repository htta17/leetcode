An input array containing non-zero integers is given, where the value at each index represents the number of places to skip forward (if the value is positive) or backward (if the value is negative). When skipping forward or backward, wrap around if you reach either end of the array. For this reason, we are calling it a circular array. Determine if this circular array has a cycle. A cycle is a sequence of indices in the circular array characterized by the following:

The same set of indices is repeated when the sequence is traversed in accordance with the aforementioned rules.
The length of the sequence is at least two.
The loop must be in a single direction, forward or backward.

https://www.youtube.com/watch?v=2hVinjU-5SA&ab_channel=CodingSimplified

```py
def circular_array_loop(arr):  
    
    if len(arr) == 1:
        return False
    
    for i in range(len(arr)):
        slow = i 
        fast = i
        ifForward = arr[i] > 0

        while True:
            slow = getNextPosition(arr, slow, ifForward)
            if slow == -1:
                break
            fast = getNextPosition(arr,fast,ifForward)
            if fast == -1:
                break
            fast = getNextPosition(arr,fast,ifForward)
            if fast == -1:
                break
            if slow == fast:
                return True
    return False


def getNextPosition(arr, index, ifForward):
    direction = arr[index] > 0
    if direction!= ifForward:
        return -1
    #it's a circular array so we need to % to loop back
    nextIndex = (index + arr[index]) % len(arr)
    # this is for the case that the next index is the first index AND it's negative 
    # example: -2,-1,1,-2,-1
    if nextIndex < 0:
        nextIndex = nextIndex + len(arr)

    #this one is to check if the cycle has only one element
    if nextIndex == index:
        return -1
    
    return nextIndex
```
