using System;
using System.Collections;
using System.Collections.Generic;

namespace BikovKP
{
    public class Clique
    {
        static Random random = null;

        public List<int> maxClique = new List<int>();
        public int powerClique = 0;
        public int n = 0;

        public Clique(int numberNodes, int numberEdges, bool[,] Matrix)
        {
            MyGraph graph = new MyGraph(numberNodes, numberEdges, Matrix);

            n = numberNodes;
            int maxTime = 1000; // use 20 for small demo file; use about 1,000-10,000 for benchmark problem.
            int targetCliqueSize = graph.NumberNodes; // max-clique size for any graph is the size of the graph -- graph is one giant clique.

            maxClique = FindMaxClique(graph, maxTime, targetCliqueSize);

            for (int i = 0; i < maxClique.Count; i++)
                maxClique[i]++;
            powerClique = maxClique.Count;
        }

        static List<int> FindMaxClique(MyGraph graph, int maxTime, int targetCliqueSize)
        {
            // you may want to coment-out WriteLine statements for large graphs.
            List<int> clique = new List<int>();
            random = new Random(1);
            int time = 0;
            int timeBestClique = 0;
            int timeRestart = 0;
            int nodeToAdd = -1;
            int nodeToDrop = -1;

            int randomNode = random.Next(0, graph.NumberNodes);
            Console.WriteLine("Adding node " + randomNode);
            clique.Add(randomNode);

            List<int> bestClique = new List<int>();
            bestClique.AddRange(clique);
            int bestSize = bestClique.Count;
            timeBestClique = time;

            List<int> possibleAdd = MakePossibleAdd(graph, clique); // nodes which will increase size of clique
            List<int> oneMissing = MakeOneMissing(graph, clique);

            while (time < maxTime && bestSize < targetCliqueSize)
            {
                ++time;

                bool cliqueChanged = false; // to control branching logic in loop
                if (possibleAdd.Count > 0) // 
                {
                    nodeToAdd = GetNodeToAdd(graph, possibleAdd); // node from possibleAdd which is most connected to nodes in possibleAdd
                    Console.WriteLine("Adding node " + nodeToAdd);
                    clique.Add(nodeToAdd);
                    clique.Sort();
                    cliqueChanged = true;
                    if (clique.Count > bestSize)
                    {
                        bestSize = clique.Count;
                        bestClique.Clear();
                        bestClique.AddRange(clique);
                        timeBestClique = time;
                    }
                } // add node

                if (cliqueChanged == false)
                {
                    if (clique.Count > 0)
                    {
                        nodeToDrop = GetNodeToDrop(graph, clique, oneMissing); // find node in clique which generate max increase in possibleAdd set. if more than one, pick one at random
                        Console.WriteLine("Dropping node " + nodeToDrop);
                        clique.Remove(nodeToDrop);
                        clique.Sort();
                        cliqueChanged = true;
                    }
                } // drop node

                int restart = 2 * bestSize;
                if (time - timeBestClique > restart && time - timeRestart > restart) // restart? if it's been a while since we found a new best clique or did a restart . . .
                {
                    Console.WriteLine("\nRestarting\n");
                    timeRestart = time;
                    int seedNode = random.Next(0, graph.NumberNodes);
                    clique.Clear();
                    Console.WriteLine("Adding node " + seedNode);
                    clique.Add(seedNode);
                } // restart

                possibleAdd = MakePossibleAdd(graph, clique);
                oneMissing = MakeOneMissing(graph, clique);
            }
            return bestClique;
        }
        
        #region
        static List<int> MakePossibleAdd(MyGraph graph, List<int> clique)
        {
            // create list of nodes in graph which are connected to all nodes in clique and therefore will form a larger clique
            // calls helper FormsALargerClique
            List<int> result = new List<int>();

            for (int i = 0; i < graph.NumberNodes; ++i) // each node in graph
            {
                if (FormsALargerClique(graph, clique, i) == true)
                    result.Add(i);
            }
            return result; // could be empty List
        }

        static bool FormsALargerClique(MyGraph graph, List<int> clique, int node)
        {
            // is node connected to all nodes in clique?
            for (int i = 0; i < clique.Count; ++i) // compare node against each member of clique
            {
                //if (clique[i] == node) return false; // node is aleady in clique so node will not form a larger clique
                if (graph.AreAdjacent(clique[i], node) == false) return false; // node is not connected to one of the nodes in the clique
            }
            return true; // passed all checks
        }

