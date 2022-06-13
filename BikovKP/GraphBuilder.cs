using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace BikovKP
{
    class GraphBuilder
    {
        private PointF[] pointsForVerticles;//координаты для построения вершин
        private PictureBox region;//Область для рисования графа
        private Graphics graphics;//предоставление средств для рисования
        private readonly Bitmap bitmap;//хранение полного изображения графа
        private readonly Font font;//Шрифт для рисования подписей номеров графа
        private Color colorForVerticle;//Цвет для вершин
        private int verticles;//Количество вершин
        private bool[,] Matrix;//Матрица смежности

        /// <summary>
        /// установка области для рисования графа
        /// </summary>
        /// <param name="region">Ссылка на экземпляр класса PictureBox</param>
        public GraphBuilder(PictureBox region)
        {
            this.region = region;
            bitmap = new Bitmap(this.region.Width, this.region.Height);
            graphics = Graphics.FromImage(bitmap);
            graphics.SmoothingMode = SmoothingMode.AntiAlias;
            font = new Font("Tahoma", 9f);
        }

        /// <summary>
        /// Нарисовать граф
        /// </summary>
        /// <param name="AdjacencyMatrix">Матрица смежности</param>
        public void DrawGraph(bool[,] AdjacencyMatrix)
        {
            verticles = AdjacencyMatrix.GetLength(0);
            Matrix = AdjacencyMatrix;
            graphics.Clear(region.BackColor);
            CreatePointsForVerticles();
            DrawEdges();
            DrawVerticles();
            region.Image = bitmap;
        }
        public void DrawGraph(bool[,] AdjacencyMatrix, List<int> cliqueNodes)
        {
            verticles = AdjacencyMatrix.GetLength(0);
            Matrix = AdjacencyMatrix;
            graphics.Clear(region.BackColor);
            CreatePointsForVerticles();
            DrawEdges(cliqueNodes);
            DrawVerticles(cliqueNodes);
            region.Image = bitmap;
        }


        /// <summary>
        /// Найти координаты для построения вершин на области для рисования
        /// </summary>
        private void CreatePointsForVerticles()
        {
            pointsForVerticles = new PointF[verticles];
            double degree = 360.0 / verticles;
            double d = 0;
            Point xy = new Point(region.Width / 2 - 12, region.Height / 2 - 15);
            Point x0y0 = new Point(region.Width - 40, region.Height / 2 - 15);
            Point rxry = new Point((x0y0.X - xy.X), (x0y0.Y - xy.Y));
            for (int i = 0; i < verticles; i++, d += degree)
            {
                double cos = Math.Cos((Math.PI / 180) * d);
                double sin = Math.Sin((Math.PI / 180) * d);
                double tmps = (xy.X + rxry.X * cos - rxry.Y * sin);
                double tmp1 = (xy.Y + rxry.X * sin + rxry.Y * cos);
                Point x1y1 = new Point((int)tmps, (int)tmp1);
                pointsForVerticles[i] = new Point(x1y1.X, x1y1.Y);
            }
        }

        /// <summary>
        /// Нарисовать ребра
        /// </summary>
        private void DrawEdges()
        {
            for (int i = 0; i < Matrix.GetLength(0); i++)
            {
                for (int j = 0; j < Matrix.GetLength(1); j++)
                {
                    if (Matrix[i, j])
                    {
                        graphics.DrawLine(Pens.Gray, pointsForVerticles[i].X + 12, pointsForVerticles[i].Y + 12, pointsForVerticles[j].X + 12, pointsForVerticles[j].Y + 12);
                    }
                }
            }
        }
        private void DrawEdges(List<int> cliqueNodes)
        {
            DrawEdges();
            for (int i = 0; i < cliqueNodes.Count; i++)
            {
                for(int j = 0; j < cliqueNodes.Count; j++)
                {
                    if(cliqueNodes[i] != cliqueNodes[j])
                    {
                        graphics.DrawLine(Pens.LimeGreen, 
                            pointsForVerticles[cliqueNodes[i] - 1].X + 12, pointsForVerticles[cliqueNodes[i] - 1].Y + 12, 
                            pointsForVerticles[cliqueNodes[j] - 1].X + 12, pointsForVerticles[cliqueNodes[j] - 1].Y + 12);
                    }
                }
            }
        }

        /// <summary>
        /// Нарисовать вершины
        /// </summary>
        private void DrawVerticles()
        {
            for (int i = 0; i < Matrix.GetLength(0); i++)
            {
                colorForVerticle = Color.LightSeaGreen;
                graphics.FillEllipse(new SolidBrush(colorForVerticle), pointsForVerticles[i].X, pointsForVerticles[i].Y, 25, 25);
                var x = (i < 9) ? pointsForVerticles[i].X + 8 : pointsForVerticles[i].X + 4;
                graphics.DrawString((i + 1).ToString(), font, Brushes.GhostWhite, x, pointsForVerticles[i].Y + 5);
            }
        }
        private void DrawVerticles(List<int> cliqueNodes)
        {
            for (int i = 0, counter = 0; i < Matrix.GetLength(0); i++)
            {
                if(counter < (cliqueNodes.Count) && i == (cliqueNodes[counter] - 1))
                {
                    int node = cliqueNodes[counter];
                    colorForVerticle = Color.Orange;
                    graphics.FillEllipse(new SolidBrush(colorForVerticle), pointsForVerticles[node - 1].X, pointsForVerticles[node - 1].Y, 25, 25);
                    var x = (node < 9) ? pointsForVerticles[node - 1].X + 8 : pointsForVerticles[node - 1].X + 4;
                    graphics.DrawString((node).ToString(), font, Brushes.Purple, x, pointsForVerticles[node - 1].Y + 5);
                    counter++;
                }
                else
                {
                    colorForVerticle = Color.LightSeaGreen;
                    graphics.FillEllipse(new SolidBrush(colorForVerticle), pointsForVerticles[i].X, pointsForVerticles[i].Y, 25, 25);
                    var x = (i < 9) ? pointsForVerticles[i].X + 8 : pointsForVerticles[i].X + 4;
                    graphics.DrawString((i + 1).ToString(), font, Brushes.GhostWhite, x, pointsForVerticles[i].Y + 5);
                }
            }
        }
    }
}
