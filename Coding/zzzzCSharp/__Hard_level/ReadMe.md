<details>
  <summary> https://leetcode.com/problems/longest-increasing-path-in-a-matrix </summary>
  
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
    //From position X, Y, we find all up, down, left, right position
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
  <summary> https://leetcode.com/problems/minimum-window-subsequence/ </summary>
  
```cs
public class Solution {
    public string MinWindow(string s1, string s2) {
        //Use dynamic programming
        //(i,j): Find match string with s1 from 0--> i and s2 from 0-->j        
        var len1 = s1.Length; 
        var len2 = s2.Length;
        var memo = new int[len1,len2];
        var pos = new int[len1,len2];
        for (int i=0; i< len1; i++) {             
            for (int j=0; j< len2; j++) { 
                memo [i,j] = -1; 
                pos[i,j] = -1; 
            }
        } 
        if (s1[0] == s2[0]) {
            memo[0,0] =  1; 
            pos[0,0] = 0;
        }        
        for (int i=1; i< len1; i++) {
            if (s1[i] == s2[0]) {
                memo[i, 0] = 1; 
                pos[i,0] = i; 
            }
            else {
                memo[i, 0] = memo[i-1, 0]; 
                pos[i,0] = pos[i-1, 0];
            }
        }
        for (int i=1; i< len1; i++) {             
            for (int j=1; j< len2; j++) {
                if (s1[i] == s2[j]) {
                    memo[i,j] = memo[i -1, j-1] + 1; 
                    pos[i,j] = pos[i-1, j-1]; 
                }
                else {
                    memo[i,j] = memo[i-1, j ];
                    pos[i,j] = pos[i-1, j]; 
                }
            }
        }       
        var minLen = int.MaxValue;
        var ans = ""; 
        for (int i=0; i< len1; i++) {           
            var left = pos[i, len2 - 1];   
            if (memo[i, len2 -1] == len2 && minLen > i - left) {                
                minLen = i - left; 
                ans = s1.Substring(left, i - left + 1);
            }
        }
        return ans;  
    }
}
```
</details>

