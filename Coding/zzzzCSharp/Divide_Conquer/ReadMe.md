<details>
<summary>https://leetcode.com/problems/search-a-2d-matrix-ii</summary>
  
 ```cs
 public bool SearchMatrix(int[][] matrix, int target) {
    int row = 0; 
    int col = matrix[0].Length - 1;         
    while (row < matrix.Length && col >= 0) {
        if (matrix[row][col] > target) {
            col--; 
        }
        else if (matrix[row][col] < target) {
            row++; 
        }
        else {
            return true;
        }
    }        
    return false;
}   
 ```
  
</details>
