<details>
<summary>https://leetcode.com/problems/n-queens-ii/</summary>
    
The n-queens puzzle is the problem of placing n queens on an n x n chessboard such that no two queens attack each other.

Given an integer n, return the number of distinct solutions to the n-queens puzzle.
```cs
public int TotalNQueens(int n) {
    if (n == 1) 
        return 1; 
    else if (n == 2 || n == 3)
        return 0;
    return BackTrack(0, new HashSet<int>(), new HashSet<int>(), new HashSet<int>(), n);
}

int BackTrack(int row, HashSet<int> cols,  HashSet<int> diag1, HashSet<int> diag2, int n) {
    if (row == n)
        return 1;
    int sum =0; 
    for (var j = 0; j< n; j++) {
        var dResult1 = row - j; 
        var dResult2 = row + j;
        if (!cols.Contains(j) && !diag1.Contains(dResult1) && !diag2.Contains(dResult2)) {
            cols.Add(j);
            diag1.Add(dResult1);
            diag2.Add(dResult2);                
            sum += BackTrack(row + 1, cols, diag1, diag2, n);                
            cols.Remove(j);
            diag1.Remove(dResult1);
            diag2.Remove(dResult2);                
        }
    }
    return sum;
}
```
  
  
</details>
