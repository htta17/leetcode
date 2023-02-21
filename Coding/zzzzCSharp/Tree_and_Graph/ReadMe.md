<details>
  <summary>Network Delay Time: https://leetcode.com/explore/learn/card/graph/622/single-source-shortest-path-algorithm/3863/</summary>
  
  ```cs
  public class Solution {
    public int NetworkDelayTime(int[][] times, int n, int k) {        
        var min = new int[n+1];
        var visited = new List<int>();        
        visited.Add(k);        
        
        var grid = new int[n + 1, n + 1];         
        for(int i =0; i<= n; i++) {
            min[i] = int.MaxValue;            
            for (int j =0; j<= n; j++) {
                grid[i,j] = -1; 
            }
        }
        foreach (var time in times) {            
            grid[time[0], time[1]] = time[2];            
        }
        min[k] = 0;        
        var index =0;        
        while (index < visited.Count) {            
            var newNode = visited[index];
            for (int i=1; i <= n; i++) {
                if (newNode != i && grid[newNode, i] >= 0) {                    
                    if (grid[newNode, i] + min[newNode] < min[i] ) {
                        visited.Add(i);
                        min[i] = grid[newNode, i] + min[newNode];
                    }
                }
            }            
            index ++;
        }        
        if (visited.Count < n)
            return -1;         
        var max = -1; 
        for (int i=1; i<=n ; i++)
            max = Math.Max(max, min[i]);
         return max;
    }
}
  ```
  
</details>

<details>
  <summary>Number of Provinces: https://leetcode.com/explore/learn/card/graph/618/disjoint-set/3845/</summary>
  
  ```cs
  public class Solution {
    int n; 
    int[] root; 
    int[] rank; 
    int count;
    
    int find(int x) {
        if (x == root[x]) {
            return x;
        }
        return root[x] = find(root[x]);
    }
    
    bool isConnected(int x, int y) {
        return find(x) == find(y);
    }
    
    void union(int x, int y) {
        var findX = find(x); 
        var findY = find(y);
        if (findX != findY) {
            count--;
            if (rank[findX] > rank[findY]) {
                root[findY] = findX;
            }
            else if (rank[findX] < rank[findY]) {
                root[findX] = findY;
            }
            else {
                root[findX] = findY;
                rank[findY] ++;
            }
        }
    }
    
    public void Init(int[][] isConnected) {
        n = isConnected.Length; 
        root = new int[n];
        rank = new int[n]; 
        for (int i=0; i<n; i++) {
            root[i] = i; 
            rank[i] = 1;
        }
        count = n;
    }
    
    
    public int FindCircleNum(int[][] isConnected) {
        Init(isConnected);
        
        for (int i=0; i<n; i++) {
            for (int j=0; j<n; j++) {
                if (i != j && isConnected[i][j] == 1) {
                    union(i,j); 
                }
            }
        }
        
        return count;
    }
}
  ```
  

</details>
<details>
  <summary>Longest Increasing Path in a Matrix: https://leetcode.com/explore/interview/card/google/61/trees-and-graphs/3072/</summary>
  
  ```cs
  public class Solution {
    int m,n; 
    int[,] mark; //To Store a path
    Dictionary<int, List<int[]>> startDic; //Store all node value, smaller one goes first
    int max; 
    int[][] matrix;
    
    public int LongestIncreasingPath(int[][] matrix) {
        this.matrix = matrix; 
        m = matrix.Length; 
        n = matrix[0].Length; 
        mark = new int[m,n]; 
        max = 0;         
        startDic = new Dictionary<int, List<int[]>>();        
        for (int i=0; i<m; i++) {
            for (int j=0; j<n; j++) {
                var val = matrix[i][j]; 
                if (!startDic.ContainsKey(val)) {
                    startDic.Add(val, new List<int[]>());
                }
                startDic[val].Add(new int[]{i, j}); 
            }
        }        
        var keys = startDic.Keys.OrderBy(c=>c);
        
        foreach (var key in keys) {
            var list = startDic[key]; 
            foreach (var item in list){
                DFS(item[0], item[1], 1); 
            }            
        }        
        return max;
    }
    int[] hor = new int[]{-1, 1, 0, 0}; 
    int[] ver = new int[]{0, 0, -1, 1};
    
    //Use Deep First Search
    //From position X, Y, we find all up, down, left, right position if they are greater than current position
    void DFS(int x, int y, int level) {
        if (mark[x,y] >= level) {
            return;
        }
        max = Math.Max(max, level);        
        mark[x,y] = level;  
        
        for (int i=0; i<4; i++) {
            var newX = x + hor[i]; 
            var newY = y + ver[i]; 
            if (newX >=0 && newX < m  && newY>=0 && newY < n 
                    && matrix[newX][newY] > matrix[x][y] ) {       
                DFS(newX,newY, level + 1);
            }
        }     
    } 
}
  ```
  
</details>

<details>
  <summary>Word Ladder: https://leetcode.com/explore/interview/card/google/61/trees-and-graphs/3068/</summary>
  
  ```cs
  public class Solution {
    HashSet<string> wordSet; //Set of 
    public int LadderLength(string beginWord, string endWord, IList<string> wordList) {
        wordSet = new HashSet<string>(wordList);        
        var queue = new Queue<string>(); 
        queue.Enqueue(beginWord);
        wordSet.Remove(beginWord);
        var count = 1;        
        while(queue.Count > 0) {
            var size = queue.Count; 
            count++; 
            for (int i=0; i< size; i++) {
                var word = queue.Dequeue(); 
                var neighbors = GetWordNeighbor(word);
                foreach(var neighbor in neighbors) {
                    wordSet.Remove(neighbor);
                    if (neighbor == endWord) 
                        return count;
                    else 
                        queue.Enqueue(neighbor);
                }                
            }
        }
        return 0;
    }
    List<string> GetWordNeighbor(string word) {
        var ans = new List<string>();
        //Go to each character of word and try to replace 
        for (var i=0; i< word.Length; i++) {
            for (int j=0; j< 26; j++) {
                var newChar = (char)('a' + j);
                if (newChar != word[i]) {
                    var newWord = word.Substring(0,i) + newChar + word.Substring(i+1);
                    if (wordSet.Contains(newWord)) {
                        ans.Add(newWord);
                    }
                }
            }     
        }
        return ans;
    }    
}
  ```

</details>
