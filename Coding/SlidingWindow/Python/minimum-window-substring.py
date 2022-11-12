def min_window(s, t):
    # Empty string scenario
    if t == "":
        return ""
    # Creating the two hash maps
    r_count = {}
    window = {}

    # Populating r_count hash map
    for c in t:
        r_count[c] = 1 + r_count.get(c, 0)

    # Setting up the conditional variables
    current, required = 0, len(r_count)
    # Setting up a variable containing the result's starting and ending point
    # with default values and a length variable
    res, res_len = [-1, -1], float("infinity")
    # Setting up the sliding window pointers
    left = 0
    for right in range(len(s)):
        c = s[right]
        window[c] = 1 + window.get(c, 0)  # Populating the window hash map

        # Updating the current variable
        if c in r_count and window[c] == r_count[c]:
            current += 1

        while current == required:  # Adjusting the sliding window
            # update our result
            if (right - left + 1) < res_len:
                res = [left, right]
                res_len = (right - left + 1)
            # pop from the left of our window
            window[s[left]] -= 1
            if s[left] in r_count and window[s[left]] < r_count[s[left]]:
                current -= 1  # if the popped character was among the required characters and removing it has reduced its frequency below its frequency in t, decrement current
            left += 1
    left, right = res
    return s[left:right+1] if res_len != float("infinity") else ""


