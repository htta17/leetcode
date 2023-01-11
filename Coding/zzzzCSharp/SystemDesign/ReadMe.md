<details>
  <summary>LRU Cache: https://leetcode.com/explore/interview/card/bloomberg/74/design/433/</summary>
  
  <b>If put function doesn't require O(1)</b>: We can use another dictionary to store positions of all keys
  
  ```cs
  public class LRUCache {
    Dictionary<int,int> cache; //Store key and value of the cache
    Dictionary<int,int> position;  //Store key and position. When the app receives new key, it will try to remove the min position
    int maxPosition =0;    
    int capacity;
    
    public LRUCache(int capacity) {
        this.capacity = capacity; 
        cache = new Dictionary<int,int>(); 
        position = new Dictionary<int,int>(); 
    }
    
    public int Get(int key) {
        if (cache.ContainsKey(key)) { 
            position[key] = maxPosition++;
            return cache[key];            
        }            
        return -1; 
    }
    
    public void Put(int key, int value) {        
        if (cache.Count >= capacity && !cache.ContainsKey(key)){  
            //Remove least use
            //Find the key which has position[key] is the min
            var min = int.MaxValue;
            var removeKey = -1; 
            foreach (var rkey in position.Keys) {
                if (min > position[rkey]) {
                    removeKey = rkey; 
                    min = position[rkey]; 
                }
            }
            position.Remove(removeKey);
            cache.Remove(removeKey);
        }
        cache[key] = value;
        position[key] = maxPosition++;
    }    
}
  ```
  
 </details>
