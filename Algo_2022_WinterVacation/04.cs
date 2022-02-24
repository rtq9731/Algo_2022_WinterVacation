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

        class TreeNode<T> : IComparable
        {
            public int priority = 0;
            public T data;
            public TreeNode<T> left;
            public TreeNode<T> right;

            public int CompareTo(object obj)
            {
                return (obj as TreeNode<T>).priority.CompareTo(priority);
            }
        }

        class PriorityQueue<T>
        {
            public TreeNode<T> rootNode = null;
            List<List<TreeNode<T>>> nodes = new List<List<TreeNode<T>>>();

            int curLevel = 0;

            public void PreOrderTraversal(TreeNode<T> node)
            {
                if (node == null) return;

                Console.WriteLine(node.data);
                PreOrderTraversal(node.left);
                PreOrderTraversal(node.right);
            }

            public void PrintAll()
            {
                for (int level = 0; level < curLevel; level++)
                {
                    for (int nodeNum = 0; nodeNum < nodes[level].Count; nodeNum++)
                    {
                        Console.Write(" " + nodes[level][nodeNum].data + " ");
                    }
                    Console.WriteLine();
                }
            }

            public void Enqueue(TreeNode<T> node, int priority)
            {
                node.priority = priority;

                if (curLevel > 0) // 우선 루트가 아니면
                {
                    if(nodes.Count < curLevel + 1)
                    {
                        nodes.Add(new List<TreeNode<T>>());
                    }

                    if(nodes[curLevel].Count >= GetSqureNum(2, curLevel)) // 현재 레벨이 최고 개수라면 아래 레벨로
                    {
                        curLevel++;
                        Enqueue(node, priority);
                    }
                    else // 아니라면 그냥 지금 레벨에
                    {
                        nodes[curLevel].Add(node);  
                    }
                }
                else
                {
                    rootNode = node;
                    nodes.Add(new List<TreeNode<T>>() { node });
                    curLevel++;
                }
            }
            
            /// <summary>
            /// 맨위의 출력합니다.
            /// </summary>
            /// <returns></returns>
            public TreeNode<T> Dequeue()
            {
                TreeNode<T> result = nodes[0][0];
                nodes[0].Remove(result);

                List<TreeNode<T>> tempList = GetAllNodes();
                nodes.Clear();
                curLevel = 0;
                tempList.ForEach(x => Enqueue(x, x.priority));
                MakeTree();

                return result;
            }

            private List<TreeNode<T>> GetAllNodes()
            {
                List<TreeNode<T>> result = new List<TreeNode<T>>();
                
                nodes.ForEach(item =>
                {
                    item.ForEach(item =>
                    {
                        result.Add(item);
                    });
                });

                return result;
            }

            public void MakeTree()
            {

                if (nodes[0][0] != null)
                {
                    for (int level = 1; level < curLevel + 1; level++) // curLevel은 0부터 시작했으니까 이렇게 쓰려면 1 더해야함 / 그리고 0은 스킵
                    {
                        for (int nodeNum = 0; nodeNum < nodes[level].Count; nodeNum++)
                        {
                            if(nodeNum % 2 == 0)
                            {
                                nodes[level - 1][nodeNum / 2].left = nodes[level][nodeNum];
                            }
                            else
                            {
                                nodes[level - 1][nodeNum / 2].right = nodes[level][nodeNum];
                            }
                        }
                    }
                }
            }

            private int GetSqureNum(int num, int count)
            {
                int result = num;

                for (int i = 0; i < count - 1; i++)
                {
                    result *= num;
                }

                return result;
            }
        }

        static void Main(string[] args)
        {
            PriorityQueue<int> queue = new PriorityQueue<int>();
            queue.Enqueue(new TreeNode<int>() { data = 10 }, 1);
            queue.Enqueue(new TreeNode<int>() { data = 20 }, 2);
            queue.Enqueue(new TreeNode<int>() { data = 30 }, 3);
            queue.Enqueue(new TreeNode<int>() { data = 40 }, 4);
            queue.Enqueue(new TreeNode<int>() { data = 50 }, 5);
            queue.Enqueue(new TreeNode<int>() { data = 60 }, 6);
            queue.Enqueue(new TreeNode<int>() { data = 70 }, 7);
            queue.Enqueue(new TreeNode<int>() { data = 80 }, 8);
            queue.Enqueue(new TreeNode<int>() { data = 90 }, 9);
            queue.Enqueue(new TreeNode<int>() { data = 100 }, 10);
            queue.Enqueue(new TreeNode<int>() { data = 110 }, 11);
            queue.Enqueue(new TreeNode<int>() { data = 120 }, 12);
            queue.Enqueue(new TreeNode<int>() { data = 130 }, 13);
            queue.Enqueue(new TreeNode<int>() { data = 140 }, 14);
            queue.Enqueue(new TreeNode<int>() { data = 150 }, 15);
            queue.MakeTree();
            queue.PrintAll();
            Console.WriteLine(queue.Dequeue().data);
            queue.PrintAll();
            // queue.PrintAll();
        }
    }
}
