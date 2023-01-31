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
        var count = 0;        
        while(queue.Count > 0) {
            var size = queue.Count; 
            count++; 
            for (int i=0; i< size; i++) {
                var word = queue.Dequeue(); 
                var neighbors = GetWordNeighbor(word);
                foreach(var neighbor in neighbors) {
                    wordSet.Remove(neighbor);
                    if (neighbor == endWord) 
                        return count + 1;
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
