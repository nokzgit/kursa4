using System;
using System.Collections.Generic;
using BikovKP;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTest
{
    [TestClass]
    public class UnitTest
    {
        private readonly bool[,] matrix_5x5_correct = new bool[,]
        {
            { false, false, true,  true,  true},
            { false, false, false, false, true},
            { true,  false, false, false, true},
            { true,  false, false, false, true},
            { true,  true,  true,  true,  false}
        };

        private readonly bool[,] matrix_5x5_incorrect = new bool[,]
        {
            { false, true,  true,  false, false},
            { true,  false, true,  true,  false},
            { true,  false, false, false, true},
            { false, true,  true,  false, false},
            { true,  false, false, true,  false}
        };

        private readonly int[] FI_correct = Array.ConvertAll("0 4 11 0 5 6 14 0 2 5 0 3 4 13 0 3 9 12 13 14 0 9 0 12 13 0 6 7 0 14 0 2 13 0 6 8 13 0 5 6 8 11 12 0 3 6 10 0".Split(' '), int.Parse);
        private readonly int[] FI_incorrect_minus = Array.ConvertAll("2 3 4 0 1 0 1 -4 0 1 3 0".Split(' '), int.Parse);
        private readonly int[] FI_incorrect = Array.ConvertAll("2 5 0 1 3 4 5 0 2 4 0 2 3 6 0 1 2 4 0".Split(' '), int.Parse);
        private readonly int[] FI_over_first = Array.ConvertAll("12 0 0 0 5 14 0 0 2 3 0 0 14 0 7 0 8 0 0 4 5 0 0 13 15 0 10 0".Split(' '), int.Parse);
        private readonly int[] FI_null = null;
        private readonly int[] FI_additional_number_of_adge = Array.ConvertAll("3 4 5 0 4 5 0 1 2 4 5 0 1 2 3 5 0 1 2 3 4 0".Split(' '), int.Parse);

        [TestMethod]
        public void check_correct_Matrix_FI_test()
        {
            int[] FI = Graph.MakeFI(matrix_5x5_correct);
            Assert.AreEqual(true, Graph.CheckFI(FI));
        }
        [TestMethod]
        public void check_incorrect_Matrix_FI_test()
        {
            try
            {
                int[] FI = Graph.MakeFI(matrix_5x5_incorrect);
            }
            catch
            {
                Assert.IsTrue(true);
            }
        }
        [TestMethod]
        public void check_correct__FI_test()
        {
            Assert.AreEqual(true, Graph.CheckFI(FI_correct));
        }
        [TestMethod]
        public void check_incorrect_FI_test()
        {
            Assert.AreEqual(false, Graph.CheckFI(FI_incorrect));
        }
        [TestMethod]
        public void check_incorrect_minus_FI_test()
        {
            Assert.AreEqual(false, Graph.CheckFI(FI_incorrect_minus));
        }
        [TestMethod]
        public void check_over_first_element_FI_test()
        {
            Assert.AreEqual(false, Graph.CheckFI(FI_over_first));
        }
        [TestMethod]
        public void check_nulled_graph_FI_test()
        {
            Assert.AreEqual(false, Graph.CheckFI(FI_null));
        }
        [TestMethod]
        public void check_additional_number_of_adge_FI_test()
        {
            Assert.AreEqual(false, Graph.CheckFI(FI_additional_number_of_adge));
        }

        [TestMethod]
        public void check_generation_random_graph()
        {
            bool[,] matrix = Graph.GenRandomGraph(7, 11);
            int[] FI = Graph.MakeFI(matrix);
            Assert.AreEqual(true, Graph.CheckFI(FI));
        }

        int[] FI_p3_1 = Array.ConvertAll("3 4 5 0 3 4 5 0 1 2 4 5 0 1 2 3 0 1 2 3 0".Split(' '), int.Parse);
        int[] FI_p3_2 = Array.ConvertAll("3 5 0 4 6 7 0 1 4 5 0 2 3 5 6 7 0 1 3 4 6 7 0 2 4 5 0 2 4 5 0".Split(' '), int.Parse);
        int[] FI_p3_3 = Array.ConvertAll("2 5 6 0 1 4 5 6 0 4 5 6 0 2 3 5 0 1 2 3 4 0 1 2 3 0".Split(' '), int.Parse);
        int[] FI_p3_4 = Array.ConvertAll("2 4 0 1 4 0 4 0 1 2 3 0".Split(' '), int.Parse);
        int[] FI_p4_5 = Array.ConvertAll("4 5 6 0 3 4 5 0 2 4 5 0 1 2 3 5 6 0 1 2 3 4 0 1 4 0".Split(' '), int.Parse);
        int[] FI_p4_6 = Array.ConvertAll("2 4 0 1 5 7 8 0 4 6 8 0 1 3 6 8 0 2 6 0 3 4 5 8 0 2 0 2 3 4 6 0".Split(' '), int.Parse);

        bool compareGraphs(List<Graph> graphs)
        {
            int powerClique = graphs[0].PowerClique;
            foreach (Graph graph in graphs)
                if (powerClique != graph.PowerClique)
                    return false;
            return true;
        }

        [TestMethod]
        public void equivalent_2_graphs()
        {
            List<Graph> graphs = new List<Graph>();

            graphs.Add(new Graph(FI_p3_1));
            graphs.Add(new Graph(FI_p3_2));

            bool isEquivalent = compareGraphs(graphs);
            Assert.IsTrue(isEquivalent);
        }
        [TestMethod]
        public void equivalent_4_graphs()
        {
            List<Graph> graphs = new List<Graph>();

            graphs.Add(new Graph(FI_p3_1));
            graphs.Add(new Graph(FI_p3_2));
            graphs.Add(new Graph(FI_p3_3));
            graphs.Add(new Graph(FI_p3_4));

            bool isEquivalent = compareGraphs(graphs);
            Assert.IsTrue(isEquivalent);
        }
        [TestMethod]
        public void not_equivalent_2_graphs()
        {
            List<Graph> graphs = new List<Graph>();

            graphs.Add(new Graph(FI_p3_4));
            graphs.Add(new Graph(FI_p4_6));

            bool isEquivalent = compareGraphs(graphs);
            Assert.IsFalse(isEquivalent);
        }
        [TestMethod]
        public void not_equivalent_4_graphs()
        {
            List<Graph> graphs = new List<Graph>();

            graphs.Add(new Graph(FI_p3_1));
            graphs.Add(new Graph(FI_p4_5));
            graphs.Add(new Graph(FI_p3_3));
            graphs.Add(new Graph(FI_p3_4));

            bool isEquivalent = compareGraphs(graphs);
            Assert.IsFalse(isEquivalent);
        }
    }
}
