def find_repeated_sequences(s, k):
    #create a set to store hash map and another set to store result
    hash_set, result_set = set(), set()
    #slide window to look for pattern then add it to result set if its not in hash map
    for i in range(len(s)-k+1):
        current = s[i:i+k]
        if current in hash_set:
            result_set.add(current)
        hash_set.add(current)
    #return result as a list
    return list(result_set)
