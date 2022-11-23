- Given a binary search tree (BST), find the lowest common ancestor (LCA) node of two given nodes in the BST. <br/>
- https://leetcode.com/problems/lowest-common-ancestor-of-a-binary-search-tree/description/
```cs
public TreeNode LowestCommonAncestor(TreeNode node, TreeNode p, TreeNode q) {
      if (node == null)
          return null; 
      var leftResult = LowestCommonAncestor(node.left, p, q); 
      var rightResult = LowestCommonAncestor(node.right, p, q); 
      if (node == p || node == q || (leftResult != null && rightResult != null)) {
          return node; 
      }
      else if (leftResult != null) {
          return leftResult;
      }
      else if (rightResult != null) {
          return rightResult;
      }
      return null;
  }
```
