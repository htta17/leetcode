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
