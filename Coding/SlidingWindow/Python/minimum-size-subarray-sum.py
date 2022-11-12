def min_sub_array_len(target, nums):
    l = 0 
    res = float('inf')
    total = 0

    for r in range(len(nums)):
        total += nums[r]
        while total >= target:
            res = min(r - l + 1, res)
            total -= nums[l]
            l += 1
    return 0 if res == float('inf') else res
