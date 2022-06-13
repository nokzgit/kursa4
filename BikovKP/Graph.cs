using System;
using System.Collections.Generic;

namespace BikovKP
{
    public class Graph
    {
        private bool[,] _Matrix;
        private int[] _FI;

        public bool[,] Matrix { get { return _Matrix; } }
        public int[] FI { get { return _FI; } }
        
        public int PowerClique;
        public List<int> Clique = new List<int>();
        public string SummaryOfGraph = "";

        public Graph(int[] FI)
        {
            if (!CheckFI(FI))
                throw new Exception("Некоректний формат представлення даних FI");
            _Matrix = MakeMatrix(FI);
            _FI = FI;

            Clique c = new Clique(CalculateNodes(_FI), getNumberEdges(_FI), _Matrix);
            Clique = c.maxClique;
            PowerClique = c.powerClique;
            SummaryOfGraph = c.ToString();
        }

        public static bool CheckFI(int[] FI)
        {
            {
                if (FI == null)
                    return false;
                int n = CalculateNodes(FI);
                for (int i = 0; i < FI.Length; i++)
                {
                    if (FI[i] > n)
                        return false;
                    if (FI[i] < 0)
                        return false;
                }
            }

            bool[,] matrix = MakeMatrix(FI);

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] == true)
                    {
                        if (matrix[j, i] != true)
                            return false;
                    }
                }
            }
            return true;
        }

        public static bool[,] MakeMatrix(int[] FI)
        {
            int n = CalculateNodes(FI);
            bool[,] matrix = new bool[n, n];
            int edge = 0;

            for (int i = 0; i < FI.Length; i++)
            {
                if(FI[i] != 0)
                    matrix[edge, FI[i] - 1] = true;
                else
                    edge++;
            }
            return matrix;
        }        

        public static int CalculateEdge(bool[,] Matrix){
            int count = 0;
            for(int i = 0; i < Matrix.GetLength(0); i++)
                for(int j = 0; j < Matrix.GetLength(1); j++)
                    if (Matrix[i, j] == true)
                        count++;
            return count;
        }

        public static int CalculateNodes(int[] FI)
        {
            int counter = 0;
            for (int i = 0; i < FI.Length; i++)
                if (FI[i] == 0)
                    counter++;
            return counter;
        }

        public static int[] MakeFI(bool[,] Matrix)
        {
            int n = Matrix.GetLength(0);
            int edge = CalculateEdge(Matrix) / 2;
            int[] FI = new int[(edge * 2) + n];
            for (int i = 0, counter = 0; i < Matrix.GetLength(0); i++)
            {
                for (int j = 0; j < Matrix.GetLength(1); j++)
                {
                    if (Matrix[i, j] == true)
                    {
                        if(Matrix[j, i] != true)
                            throw new Exception("Помилка у матриці сумісності");
                        FI[counter] = j + 1;
                        counter++;
                    }
                }
                FI[counter] = 0;
                counter++;
            }
            return FI;
        }

        public static bool[,] GenRandomGraph(int Vertices, int Edges)
        {
            bool[,] mas = new bool[Vertices, Vertices];

            for (int i = 0; i < Vertices; i++)//Предварительное заполнение матрици
                for (int j = 0; j < Vertices; j++)
                    mas[i, j] = false;

            Random rnd = new Random();
            int counter = 0;

            while (counter < Edges)//Добавление количества ребер если их недостаточно
            {
                var i = rnd.Next(0, Vertices);
                var j = rnd.Next(0, Vertices);
                if (i != j)
                    if (mas[i, j] == false)
                    {
                        mas[i, j] = true;
                        mas[j, i] = true;
                        counter++;
                    }
            }

            return mas;
        }

        public static int getNumberEdges(int[] FI)
        {
            int counter = 0;
            for(int i = 0; i < FI.Length; i++)
            {
                if (FI[i] != 0)
                    counter++;
            }
            return counter / 2;
        }
    }
}