        static int GetNodeToAdd(MyGraph graph, List<int> possibleAdd)
        {
            // find node from a List of allowed and posible add which has max degree in posibleAdd
            // there could be more than one, if so, pick one at random
            //if (possibleAdd == null) throw new Exception("List possibleAdd is null in GetNodeToAdd");
            //if (possibleAdd.Count == 0) throw new Exception("List possibleAdd has Count 0 in GetNodeToAdd");

            if (possibleAdd.Count == 1) // there is only 1 node to choose from
                return possibleAdd[0];

            // examine each node in possibleAdd to find the max degree in possibleAdd (because there could be several nodes tied with max degree)
            int maxDegree = 0;
            for (int i = 0; i < possibleAdd.Count; ++i)
            {
                int currNode = possibleAdd[i];
                int degreeOfCurrentNode = 0;
                for (int j = 0; j < possibleAdd.Count; ++j) // check each node in possibleAdd
                {
                    int otherNode = possibleAdd[j];
                    if (graph.AreAdjacent(currNode, otherNode) == true) ++degreeOfCurrentNode;
                }
                if (degreeOfCurrentNode > maxDegree)
                    maxDegree = degreeOfCurrentNode;
            }

            // now rescan possibleAdd and grab all nodes which have maxDegree
            List<int> candidates = new List<int>();
            for (int i = 0; i < possibleAdd.Count; ++i)
            {
                int currNode = possibleAdd[i];
                int degreeOfCurrentNode = 0;
                for (int j = 0; j < possibleAdd.Count; ++j) // check each node in possibleAdd
                {
                    int otherNode = possibleAdd[j];
                    if (graph.AreAdjacent(currNode, otherNode) == true) ++degreeOfCurrentNode;
                }
                if (degreeOfCurrentNode == maxDegree)
                    candidates.Add(currNode);
            }

            //if (candidates.Count == 0) throw new Exception("candidates List has size 0 just before return in GetNodeToAdd");
            return candidates[random.Next(0, candidates.Count)]; // if candidates has Count 1 we'll get that one node
        }

        static int GetNodeToDrop(MyGraph graph, List<int> clique, List<int> oneMissing)
        {
            // get a node from clique set, which if dropped, gives the largest increase in PA set size
            // we use the oneMissingb set to determine which clique node to pick
            //if (clique == null) throw new Exception("clique is null in GetNodeToDrop");
            //if (clique.Count == 0) throw new Exception("clique has Count 0 in GetNodeToDrop");

            if (clique.Count == 1)
                return clique[0];

            // scan each node in clique and determine the max possibleAdd size if node removed
            int maxCount = 0; // see explanation below
            for (int i = 0; i < clique.Count; ++i) // each node in clique nodes List
            {
                int currCliqueNode = clique[i];
                int countNotAdjacent = 0;
                for (int j = 0; j < oneMissing.Count; ++j) // each node in the one missing list
                {
                    int currOneMissingNode = oneMissing[j];
                    if (graph.AreAdjacent(currCliqueNode, currOneMissingNode) == false) // we like this
                        ++countNotAdjacent;

                    // if currCliqueNode is not connected to omNode then currCliqueNode is the 'missing'
                    // it would be good to drop this cliqueNode because after dropped from clique
                    // the remaining nodes in the clique will all be connected to the omNode
                    // and so the omNode would become a posibleAdd node and increase PA set size
                    // So the best node to drop from clique will be the one which is least connected
                    // to the nodes in OM
                }

                if (countNotAdjacent > maxCount)
                    maxCount = countNotAdjacent;
            }

            // at this point we know what the max-not-connected count is but there could be several clique nodes which give that size
            List<int> candidates = new List<int>();
            for (int i = 0; i < clique.Count; ++i) // each node in clique
            {
                int currCliqueNode = clique[i];
                int countNotAdjacent = 0;
                for (int j = 0; j < oneMissing.Count; ++j) // each node in the one missing list
                {
                    int currOneMissingNode = oneMissing[j];
                    if (graph.AreAdjacent(currCliqueNode, currOneMissingNode) == false)
                        ++countNotAdjacent;
                }

                if (countNotAdjacent == maxCount) // cxurrent clique node has max count not connected
                    candidates.Add(currCliqueNode);
            }

            //if (candidates.Count == 0) throw new Exception("candidates List has size 0 just before return in GetNodeToDropFromAllowedInClique");
            return candidates[random.Next(0, candidates.Count)]; // must have size of at least 1

        }
        #endregion

        static List<int> MakeOneMissing(MyGraph graph, List<int> clique)
        {
            // make a list of nodes in graph which are connected to all but one of the nodes in clique
            int count; // number of nodes in clique which are connected to a candidate node. if final count == (clique size - 1) then candidate is a winner
            List<int> result = new List<int>();

            for (int i = 0; i < graph.NumberNodes; ++i) // each node in graph i a candidate
            {
                count = 0;
                if (graph.NumberNeighbors(i) < clique.Count - 1) continue; // node i has too few neighbors to possibly be connected to all but 1 node in clique
                                                                           //if (LinearSearch(clique, i) == true) continue; // node i is in clique. clique is not sorted so use LinearSearch -- consider Sort + BinarySearch
                if (clique.BinarySearch(i) >= 0) continue;
                for (int j = 0; j < clique.Count; ++j) // count how many nodes in clique are connected to candidate i
                {
                    if (graph.AreAdjacent(i, clique[j]))
                        ++count;
                }
                if (count == clique.Count - 1)
                    result.Add(i);
            } // each candidate node i
            return result;

        }

