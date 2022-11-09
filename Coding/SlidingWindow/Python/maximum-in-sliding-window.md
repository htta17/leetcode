from collections import deque


def find_max_sliding_window(nums, window_size):
    # your code will replace this placeholder return statement
    result = []
    # Initializing doubly ended queue for storing indices
    window = deque()

    # Return 0 if nums is empty
    if len(nums) == 0:
        return result

    # If window_size is greater than the array size,
    # set the window_size to the array size
    if window_size > len(nums):
        window_size = len(nums)

    #set up first window
    for i in range(window_size):
        while window and nums[i] > nums[window[-1]]:
            window.pop()
        window.append(i)
    #append first window's maximum element
    result.append(nums[window[0]])
    
    #iterating through the rest of the array after setting up first window
    for i in range(window_size,len(nums)):
        while window and nums[i] >= nums[window[-1]]:
            window.pop()

        # Remove first index from the window deque if
        # it doesn't fall in the current window anymore 
        if window and window[0] <= (i - window_size):
            window.popleft()

        window.append(i)
        result.append(nums[window[0]])
        
    return result
