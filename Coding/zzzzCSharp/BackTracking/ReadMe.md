<details>
<summary>Cracking the Safe: https://leetcode.com/problems/cracking-the-safe/description/</summary>

```cs
public class Solution {
    //There are k^n combines 
    //We have to make sure all k^n combination appear in the final string 
    //We will use a HashSet<string> to remember all combine 
    
    //Start with n '0' (For example, if n=4-> start with '0000')
    //Each time, we can append 1 character to the prefix and 1 character to the last
    //0'000' --> '000' + 1 --> 0001
    //'000'0 --> 1 + '000'
    //After this step, we have 3 combinations in the list: '0000', '0001' and '1000'    
    int n, k; 
    int noOfCombine; 
    HashSet<string> visited; 
    string finalAnswer = "";
    public string CrackSafe(int n, int k) {
        this.n = n; 
        this.k = k; 
        noOfCombine = (int)Math.Pow(k,n);
        var ans = "";
        for (int i=0; i<n; i++)
            ans += '0';
        visited = new HashSet<string>();
        visited.Add(ans);
        BackTrack(ans);        
        return finalAnswer;
    }
    
    bool BackTrack(string currentAns) {
        //Console.WriteLine(currentAns);
        if (visited.Count == noOfCombine){
            if (finalAnswer == "")
                finalAnswer = currentAns;
            return true; 
        }        
        var postfix = currentAns.Substring(0, n - 1);        
        for (int i=0; i< k; i++) {
            var newNum = string.Format("{0}{1}", i, postfix);
            if (!visited.Contains(newNum)) {
                visited.Add(newNum);                
                var ret = BackTrack(string.Format("{0}{1}", i, currentAns)); 
                if (ret) {
                    return ret;
                }
                visited.Remove(newNum);
            }
        }
        return false; 
    }
}
```

</details>

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
    
<details>
<summary>https://leetcode.com/problems/letter-combinations-of-a-phone-number/</summary>
    
Given a string containing digits from 2-9 inclusive, return all possible letter combinations that the number could represent. Return the answer in any order.

A mapping of digits to letters (just like on the telephone buttons) is given below. Note that 1 does not map to any letters.
    
<img alt="" src="https://assets.leetcode.com/uploads/2022/03/15/1200px-telephone-keypad2svg.png" style="width: 300px; height: 243px;">

```cs
Dictionary<char, string> dic;    
    public IList<string> LetterCombinations(string digits) {
        if (digits == null || digits == "") {
            return new List<string>();
        }        
        dic = new Dictionary<char, string>();        
        dic.Add('2',"abc");
        dic.Add('3',"def");
        dic.Add('4',"ghi");
        dic.Add('5',"jkl");
        dic.Add('6',"mno");
        dic.Add('7',"pqrs");
        dic.Add('8',"tuv");
        dic.Add('9',"wxyz");
        return Recursive(digits);   
    }
                
    IList<string> Recursive(string digit) {        
        if (digit == "") {
            return null;
        }
        var fistChar = digit[0];        
        var returnList = new List<string>();         
        var list = Recursive(digit.Substring(1));         
        foreach (var chr in dic[fistChar]) {
            if (list != null) {
                foreach (var str in list) 
                    returnList.Add(chr + str);
            }
            else 
                returnList.Add(chr.ToString());
        }         
        return returnList; 
    }
```
  
  
</details>    

    
<details>
<summary>https://leetcode.com/explore/learn/card/recursion-ii/507/beyond-recursion/2903/</summary>
    
Given an array nums of distinct integers, return all the possible permutations. You can return the answer in any order.

```cs
List<IList<int>> answers; 
public IList<IList<int>> Permute(int[] nums) {
    answers = new List<IList<int>>(); 
    var list = nums.ToList();
    var currList = new List<int>(); 
    Recur(currList, list);
    return answers;
}

void Recur(List<int> currList, List<int> remains) {
    if (remains.Count == 0) {     
        answers.Add(new List<int>(currList));
    }
    var size = remains.Count; 
    for (int i=0; i< size; i++) {
        var x = remains[i]; 
        currList.Add(x);
        remains.RemoveAt(i); 
        Recur(currList, remains);
        remains.Insert(i, x);   
        currList.RemoveAt(currList.Count -1);  
    }
}   
```
  
  
</details>
    
    
<details>
<summary>https://leetcode.com/explore/learn/card/recursion-ii/472/backtracking/2798/</summary>
    
Given two integers n and k, return all possible combinations of k numbers chosen from the range [1, n].

You may return the answer in any order.
```cs
int n; 
int k; 
IList<IList<int>> ans; 
IList<int> curr; 

public IList<IList<int>> Combine(int n, int k) {
    this.n = n; 
    this.k = k;
    ans = new List<IList<int>>();
    curr = new List<int>();        
    Generate(k, 0);        
    return ans;
}

void Generate(int k, int index) {
    if (k == 0) {
        var cloned = new List<int>(curr);
        ans.Add(cloned);            
        return;
    }

    for (int i=index + 1; i<=n; i++) {            
        curr.Add(i);
        Generate(k - 1, i);
        curr.RemoveAt(curr.Count -1);
    }        
}
```
  
  
</details>




