<details>
<summary>Given a binary search tree (BST), find the lowest common ancestor (LCA) node of two given nodes in the BST</summary>
https://leetcode.com/problems/lowest-common-ancestor-of-a-binary-search-tree/description

```cs
public TreeNode LowestCommonAncestor(TreeNode node, TreeNode p, TreeNode q) {
      //LCA is a node which:  
      //   - Itself is p (q), and left node or right node has q (or p)
      //   - A node which has leftNode is p (q) and rightNode is q (p)
   
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
</details>

<details>
      <summary>Flip Equivalent Binary Trees: https://leetcode.com/explore/interview/card/google/61/trees-and-graphs/3077/ </summary> 

```cs
public bool FlipEquiv(TreeNode root1, TreeNode root2) {
  if (root1 == null && root2 == null)
      return true;
  else if (root1 == null || root2 == null)
      return false;
  return root1.val == root2.val && 
          ((FlipEquiv(root1.left, root2.left) && FlipEquiv(root1.right, root2.right))
          || (FlipEquiv(root1.left, root2.right) && FlipEquiv(root1.right, root2.left)));
}
```
</details>
