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
 
 <details>
  <summary>Min Stack: https://leetcode.com/explore/interview/card/google/65/design-4/3091/</summary>
  
  ```cs
  public class MinStack {
    Stack<int[]> stack; //Each item, we store both min & value    
    public MinStack() {
        stack = new Stack<int[]>();
    }
    
    public void Push(int val) {
        if (stack.Count == 0) {
            stack.Push(new int[]{ val, val});            
        }
        else {
            //Find the current min & value
            var curr = stack.Peek(); 
            var min = Math.Min(curr[1], val);
            //Store value & min
            stack.Push(new int[]{val, min});
        }
    }
    
    public void Pop() { 
        stack.Pop();
    }
    
    public int Top() {
        return stack.Peek()[0];
    }
    
    public int GetMin() {
       return stack.Peek()[1];
    }
}
  ```
 
 </details>
   
 <details>
   <summary>Insert Delete GetRandom O(1) https://leetcode.com/explore/interview/card/google/65/design-4/3094/</summary>

   ```cs
   public class RandomizedSet {
    HashSet<int> set; //O(1)
    List<int> list; 
    public RandomizedSet() {
        set = new HashSet<int>();        
        list = new List<int>();
    }
    
    public bool Insert(int val) {
        var ans = set.Add(val);
        if (ans) {
            list.Add(val);
        }
        return ans;
    }
    
    public bool Remove(int val) {
        var ans =  set.Remove(val);
        if (ans) {
            list.Remove(val);
        }
        return ans;
    }
    
    public int GetRandom() {
        var rand = new Random();
        var next = rand.Next(set.Count) ;
        return list[next]; //List can use for random
    }
}

```
   </details>
   
 <details>
 <summary>Serialize and Deserialize Binary Tree https://leetcode.com/explore/interview/card/google/65/design-4/3092/ </summary>

```cs
public class Codec {
    // Encodes a tree to a single string.
    public string serialize(TreeNode root) {
        //Format after serialization: 
        //[1,2,3,null,null,4,5] --> 1(2,3(4,5))
        if (root == null)
            return null ;        
        var data = root.left != null ||  root.right != null ? 
                    string.Format("{0}({1},{2})", 
                            root.val, 
                            root.left == null ? "null" : serialize(root.left), 
                            root.right == null ? "null" : serialize(root.right))
             :     root.val.ToString();        
        return data;       
    }
    // Decodes your encoded data to tree.
    public TreeNode deserialize(string data) {
        if (data == null || data == "null")
            return null;
        var ans = new TreeNode(0);
        var nodeValIndex = data.IndexOf('('); //Find the first 
        if (nodeValIndex < 0) {
            ans.val = int.Parse(data);             
        }
        else  {            
            ans.val = int.Parse(data.Substring(0, nodeValIndex));            
            //Find the ',' with no open or close
            var childrenStr = data.Substring(nodeValIndex + 1, data.Length - nodeValIndex - 2 ); 
            
            int findComma = 0; 
            int indexOfComma = -1; 
            int countOpen = 0; 
            while (findComma < childrenStr.Length ) {
                if (childrenStr[findComma] == '(') 
                    countOpen ++; 
                else if (childrenStr[findComma] == ')') 
                    countOpen --; 
                else if (childrenStr[findComma] == ',' && countOpen == 0) {
                    indexOfComma = findComma; 
                    findComma = childrenStr.Length;
                }
                findComma++;                
            }
            if (indexOfComma > 0) {
                ans.left = deserialize(childrenStr.Substring(0,indexOfComma));
                ans.right = deserialize(childrenStr.Substring(indexOfComma + 1));
            }            
        }
        return ans;
    }
}
```

</details>
