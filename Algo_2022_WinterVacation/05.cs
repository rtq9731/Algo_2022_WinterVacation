using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace Algo_2022_WinterVacation
{
    class _05
    {
        class DijkstraNode
        {
            public string name;
            public Dictionary<DijkstraNode, int> linkedNodeDict = new Dictionary<DijkstraNode, int>(); // 거리를 담은 Dict

            //public int GetDistance(DijkstraNode goal)
            //{
            //    if(linkedNodeDict.ContainsKey(goal))
            //    {
            //        return linkedNodeDict[goal];
            //    }
            //    return -1;
            //}
        }

        class DijkstraAssistant
        {
            Stack<DijkstraNode> trace = new Stack<DijkstraNode>();
            List<DijkstraNode> checkedNodes = new List<DijkstraNode>();

            int dist = 0;

            public bool FindRoad(DijkstraNode start, DijkstraNode goal)
            {
                trace.Push(start);

                while (start != goal)
                {
                    var temp = from node in start.linkedNodeDict
                               orderby node.Value
                               where trace.Peek() != node.Key
                               select node;

                    var list = temp.ToList();

                    if(list.Count < 1)
                    {
                        return false;
                    }

                    for (int i = 0; i < list.Count(); i++) // 연결 되있는 걸 다 살펴봄
                    {
                        if (list[i].Key.linkedNodeDict.Count > 0) // 만약 다음 노드에도 연결지점이 있으면 들어감
                        {
                            FindRoad(list[i].Key, goal);
                        }
                    }
                }

                return true;
            }
        }

        static void Main(string[] args)
        {
            DijkstraAssistant assistant = new DijkstraAssistant();

            Dictionary<string, DijkstraNode> nodeDict = new Dictionary<string, DijkstraNode>()
            {
                { "A", new DijkstraNode() { name = "A" } },
                { "B", new DijkstraNode() { name = "B" } },
                { "C", new DijkstraNode() { name = "C" } },
                { "D", new DijkstraNode() { name = "D" } },
                { "E", new DijkstraNode() { name = "E" } },
                { "F", new DijkstraNode() { name = "F" } },
                { "G", new DijkstraNode() { name = "G" } },
            };

            nodeDict["A"].linkedNodeDict.Add(nodeDict["B"], 10);
            nodeDict["A"].linkedNodeDict.Add(nodeDict["C"], 5);
            nodeDict["A"].linkedNodeDict.Add(nodeDict["D"], 15);

            nodeDict["B"].linkedNodeDict.Add(nodeDict["A"], 10);
            nodeDict["B"].linkedNodeDict.Add(nodeDict["F"], 5);

            nodeDict["C"].linkedNodeDict.Add(nodeDict["A"], 5);
            nodeDict["C"].linkedNodeDict.Add(nodeDict["E"], 15);

            nodeDict["E"].linkedNodeDict.Add(nodeDict["C"], 15);
            nodeDict["E"].linkedNodeDict.Add(nodeDict["G"], 10);

            nodeDict["F"].linkedNodeDict.Add(nodeDict["B"], 5);
            nodeDict["F"].linkedNodeDict.Add(nodeDict["G"], 7);

            assistant.FindRoad(nodeDict["A"], nodeDict["G"]);
        }

    }
}
