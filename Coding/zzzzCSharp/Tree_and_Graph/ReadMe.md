<details>
  <summary>Longest Univalue Path: https://leetcode.com/problems/longest-univalue-path/description/</summary>
  
  ```cs
  public class Solution {
    public int LongestUnivaluePath(TreeNode root) {
        SumPath(root);
        return ans;
    }
    int ans = 0;

    int SumPath(TreeNode node, int parentValue = -1001) {
        if (node == null)
            return 0; 
        var left = SumPath(node.left, node.val);
        var right = SumPath(node.right, node.val);
        ans = Math.Max(ans, left + right);
        return node.val == parentValue ? Math.Max(left, right) + 1 : 0;
    }    
}
  ```
  
  
</details>  

<details>
  <summary>Binary Tree Maximum Path Sum: https://leetcode.com/problems/binary-tree-maximum-path-sum/submissions/905532298/</summary>
  
  ```cs
  public int MaxPathSum(TreeNode root) {
        MaxGain(root);
        return maxSum;
    }
    
    int maxSum = int.MinValue;
    
    int MaxGain(TreeNode root) {
        if (root == null) 
            return 0; 
        
        var gainFromLeft = Math.Max( MaxGain(root.left), 0);
        
        var gainFromRight = Math.Max( MaxGain(root.right), 0);
        
        maxSum = Math.Max(maxSum, gainFromLeft + gainFromRight + root.val);

        return Math.Max(gainFromLeft + root.val, gainFromRight + root.val);
        
    }
  
  ```
  
</details>
  


<details>
  <summary>Alien Dictionary: https://leetcode.com/explore/learn/card/graph/623/kahns-algorithm-for-topological-sorting/3909/</summary>
  
  ```cs
  public class Solution {   
    HashSet<char>[] previousSet = new HashSet<char>[26]; 
    //keep the list of all previous charcters 
    //for example: previousSet['s'] = {'a', 'z', 'j'} means 'a', 'z', 'j' must add to the answer 
    //before adding 's'
    HashSet<char> charSet = new HashSet<char>();
    bool Build(string s1, string s2) {        
        //1. add all characters of s1 and s2 to charSet    
        var min = Math.Min(s1.Length, s2.Length);
        var i=0; 
        while (i < min ) {
            charSet.Add(s1[i]);
            charSet.Add(s2[i]);            
            if (s1[i] == s2[i]) {
                i++;
            }
            else {               
                var index = s2[i] - 'a'; 
                if (previousSet[index] == null) {
                    previousSet[index] = new HashSet<char>();
                }
                previousSet[index].Add(s1[i]);
                break;
            }            
        }        
        if (i == min && s1.Length > s2.Length )
            return false; 
        
        var max = Math.Max(s1.Length, s2.Length);
        
        for (int j= i; j< max; j++) {
            if (j < s1.Length) charSet.Add(s1[j]);
            if (j < s2.Length) charSet.Add(s2[j]);
        }
        return true;
    } 
    
    public string AlienOrder(string[] words) {
        var valid = true; 
        if (words.Length == 1) {
            for (int i=0; i< words[0].Length; i++)
                charSet.Add(words[0][i]);
        }
        for (int i=0; i< words.Length; i++)
            for (int j=i+1; j< words.Length; j++) 
                valid &= Build(words[i], words[j]);        
        if (!valid)
            return "";         
        var ans = ""; 
        var visitedChars = new HashSet<char>();        
        while (ans.Length < charSet.Count) {
            var addingChar = ' ';            
            for (int i=0; i<26; i++) {
                var ch = (char)(i + 'a');
                if (charSet.Contains(ch) && !visitedChars.Contains(ch) && 
                    (previousSet[i] == null || previousSet[i].Count == 0))  {
                    
                    addingChar = ch;
                    break; 
                }
            }
            if (addingChar == ' ')
                return "";             
            ans += addingChar; 
            visitedChars.Add(addingChar);                        
            for (int i=0; i<26; i++) {
                if (previousSet[i] != null)
                    previousSet[i].Remove(addingChar);
            }
        }
        return ans; 
    }
}
  ```
  </details>
  

<details>
  <summary>Course Schedule II: https://leetcode.com/explore/learn/card/graph/622/single-source-shortest-path-algorithm/3866/</summary>
  
  ```cs
  public int[] FindOrder(int numCourses, int[][] prerequisites) {
        //this.numCourses = numCourses;
        var set = new HashSet<int>[numCourses];
        foreach (var prerequisite in prerequisites) {
            //a --> prerequisite[0]
            //b --> prerequisite[1]
            //take b then a
            var a = prerequisite[0];
            var b = prerequisite[1];
            if (set[a] == null) {
                set[a] = new HashSet<int>();                
            }
            set[a].Add(b);            
        }
        
        var planned = new HashSet<int>();
        var count = 0; 
        var ans = new int[numCourses];
        while (count < numCourses) {
            //Find a number which 
            //1. planned doesn't have it
            //2. Has set == null or set.Count = 0
            var courseNo = 0; 
            while (courseNo < numCourses 
                   && (planned.Contains(courseNo) || (set[courseNo] != null && set[courseNo].Count >0)))
                courseNo++; 
            
            //Cannot find the start point (loop)
            if (courseNo == numCourses)
                return new int[0];
            
            //Remove this course from other courses' prerequisite
            for (int i=0; i< numCourses; i++) {
                if (set[i] != null) {
                    set[i].Remove(courseNo);        
                }                    
            }             
            
            //Add this number to planned
            planned.Add(courseNo);            
            //Set ans and inscrease count
            ans[count] = courseNo;            
            count++;            
        }        
        return ans;
    }
  ```
  
</details>  
<details>
  <summary>Cheapest Flights Within K Stops: https://leetcode.com/explore/learn/card/graph/622/single-source-shortest-path-algorithm/3866/</summary>
  
  ```cs

    
    public int FindCheapestPrice(int n, int[][] flights, int src, int dst, int k) {
        
        //Concept: Using BFS to find 
        var graph = new int[n, n]; 
        foreach(var fl in flights) {
            graph[fl[0], fl[1]] = fl[2]; 
        }
        var minAns = int.MaxValue; 
        var queue = new Queue<(int, int)>(); 
        var visited = new Dictionary<int,int>(); //If a stop is visited, we only go to this stop again 
                                                        //if fly to there less than current
        queue.Enqueue((src, 0));        
        
        while (queue.Count > 0 && k > -1) {
            k--;//Reduce number of stop 
            var size = queue.Count;            
            for (int i=0; i<size; i++) {
                var currentStop = queue.Dequeue();
                var stop = currentStop.Item1;
                var val = currentStop.Item2;                
                visited[stop] = val;
                for (int j=0; j<n; j++) {
                    if (graph[stop, j] > 0) { //There is a flight from current stop to j
                        var nextVal = val + graph[stop, j];
                        if (j == dst) {
                            minAns = Math.Min(minAns, nextVal);
                        }
                        else if (nextVal < minAns 
                                 && (!visited.ContainsKey(j) || nextVal < visited[j])) { 
                                        //Fly to j if we have not fly there or value is cheaper 
                            queue.Enqueue((j, nextVal));
                        }                            
                    }
                }
            }             
        }       
        return minAns == int.MaxValue? - 1 : minAns;        
    }
    

  ```
  
</details>   

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