        public static string ListAsString(List<int> list)
        {
            string s = "";
            for (int i = 0; i < list.Count; ++i)
            {
                if (i % 10 == 0 && i > 0) s += Environment.NewLine;
                s += list[i] + " ";
            }

            s += Environment.NewLine;
            return s;
        }

        static void ValidateState(MyGraph graph, List<int> clique, List<int> possibleAdd, List<int> oneMissing)
        {
            // any duplicates in clique?
            for (int i = 0; i < clique.Count - 1; ++i)
            {
                for (int j = i + 1; j < clique.Count; ++j)
                {
                    if (clique[i] == clique[j])
                        throw new Exception("Dup value in clique");
                }
            }
            // any values in clique in possibleAdd or oneMissing?
            for (int i = 0; i < possibleAdd.Count; ++i)
            {
                if (clique.BinarySearch(possibleAdd[i]) >= 0)
                    throw new Exception("Possible Add value in clique");
            }
            for (int i = 0; i < oneMissing.Count; ++i)
            {
                if (clique.BinarySearch(oneMissing[i]) >= 0)
                    throw new Exception("One Missing value in clique");
            }
            // any values in possibleAdd in oneMissing?
            for (int i = 0; i < possibleAdd.Count; ++i)
            {
                if (oneMissing.Contains(possibleAdd[i]))
                    throw new Exception("Value in possibleAdd found in oneMissing");
            }
            for (int i = 0; i < oneMissing.Count; ++i)
            {
                if (possibleAdd.Contains(oneMissing[i]))
                    throw new Exception("Value in oneMissing found in possibleAdd");
            }
        }

        public override string ToString()
        {
            string allVertices = "";
            for (int i = 1; i <= n; i++)
                allVertices += i + " ";
            allVertices.Remove(allVertices.Length - 1);

            return "Підграф із вершинами " + ListAsString(maxClique) + " є максимально повним підграфoм у графі ["
                + allVertices + "] із потужністю " + powerClique;
        }
    }

    public class MyGraph
    {
        private BitMatrix data;
        private int numberNodes;
        private int numberEdges;
        private int[] numberNeighbors;

        public MyGraph(int numberNodes, int numberEdges, bool[,] Matrix)
        {
            this.data = new BitMatrix(numberNodes);

            int length = numberNodes;
            int startIndex = 1;
            for (int i = 0; i < (length - 1); i++)
            {
                for (int j = startIndex; j < length; j++)
                {
                    if (Matrix[i, j] == true)
                    {
                        data.SetValue(i, j, true);
                        data.SetValue(j, i, true);
                    }
                }
                startIndex++;
            }

            this.numberNeighbors = new int[numberNodes];
            for (int row = 0; row < numberNodes; ++row)
            {
                int count = 0;
                for (int col = 0; col < numberNodes; ++col)
                {
                    if (data.GetValue(row, col) == true)
                        ++count;
                }
                numberNeighbors[row] = count;
            }

            this.numberNodes = numberNodes;
            this.numberEdges = numberEdges;
        }
        
        public int NumberNodes
        {
            get { return this.numberNodes; }
        }

        public int NumberEdges
        {
            get { return this.numberEdges; }
        }

        public int NumberNeighbors(int node)
        {
            return numberNeighbors[node];
        }

        public bool AreAdjacent(int nodeA, int nodeB)
        {
            return data.GetValue(nodeA, nodeB);
        }

        public override string ToString()
        {
            string s = "";
            for (int i = 0; i < this.data.Dim; ++i)
            {
                s += i + ": ";
                for (int j = 0; j < this.data.Dim; ++j)
                {
                    if (this.data.GetValue(i, j) == true)
                        s += j + " ";
                }
                s += Environment.NewLine;
            }
            return s;
        }
           
        private class BitMatrix
        {
            private BitArray[] data;
            public readonly int Dim;

            public BitMatrix(int n)
            {
                this.data = new BitArray[n];
                for (int i = 0; i < data.Length; ++i)
                {
                    data[i] = new BitArray(n);
                }
                this.Dim = n;
            }
            public bool GetValue(int row, int col)
            {
                return data[row][col];
            }
            public void SetValue(int row, int col, bool value)
            {
                data[row][col] = value;
            }
            public override string ToString()
            {
                string s = "";
                for (int i = 0; i < data.Length; ++i)
                {
                    for (int j = 0; j < data[i].Length; ++j)
                    {
                        if (data[i][j] == true) s += "1 "; else s += "0 ";
                    }
                    s += Environment.NewLine;
                }
                return s;
            }
        }
    }
}
