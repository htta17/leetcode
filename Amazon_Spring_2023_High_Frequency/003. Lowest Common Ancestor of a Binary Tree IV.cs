//https://leetcode.com/problems/lowest-common-ancestor-of-a-binary-tree-iv/description/?envType=study-plan-v2&envId=amazon-spring-23-high-frequency 

/**
 * Definition for a binary tree node.
 * public class TreeNode {
 *     public int val;
 *     public TreeNode left;
 *     public TreeNode right;
 *     public TreeNode(int x) { val = x; }
 * }
 */
public class Solution {
    public TreeNode LowestCommonAncestor(TreeNode root, TreeNode[] nodes) {
        var set = new HashSet<int>();
        foreach(var node in nodes) {
            set.Add(node.val);
        }

        var loop = CountSeenNode(root, set);

        return ans;
    }

    TreeNode ans = null; 

    int CountSeenNode(TreeNode node, HashSet<int> set) {
        if (node == null || ans != null) {
            return 0; 
        }
        var count = (set.Contains(node.val) ? 1 : 0)  + CountSeenNode(node.left, set) + CountSeenNode(node.right, set) ; 

        if (count == set.Count && ans == null) {
            ans = node;            
        }

        return count; 
    }
}
