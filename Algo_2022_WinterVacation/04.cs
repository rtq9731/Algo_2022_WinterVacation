using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace Algo_2022_WinterVacation
{

    class _04
    {
        //class TreeNode
        //{
        //    public int num;
        //    public int data;
        //    public TreeNode left;
        //    public TreeNode right;

        //    public bool CanSetNode(TreeNode node, TreeNode parentNode)
        //    {
        //        if(parentNode.data <= node.data)
        //        {

        //        }

        //        if (parentNode.left == null) // 없다
        //        {
        //            parentNode.left = node; // 왼쪽부터 배치
        //            return true;
        //        }
        //        else if (parentNode.right == null) // 오른쪽이 없으면
        //        {

        //            parentNode.right = node; // 오른쪽에 배치
        //            return true;
        //        }

        //        else // 양쪽 둘다 차있으면 왼쪽 아래로 내려가서 또 검사
        //        {
        //            if (parentNode.CanSetNode(node, parentNode.left)) // 왼쪽으로 내려가서 확인
        //            {
        //                return true;
        //            }
        //            else // 왼쪽 안되면 오른쪽 검사
        //            {
        //                return parentNode.CanSetNode(node, parentNode.right);
        //            }
        //        }
        //    }
        //}

        //class Tree
        //{
        //    static List<TreeNode> nodeList = new List<TreeNode>();
        //    static TreeNode rootNode;
        //    static TreeNode nextPos;

        //    public void MakeNode(int data)
        //    {
        //        TreeNode curTreeNode = new TreeNode() { num = treeNum, data = data };
        //        if (nodeList.Count > 0)
        //        {
        //            rootNode = curTreeNode;
        //            nodeList.Add(curTreeNode);
        //        }
        //        else
        //        {
        //            TreeNode rootNode = nodeList.Find(x => x.num == 0); // 루트 노드 찾기

        //            if(rootNode.data <= curTreeNode.data) // 만약에 루트노드가 작다면
        //            {
        //                TreeNode temp = rootNode;

        //            }

        //        }
        //    }
        //}

        //static int treeNum = 0;
        //static List<TreeNode> nodeList = new List<TreeNode>();

        class TreeNode<T>
        {
            public T data;
            public TreeNode<T> left;
            public TreeNode<T> right;

            public bool CheckFullChild()
            {
                return (left != null && right != null);
            }
        }

        class BinaryTree<T>
        {
            public TreeNode<T> rootNode = null;
            List<TreeNode<T>> nodes = new List<TreeNode<T>>();

            public void AddNode(TreeNode<T> node)
            {
                if (rootNode == null)
                {
                    rootNode = node;
                }
                else
                {
                    AddNodeToTree(TreeNode<T>, node);
                }
                nodes.Add(node);
            }

            public void PreOrderTraversal(TreeNode<T> node)
            {
                if (node == null) return;

                Console.WriteLine(node.data);
                PreOrderTraversal(node.left);
                PreOrderTraversal(node.right);
            }

            private void AddNodeToTree(TreeNode<T> parent, TreeNode<T> curNode)
            {

                if (parent.left == null) // 만약 부모의 왼쪽이 비어있다면
                {
                    parent.left = curNode;
                }
                else if (parent.right == null) // 오른쪽이 비어있다면
                {
                    parent.right = curNode;
                }
                else // 양쪽 다 차있으면
                {
                    if (!parent.left.CheckFullChild()) // 만약 왼쪽의 자식 자리가 비어있으면
                    {
                        AddNodeToTree(parent.left, curNode);
                    }
                    else if (!parent.right.CheckFullChild())// 아니면
                    {
                        AddNodeToTree(parent.right, curNode);
                    }
                    else // 만약 양쪽 다 자식이 안 비어있으면
                    {
                        AddNodeToTree(parent.left, curNode);
                    }
                }
            }
        }

        static void Main(string[] args)
        {
            BinaryTree<int> tree = new BinaryTree<int>();
            tree.AddNode(new TreeNode<int>() { data = 10 });
            tree.AddNode(new TreeNode<int>() { data = 20 });
            tree.AddNode(new TreeNode<int>() { data = 30 });
            tree.AddNode(new TreeNode<int>() { data = 40 });
            tree.AddNode(new TreeNode<int>() { data = 50 });
            tree.AddNode(new TreeNode<int>() { data = 60 });
            tree.AddNode(new TreeNode<int>() { data = 70 });
            //tree.AddNode(new TreeNode<int>() { data = 80 });
            //tree.AddNode(new TreeNode<int>() { data = 90 });
            //tree.AddNode(new TreeNode<int>() { data = 100 });
            //tree.AddNode(new TreeNode<int>() { data = 110 });
            //tree.AddNode(new TreeNode<int>() { data = 120 });
            //tree.AddNode(new TreeNode<int>() { data = 130 });
            //tree.AddNode(new TreeNode<int>() { data = 140 });
            //tree.AddNode(new TreeNode<int>() { data = 150 });
            tree.PreOrderTraversal(tree.rootNode);
        }
    }
}
