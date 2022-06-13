using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace BikovKP
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Graphs.Add(null);
            Graphs.Add(null);

            for (int i = 0; i < 2; i++)
            {
                TabPage newPage = new TabPage("Граф " + i);
                PictureBox pb = new PictureBox();
                pb.Dock = DockStyle.Fill;
                pb.Click += new EventHandler(pictureBox_Click);
                newPage.Controls.Add(pb);

                Label lable = new Label();
                lable.Text = "Граф";
                lable.Font = new Font("Tahoma", 11f);
                lable.Dock = DockStyle.Top;
                newPage.Controls.Add(lable);

                tabControl1.TabPages.Add(newPage);
            }

            Vertices_Leave(sender, e);
        }

        List<Graph> Graphs = new List<Graph>();
        int AbsolutNumberOfGraph = 1;

        private void AddNewGraph_Click(object sender, EventArgs e)
        {
            AbsolutNumberOfGraph++;
            TabPage newPage = new TabPage("Граф " + AbsolutNumberOfGraph);
            PictureBox pb = new PictureBox();
            pb.Dock = DockStyle.Fill;
            pb.Click += new EventHandler(pictureBox_Click);
            newPage.Controls.Add(pb);

            Label lable = new Label();
            lable.Text = "Граф";
            lable.Font = new Font("Tahoma", 11f);
            lable.Dock = DockStyle.Top;
            newPage.Controls.Add(lable);

            tabControl1.TabPages.Add(newPage);
            NumberOfGraphForDroping.Maximum = tabControl1.TabPages.Count - 1;
            Graphs.Add(null);
            ResultOfGraph.Text = "";
        }

        private void DropGraph_Click(object sender, EventArgs e)
        {
            if (tabControl1.TabPages.Count == 0)
                return;
            int number = (int) NumberOfGraphForDroping.Value;
            tabControl1.TabPages.RemoveAt(number);
            NumberOfGraphForDroping.Value = (tabControl1.TabPages.Count == 0) ? 0: tabControl1.TabPages.Count - 1;
            NumberOfGraphForDroping.Maximum = (tabControl1.TabPages.Count == 0) ? 0 : tabControl1.TabPages.Count - 1;
            Graphs.RemoveAt(number);
            
            TotalResult.Text = "";
            
            int newNumber = (int)NumberOfGraphForDroping.Value;
            if(Graphs.Count != 0)
                if (Graphs[newNumber] == null)
                {
                    KeyBoardGraph.Text = "";
                    ResultOfGraph.Text = "";
                }
                else
                {
                    KeyBoardGraph.Text = String.Join(" ", Graphs[newNumber].FI);
                    ResultOfGraph.Text = Graphs[newNumber].SummaryOfGraph;
                }
        }

        private void NumberOfGraphForDroping_ValueChanged(object sender, EventArgs e)
        {
            int number = (int) NumberOfGraphForDroping.Value;
            if (tabControl1.TabPages.Count != 0)
                tabControl1.SelectedTab = tabControl1.TabPages[number];

            RandomGraph.Text = "";
            if (Graphs[number] == null)
            {
                KeyBoardGraph.Text = "";
                ResultOfGraph.Text = "";
            }
            else
            {
                KeyBoardGraph.Text = String.Join(" ", Graphs[number].FI);
                ResultOfGraph.Text = Graphs[number].SummaryOfGraph;
            }
            TotalResult.Text = "";
        }

        private void CreateKeyBoardGraph_Click(object sender, EventArgs e)
        {
            int index = (int)NumberOfGraphForDroping.Value;
            string[] fi = KeyBoardGraph.Text.Split(' ');
            int[] FI = new int[fi.Length];
            try
            {
                for (int i = 0; i < FI.Length; i++)
                    FI[i] = Convert.ToInt32(fi[i]);
            }
            catch (Exception)
            {
                MessageBox.Show("В строчці наявні символи відміні від цифр");
                return;
            }
            Graph graph = null;
            try
            {
                if (Graph.getNumberEdges(FI) > 50)
                {
                    MessageBox.Show("В строчці вказано більше ніж 50 ребер");
                    return;
                }
                if(Graph.CalculateNodes(FI) > 20)
                {
                    MessageBox.Show("В строчці вказано більше вершин ніж 20");
                    return;
                }
                graph = new Graph(FI);
            }
            catch (Exception)
            {
                MessageBox.Show("При створенні графу виникла помилка! Перевірте строчку з FI");
                return;
            }
            Graphs[index] = graph;

            GraphBuilder gb = new GraphBuilder((PictureBox)tabControl1.TabPages[index].Controls[0]);
            gb.DrawGraph(graph.Matrix);
            
            ResultOfGraph.Text = graph.SummaryOfGraph;

            RandomGraph.Text = "";
        }

        private void CreateRandomGraph_Click(object sender, EventArgs e)
        {
            int index = (int)NumberOfGraphForDroping.Value;
            int vertices = Convert.ToInt32(Vertices.Value);
            int edges = Convert.ToInt32(Edges.Value);
            try
            {
                if (edges > 0 && vertices == 0)
                    MessageBox.Show("За такими даними неможливо створити граф!");
                else
                {
                    int[] FI = Graph.MakeFI(Graph.GenRandomGraph(vertices, edges));
                    Graph graph = new Graph(FI);

                    Graphs[index] = graph;

                    GraphBuilder gb = new GraphBuilder((PictureBox)tabControl1.TabPages[index].Controls[0]);
                    gb.DrawGraph(graph.Matrix);

                    RandomGraph.Text = String.Join(" ", FI);

                    ResultOfGraph.Text = graph.SummaryOfGraph;
                }
                KeyBoardGraph.Text = "";
            }
            catch
            {
                MessageBox.Show("Ошибка задания графа", "Error!");
            }
        }

        private void Edges_KeyPress(object sender, KeyPressEventArgs e)
        {
            var MaxZnach = ((Vertices.Value * Vertices.Value - Vertices.Value) / 2);
            if (MaxZnach > 50) MaxZnach = 50;
            Edges.Maximum = MaxZnach;
        }

        private void Vertices_Leave(object sender, EventArgs e)
        {
            var MaxZnach = ((Vertices.Value * Vertices.Value - Vertices.Value) / 2);
            if (MaxZnach > 50) MaxZnach = 50;
            Edges.Maximum = MaxZnach;
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl1.SelectedIndex == -1)
                return;
            NumberOfGraphForDroping.Value = tabControl1.SelectedIndex;
        }

        private void Import_Click(object sender, EventArgs e)
        {
            string textFromFile = "";
            int currentIndex = 0;
            if(openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                TabPage newPage = new TabPage(openFileDialog1.FileName);
                PictureBox pb = new PictureBox();
                pb.Dock = DockStyle.Fill;
                pb.Click += new EventHandler(pictureBox_Click);
                newPage.Controls.Add(pb);

                Label lable = new Label();
                lable.Text = "Граф";
                lable.Font = new Font("Tahoma", 11f);
                lable.Dock = DockStyle.Top;
                newPage.Controls.Add(lable);

                tabControl1.TabPages.Add(newPage);
                NumberOfGraphForDroping.Maximum = tabControl1.TabPages.Count - 1;
                currentIndex = (int)NumberOfGraphForDroping.Maximum;
                Graphs.Add(null);
                NumberOfGraphForDroping.Value = currentIndex;

                textFromFile = File.ReadAllText(openFileDialog1.FileName);
                tabControl1.SelectedTab = tabControl1.TabPages[currentIndex];
            }
            
            try
            {
                int[] FI = textFromFile.Split(' ').Select(x => int.Parse(x)).ToArray();
                Graph graph = new Graph(FI);
                Graphs[currentIndex] = graph;

                GraphBuilder gb = new GraphBuilder((PictureBox)tabControl1.TabPages[currentIndex].Controls[0]);
                gb.DrawGraph(graph.Matrix);

                KeyBoardGraph.Text = String.Join(" ", FI);
                ResultOfGraph.Text = graph.SummaryOfGraph;

                RandomGraph.Text = "";
            }
            catch
            {
                MessageBox.Show("Вхідний файл мав помилку у структурі представлення графу FI!");
                return;
            }
        }

        private void Export_Click(object sender, EventArgs e)
        {
            if(RandomGraph.Text != "" && KeyBoardGraph.Text != "")
            {
                MessageBox.Show("У вікні існує 2 варіанти графи у полі із випадковим та введеним із клавіатури, " +
                    "необхідно один залишити, а другий видалити, зробіть це і спробуйте зберегти знов");
                return;
            }
            else
            {
                string textGraph = "";
                try
                {
                    textGraph = (KeyBoardGraph.Text != "") ? KeyBoardGraph.Text : RandomGraph.Text;
                    Graph graph = new Graph(textGraph.Split(' ').Select(x => int.Parse(x)).ToArray());
                }
                catch
                {
                    MessageBox.Show("У структурі FI мається помилка виправте її та спробуйте зберегти знов");
                    return;
                }

                int index = (int)NumberOfGraphForDroping.Value;
                string nameGraph = tabControl1.TabPages[index].Text;
                string newNameFile = nameGraph;
                int counter = 0;
                while (File.Exists(newNameFile))
                {
                    counter++;
                    newNameFile = nameGraph + "(копія " + counter + ")";
                }
                File.WriteAllText(newNameFile, textGraph);
                MessageBox.Show("Граф був збережений у файлі під назвою " + newNameFile);

                #region Save image
                SaveFileDialog saveFile = new SaveFileDialog();
                saveFile.Title = "Зберегти зображення як...";
                saveFile.OverwritePrompt = true;
                saveFile.CheckPathExists = true;
                saveFile.Filter = "Image Files(*.BMP)|*.BMP|Image Files(*.JPG)|*.JPG|Image Files(*.GIF)|*.GIF|Image Files(*.PNG)|*.PNG|All files (*.*)|*.*";
                saveFile.ShowHelp = true;
                if (saveFile.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        PictureBox pb = (PictureBox)tabControl1.TabPages[index].Controls[0];
                        pb.Image.Save(saveFile.FileName, System.Drawing.Imaging.ImageFormat.Jpeg);
                    }
                    catch
                    {
                        MessageBox.Show("Невозможно сохранить изображение", "Ошибка",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                #endregion

                tabControl1.TabPages.RemoveAt(index);
                NumberOfGraphForDroping.Value = (tabControl1.TabPages.Count == 0) ? 0: tabControl1.TabPages.Count - 1;
                Graphs.RemoveAt(index);
                
                int number = (int)NumberOfGraphForDroping.Value;

                if(tabControl1.TabPages.Count != 0)
                    tabControl1.SelectedTab = tabControl1.TabPages[number];
                RandomGraph.Text = "";
                if (Graphs.Count != 0)
                    if (Graphs[number] == null)
                    {
                        KeyBoardGraph.Text = "";
                        ResultOfGraph.Text = "";
                    }
                    else
                    {
                        KeyBoardGraph.Text = String.Join(" ", Graphs[number].FI);
                        ResultOfGraph.Text = Graphs[number].SummaryOfGraph;
                    }
            }
        }

        private void Compare_Click(object sender, EventArgs e)
        {
            
            for(int i = 0; i < Graphs.Count; i++)
            {
                if(Graphs[i] == null)
                {
                    MessageBox.Show("Перед порівнянням необхідно щоб були створені всі графи, [" + (i + 1) + 
                        "] граф із списку не заповнений, заповніть його та знову спробуйте порівняти графи!");
                    return;
                }
            }

            string resultText = "";
            for(int i = 0; i < Graphs.Count; i++)
            {
                resultText += "\tГраф № " + i + " із списку створенних\n";
                resultText += "Має потужність максимально повного підграфу у графі " + Graphs[i].PowerClique + "\n";
                resultText += "Причому має такий максимально повний підграф: " + Clique.ListAsString(Graphs[i].Clique) + "\n";
            }
            resultText += (CompareGraphs(Graphs)) ? "АНАЛІЗОВАНІ ГРАФИ ЕКВІВАЛЕНТНІ" : "АНАЛІЗОВАНІ ГРАФИ НЕ ЕКВІВАЛЕНТНІ";
            TotalResult.Text = resultText;
        }

        private bool CompareGraphs(List<Graph> graphs)
        {
            int powerClique = graphs[0].PowerClique;
            foreach(Graph graph in graphs)
                if (powerClique != graph.PowerClique)
                    return false;
            return true;
        }

        private void pictureBox_Click(object sender, EventArgs e)
        {
            int number = (int)NumberOfGraphForDroping.Value;
            if (Graphs[number] != null)
            {
                Graph graph = Graphs[number];
                GraphBuilder gb = new GraphBuilder((PictureBox)tabControl1.TabPages[number].Controls[0]);

                Label label = (Label)tabControl1.TabPages[number].Controls[1];
                if (label.Text == "Граф")
                {
                    gb.DrawGraph(graph.Matrix, graph.Clique);
                    tabControl1.TabPages[number].Controls[1].Text = "Граф та максимально повний підграф";
                }
                else
                {
                    gb.DrawGraph(graph.Matrix);
                    tabControl1.TabPages[number].Controls[1].Text = "Граф";
                }
            }
        }
    }
}