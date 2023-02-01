<details>
  <summary>Implement Trie: https://leetcode.com/explore/learn/card/trie/147/basic-operations/1047/ </summary>
  
  ```cs
  public class TrieNode {
    private TrieNode[] Children {get;set;}    
    private bool isEnd {get;set;}    
    public TrieNode() {
        Children = new TrieNode[26];
        isEnd = false; 
    }    
    public void Insert(char c, TrieNode node) {
        Children[c - 'a'] = node;        
    }
    public bool Contains(char c) {
        return Children[c - 'a'] != null;
    }
    public TrieNode GetNode(char c) {
        return Children[c - 'a']; 
    }    
    public bool IsEnd() {
        return isEnd; 
    }
    public void SetEndNode() {
        isEnd = true;
    }    
}

public class Trie {
    private TrieNode root {get; set;}
    
    public Trie() {
        root = new TrieNode(); 
    }
    
    public void Insert(string word) {
        var node = root;         
        for (int i =0; i< word.Length; i++) {
            var c = word[i];
            if (!node.Contains(c)) {
                node.Insert(c, new TrieNode());
            }
            node = node.GetNode(c);
        }    
        node.SetEndNode(); 
    }
    
    private TrieNode InternalSearch(string word) {
        var node = root; 
        for (int i =0; i< word.Length; i++) {
            var c = word[i];
            if (!node.Contains(c)) 
                return null;             
            else 
                node = node.GetNode(c); 
        }       
        return node;
    }
    
    public bool Search(string word) {
        var node = InternalSearch(word);        
        return node != null && node.IsEnd();
    }
    
    public bool StartsWith(string prefix) {
        var node = InternalSearch(prefix);
        return node != null;
    }
}
  ```
</details>

<details>
  <summary>Implement Trie: https://leetcode.com/explore/learn/card/trie/147/basic-operations/1047/ </summary>

<br/> 
<b>Solution 1</b>: Brute Force - Using dictionary to store key - value

```cs 
public class MapSum {
    Dictionary<string, int> set;
    public MapSum() {
        set = new Dictionary<string, int>(); 
    }    
    public void Insert(string key, int val) {
        set[key] = val; //Add or update (overridden) value
    }    
    public int Sum(string prefix) {
        var sum =0; 
        //Go through all key and check which key contains prefix
        foreach (var key in set.Keys) {
            if (key.StartsWith(prefix)) {
                sum += set[key];
            }
        }
        return sum;
    }
}
```

  
</details>
  
