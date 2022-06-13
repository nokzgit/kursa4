namespace BikovKP
{
    partial class MainForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.Compare = new System.Windows.Forms.Button();
            this.Import = new System.Windows.Forms.Button();
            this.Export = new System.Windows.Forms.Button();
            this.CreateKeyBoardGraph = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.KeyBoardGraph = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.TotalResult = new System.Windows.Forms.RichTextBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.ResultOfGraph = new System.Windows.Forms.TextBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.RandomGraph = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.Edges = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.Vertices = new System.Windows.Forms.NumericUpDown();
            this.CreateRandomGraph = new System.Windows.Forms.Button();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.DropGraph = new System.Windows.Forms.Button();
            this.AddNewGraph = new System.Windows.Forms.Button();
            this.NumberOfGraphForDroping = new System.Windows.Forms.NumericUpDown();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Edges)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Vertices)).BeginInit();
            this.groupBox7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NumberOfGraphForDroping)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Left;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(583, 651);
            this.tabControl1.TabIndex = 0;
            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
            // 
            // Compare
            // 
            this.Compare.Location = new System.Drawing.Point(119, 13);
            this.Compare.Name = "Compare";
            this.Compare.Size = new System.Drawing.Size(75, 23);
            this.Compare.TabIndex = 1;
            this.Compare.Text = "Порівняти";
            this.Compare.UseVisualStyleBackColor = true;
            this.Compare.Click += new System.EventHandler(this.Compare_Click);
            // 
            // Import
            // 
            this.Import.Location = new System.Drawing.Point(148, 19);
            this.Import.Name = "Import";
            this.Import.Size = new System.Drawing.Size(141, 23);
            this.Import.TabIndex = 2;
            this.Import.Text = "Імпортувати з файлу";
            this.Import.UseVisualStyleBackColor = true;
            this.Import.Click += new System.EventHandler(this.Import_Click);
            // 
            // Export
            // 
            this.Export.Location = new System.Drawing.Point(6, 19);
            this.Export.Name = "Export";
            this.Export.Size = new System.Drawing.Size(141, 23);
            this.Export.TabIndex = 3;
            this.Export.Text = "Експортувати у файл";
            this.Export.UseVisualStyleBackColor = true;
            this.Export.Click += new System.EventHandler(this.Export_Click);
            // 
            // CreateKeyBoardGraph
            // 
            this.CreateKeyBoardGraph.Location = new System.Drawing.Point(59, 77);
            this.CreateKeyBoardGraph.Name = "CreateKeyBoardGraph";
            this.CreateKeyBoardGraph.Size = new System.Drawing.Size(168, 23);
            this.CreateKeyBoardGraph.TabIndex = 4;
            this.CreateKeyBoardGraph.Text = "Створити граф";
            this.CreateKeyBoardGraph.UseVisualStyleBackColor = true;
            this.CreateKeyBoardGraph.Click += new System.EventHandler(this.CreateKeyBoardGraph_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.KeyBoardGraph);
            this.groupBox1.Controls.Add(this.CreateKeyBoardGraph);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(3, 153);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(296, 107);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Введення даних з клавіатури";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(132, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "FI-представлення графу:";
            // 
            // KeyBoardGraph
            // 
            this.KeyBoardGraph.Location = new System.Drawing.Point(9, 32);
            this.KeyBoardGraph.Multiline = true;
            this.KeyBoardGraph.Name = "KeyBoardGraph";
            this.KeyBoardGraph.Size = new System.Drawing.Size(278, 39);
            this.KeyBoardGraph.TabIndex = 5;
            this.KeyBoardGraph.Text = "2 3 0 1 3 0 1 2 4 5 0 3 5 0 3 4 0";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.Export);
            this.groupBox2.Controls.Add(this.Import);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox2.Location = new System.Drawing.Point(3, 97);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(296, 56);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Робота із сторонім файлом";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.groupBox6);
            this.groupBox3.Controls.Add(this.groupBox5);
            this.groupBox3.Controls.Add(this.groupBox4);
            this.groupBox3.Controls.Add(this.groupBox1);
            this.groupBox3.Controls.Add(this.groupBox2);
            this.groupBox3.Controls.Add(this.groupBox7);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Right;
            this.groupBox3.Location = new System.Drawing.Point(580, 0);
            this.groupBox3.MinimumSize = new System.Drawing.Size(302, 529);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(302, 651);
            this.groupBox3.TabIndex = 1;
            this.groupBox3.TabStop = false;
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.TotalResult);
            this.groupBox6.Controls.Add(this.Compare);
            this.groupBox6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox6.Location = new System.Drawing.Point(3, 469);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(296, 179);
            this.groupBox6.TabIndex = 8;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Загальний висновок";
            // 
            // TotalResult
            // 
            this.TotalResult.Location = new System.Drawing.Point(3, 42);
            this.TotalResult.Name = "TotalResult";
            this.TotalResult.ReadOnly = true;
            this.TotalResult.Size = new System.Drawing.Size(290, 134);
            this.TotalResult.TabIndex = 3;
            this.TotalResult.Text = "";
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.ResultOfGraph);
            this.groupBox5.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox5.Location = new System.Drawing.Point(3, 403);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(296, 66);
            this.groupBox5.TabIndex = 7;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Висновок по графу";
            // 
            // ResultOfGraph
            // 
            this.ResultOfGraph.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.ResultOfGraph.Location = new System.Drawing.Point(3, 22);
            this.ResultOfGraph.Multiline = true;
            this.ResultOfGraph.Name = "ResultOfGraph";
            this.ResultOfGraph.ReadOnly = true;
            this.ResultOfGraph.Size = new System.Drawing.Size(290, 41);
            this.ResultOfGraph.TabIndex = 3;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.RandomGraph);
            this.groupBox4.Controls.Add(this.label2);
            this.groupBox4.Controls.Add(this.Edges);
            this.groupBox4.Controls.Add(this.label1);
            this.groupBox4.Controls.Add(this.Vertices);
            this.groupBox4.Controls.Add(this.CreateRandomGraph);
            this.groupBox4.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox4.Location = new System.Drawing.Point(3, 260);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(296, 143);
            this.groupBox4.TabIndex = 6;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Створення випадкового графу";
            // 
            // RandomGraph
            // 
            this.RandomGraph.Location = new System.Drawing.Point(9, 94);
            this.RandomGraph.Multiline = true;
            this.RandomGraph.Name = "RandomGraph";
            this.RandomGraph.ReadOnly = true;
            this.RandomGraph.Size = new System.Drawing.Size(278, 39);
            this.RandomGraph.TabIndex = 10;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(164, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(86, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "Кількість ребер";
            // 
            // Edges
            // 
            this.Edges.Location = new System.Drawing.Point(167, 39);
            this.Edges.Maximum = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.Edges.Name = "Edges";
            this.Edges.Size = new System.Drawing.Size(120, 20);
            this.Edges.TabIndex = 7;
            this.Edges.Value = new decimal(new int[] {
            17,
            0,
            0,
            0});
            this.Edges.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Edges_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(94, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Кількість вершин";
            // 
            // Vertices
            // 
            this.Vertices.Location = new System.Drawing.Point(6, 39);
            this.Vertices.Maximum = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.Vertices.Name = "Vertices";
            this.Vertices.Size = new System.Drawing.Size(120, 20);
            this.Vertices.TabIndex = 6;
            this.Vertices.Value = new decimal(new int[] {
            7,
            0,
            0,
            0});
            this.Vertices.Leave += new System.EventHandler(this.Vertices_Leave);
            // 
            // CreateRandomGraph
            // 
            this.CreateRandomGraph.Location = new System.Drawing.Point(59, 65);
            this.CreateRandomGraph.Name = "CreateRandomGraph";
            this.CreateRandomGraph.Size = new System.Drawing.Size(168, 23);
            this.CreateRandomGraph.TabIndex = 5;
            this.CreateRandomGraph.Text = "Створити граф";
            this.CreateRandomGraph.UseVisualStyleBackColor = true;
            this.CreateRandomGraph.Click += new System.EventHandler(this.CreateRandomGraph_Click);
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.label4);
            this.groupBox7.Controls.Add(this.DropGraph);
            this.groupBox7.Controls.Add(this.AddNewGraph);
            this.groupBox7.Controls.Add(this.NumberOfGraphForDroping);
            this.groupBox7.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox7.Location = new System.Drawing.Point(3, 16);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(296, 81);
            this.groupBox7.TabIndex = 9;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "Додаткові графи";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(28, 20);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(52, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "№ Графу";
            // 
            // DropGraph
            // 
            this.DropGraph.Location = new System.Drawing.Point(119, 48);
            this.DropGraph.Name = "DropGraph";
            this.DropGraph.Size = new System.Drawing.Size(168, 23);
            this.DropGraph.TabIndex = 9;
            this.DropGraph.Text = "Видалити обраний граф";
            this.DropGraph.UseVisualStyleBackColor = true;
            this.DropGraph.Click += new System.EventHandler(this.DropGraph_Click);
            // 
            // AddNewGraph
            // 
            this.AddNewGraph.Location = new System.Drawing.Point(119, 15);
            this.AddNewGraph.Name = "AddNewGraph";
            this.AddNewGraph.Size = new System.Drawing.Size(168, 23);
            this.AddNewGraph.TabIndex = 8;
            this.AddNewGraph.Text = "Додати новий граф";
            this.AddNewGraph.UseVisualStyleBackColor = true;
            this.AddNewGraph.Click += new System.EventHandler(this.AddNewGraph_Click);
            // 
            // NumberOfGraphForDroping
            // 
            this.NumberOfGraphForDroping.Location = new System.Drawing.Point(10, 38);
            this.NumberOfGraphForDroping.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.NumberOfGraphForDroping.Name = "NumberOfGraphForDroping";
            this.NumberOfGraphForDroping.Size = new System.Drawing.Size(91, 20);
            this.NumberOfGraphForDroping.TabIndex = 7;
            this.NumberOfGraphForDroping.ValueChanged += new System.EventHandler(this.NumberOfGraphForDroping_ValueChanged);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(882, 651);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.tabControl1);
            this.Name = "MainForm";
            this.Text = "Потужність максимально повного підграфа у графі - Биков М.М.";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox6.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Edges)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Vertices)).EndInit();
            this.groupBox7.ResumeLayout(false);
            this.groupBox7.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NumberOfGraphForDroping)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.Button Compare;
        private System.Windows.Forms.Button Import;
        private System.Windows.Forms.Button Export;
        private System.Windows.Forms.Button CreateKeyBoardGraph;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox KeyBoardGraph;
        private System.Windows.Forms.TextBox ResultOfGraph;
        private System.Windows.Forms.TextBox RandomGraph;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown Edges;
        private System.Windows.Forms.NumericUpDown Vertices;
        private System.Windows.Forms.Button CreateRandomGraph;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.Button DropGraph;
        private System.Windows.Forms.Button AddNewGraph;
        private System.Windows.Forms.NumericUpDown NumberOfGraphForDroping;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.RichTextBox TotalResult;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
    }
}