<details>
<summary>https://leetcode.com/explore/learn/card/recursion-ii/472/backtracking/2796/</summary>
    
Write a program to solve a Sudoku puzzle by filling the empty cells.

```cs
char[][] board; 
List<(int,int)> pairs; //Missing positions need to be filled. 
public void SolveSudoku(char[][] board) {
    this.board = board; 
    //rows[i] to store items can be filled in rows[i]
    //cols[i] to store items can be filled in cols[i]
    Dictionary<int, HashSet<int>> rows = new Dictionary<int, HashSet<int>>();
    Dictionary<int, HashSet<int>> cols = new Dictionary<int, HashSet<int>>();
    Dictionary<int, HashSet<int>> squares = new Dictionary<int, HashSet<int>>();
    pairs = new List<(int,int)>();
    //Setup 
    for(int i=0; i< 9; i++)  {
        rows.Add(i, new HashSet<int>());
        cols.Add(i, new HashSet<int>());
        squares.Add(i, new HashSet<int>());            
        for (int j=0; j< 9; j++) {
            rows[i].Add(j + 1);
            cols[i].Add(j + 1);
            squares[i].Add(j + 1);
            if (board[i][j] == '.') {
                pairs.Add((i, j));
            }
        }            
        for (int j=0; j< 9; j++) {
            rows[i].Remove(board[i][j] - '0');
            cols[i].Remove(board[j][i] - '0');
        }
        var _row = i / 3; //0, 1, 2 --> 0. 3, 4, 5 --> 1, ..
        var _col = i % 3;             
        for (int k= _row * 3; k < (_row + 1) * 3; k++) {
            for (int l= _col * 3; l < (_col + 1) * 3; l++) {
                squares[i].Remove(board[k][l] - '0');
            }
        }
    }
    var clonedBoard = new char[9][]; 
    for (int i=0; i<9; i++) {
        clonedBoard[i] = new char[9]; 
        for (int j=0; j<9; j++) { 
            clonedBoard[i][j] = board[i][j];
        }            
    }        
    Fill(rows, cols, squares, clonedBoard);
}

void Fill(Dictionary<int, HashSet<int>> rows, 
          Dictionary<int, HashSet<int>> cols, 
          Dictionary<int, HashSet<int>> squares, 
          char[][] board) {
    if (pairs.Count == 0) {  
        for (int i=0; i<9; i++) {
            for (int j=0; j<9; j++) {
                this.board[i][j] = board[i][j];
            }
        }            
        return; 
    }        
    var pair = pairs[0]; //Get 1 pair at top
    int row = pair.Item1, col = pair.Item2; 
    var clonedItems = new HashSet<int>(rows[row]);        
    foreach(var item in clonedItems) {
        //Try to remove
        var square_index = (row / 3) * 3 + (col / 3); 
        if (cols[col].Contains(item) && squares[square_index].Contains(item)) {
            pairs.RemoveAt(0);
            rows[row].Remove(item);
            cols[col].Remove(item);
            squares[square_index].Remove(item);
            board[row][col] = (char)(item + '0');
            Fill(rows, cols, squares, board);
            board[row][col] = '.';
            squares[square_index].Add(item);
            cols[col].Add(item);
            rows[row].Add(item);
            pairs.Insert(0, pair);
        }
    }
}
```
  
  
</details>
    
 
<details>
    <summary>Combination Sum II: https://leetcode.com/problems/combination-sum-ii/description/ </summary>
    
```cs
public class Solution {
    int[] candidates; 
    List<IList<int>> ans; 
    int target;
    public IList<IList<int>> CombinationSum2(int[] candidates, int target) {        
        this.candidates = candidates; 
        this.target = target;
        Array.Sort(candidates);
        ans = new List<IList<int>>(); 
        BuildList(0, 0, new List<int>()); 
        return ans;
    }
    void BuildList(int curIdex, int curTotal, List<int> list) {        
         if (curTotal == target ) {             
             ans.Add(new List<int>(list));
             return;
         }
         for (int i = curIdex; i< candidates.Length; i++) {
             if ((i == curIdex || candidates[i] > candidates[i - 1]) //Reduce repeat by taking 1 numbers if there are many numbers the same values
                                                                    //For example: 1 1 2 5 5, target = 8: 2nd [1] and 2nd [5] will not be jumped in 
                    && curTotal + candidates[i] <= target) {
                list.Add(candidates[i]);
                BuildList(i + 1, curTotal + candidates[i], list);
                list.RemoveAt(list.Count - 1);
             }
         }        
    } 
}
```
</details>
