namespace ImageFilters
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnOpen = new System.Windows.Forms.Button();
            this.btnZGraph = new System.Windows.Forms.Button();
            this.windoSizeForFilter = new System.Windows.Forms.TextBox();
            this.trimValue = new System.Windows.Forms.TextBox();
            this.maxWindoSizeForG = new System.Windows.Forms.TextBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.selectedFilter = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.applyFilterBtn = new System.Windows.Forms.Button();
            this.sortingAlgo = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pictureBox1.Location = new System.Drawing.Point(104, 56);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(761, 542);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // btnOpen
            // 
            this.btnOpen.BackColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.btnOpen.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnOpen.Font = new System.Drawing.Font("Times New Roman", 13.8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOpen.ForeColor = System.Drawing.Color.Chocolate;
            this.btnOpen.Location = new System.Drawing.Point(104, 880);
            this.btnOpen.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnOpen.Name = "btnOpen";
            this.btnOpen.Size = new System.Drawing.Size(163, 77);
            this.btnOpen.TabIndex = 2;
            this.btnOpen.Text = "Open Image";
            this.btnOpen.UseVisualStyleBackColor = false;
            this.btnOpen.Click += new System.EventHandler(this.btnOpen_Click);
            // 
            // btnZGraph
            // 
            this.btnZGraph.BackColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.btnZGraph.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnZGraph.Font = new System.Drawing.Font("Times New Roman", 13.8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnZGraph.ForeColor = System.Drawing.Color.Chocolate;
            this.btnZGraph.Location = new System.Drawing.Point(1571, 868);
            this.btnZGraph.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnZGraph.Name = "btnZGraph";
            this.btnZGraph.Size = new System.Drawing.Size(147, 76);
            this.btnZGraph.TabIndex = 3;
            this.btnZGraph.Text = "Graph";
            this.btnZGraph.UseVisualStyleBackColor = false;
            this.btnZGraph.Click += new System.EventHandler(this.btnZGraph_Click);
            // 
            // windoSizeForFilter
            // 
            this.windoSizeForFilter.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.windoSizeForFilter.Location = new System.Drawing.Point(728, 753);
            this.windoSizeForFilter.Name = "windoSizeForFilter";
            this.windoSizeForFilter.Size = new System.Drawing.Size(219, 24);
            this.windoSizeForFilter.TabIndex = 4;
            this.windoSizeForFilter.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // trimValue
            // 
            this.trimValue.Location = new System.Drawing.Point(1484, 752);
            this.trimValue.Name = "trimValue";
            this.trimValue.Size = new System.Drawing.Size(203, 24);
            this.trimValue.TabIndex = 5;
            // 
            // maxWindoSizeForG
            // 
            this.maxWindoSizeForG.Location = new System.Drawing.Point(1085, 754);
            this.maxWindoSizeForG.Name = "maxWindoSizeForG";
            this.maxWindoSizeForG.Size = new System.Drawing.Size(257, 24);
            this.maxWindoSizeForG.TabIndex = 6;
            this.maxWindoSizeForG.TextChanged += new System.EventHandler(this.textBox3_TextChanged);
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pictureBox2.Location = new System.Drawing.Point(957, 56);
            this.pictureBox2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(761, 542);
            this.pictureBox2.TabIndex = 7;
            this.pictureBox2.TabStop = false;
            // 
            // selectedFilter
            // 
            this.selectedFilter.FormattingEnabled = true;
            this.selectedFilter.Items.AddRange(new object[] {
            "Alpha Trim",
            "Adaptive Median"});
            this.selectedFilter.Location = new System.Drawing.Point(104, 757);
            this.selectedFilter.Name = "selectedFilter";
            this.selectedFilter.Size = new System.Drawing.Size(180, 24);
            this.selectedFilter.TabIndex = 8;
            this.selectedFilter.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 13.8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Maroon;
            this.label1.Location = new System.Drawing.Point(727, 702);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(138, 28);
            this.label1.TabIndex = 9;
            this.label1.Text = "Window Size";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe Script", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(1391, 606);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(96, 46);
            this.label2.TabIndex = 10;
            this.label2.Text = "After";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe Script", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(448, 606);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(111, 46);
            this.label3.TabIndex = 11;
            this.label3.Text = "Before";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Times New Roman", 13.8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Maroon;
            this.label4.Location = new System.Drawing.Point(99, 707);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(137, 28);
            this.label4.TabIndex = 12;
            this.label4.Text = "Image Filter";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Times New Roman", 13F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.label5.ForeColor = System.Drawing.Color.Maroon;
            this.label5.Location = new System.Drawing.Point(1080, 697);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(289, 25);
            this.label5.TabIndex = 13;
            this.label5.Text = "Max Window Size For Graph";
            this.label5.Click += new System.EventHandler(this.label5_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Times New Roman", 13.8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Maroon;
            this.label6.Location = new System.Drawing.Point(1479, 694);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(121, 28);
            this.label6.TabIndex = 14;
            this.label6.Text = "Trim Value";
            this.label6.Click += new System.EventHandler(this.label6_Click);
            // 
            // applyFilterBtn
            // 
            this.applyFilterBtn.BackColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.applyFilterBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.applyFilterBtn.Font = new System.Drawing.Font("Times New Roman", 13.8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.applyFilterBtn.ForeColor = System.Drawing.Color.Chocolate;
            this.applyFilterBtn.Location = new System.Drawing.Point(901, 868);
            this.applyFilterBtn.Name = "applyFilterBtn";
            this.applyFilterBtn.Size = new System.Drawing.Size(183, 77);
            this.applyFilterBtn.TabIndex = 15;
            this.applyFilterBtn.Text = "Apply";
            this.applyFilterBtn.UseVisualStyleBackColor = false;
            this.applyFilterBtn.Click += new System.EventHandler(this.button1_Click);
            // 
            // sortingAlgo
            // 
            this.sortingAlgo.FormattingEnabled = true;
            this.sortingAlgo.Items.AddRange(new object[] {
            "Counting sort",
            "    "});
            this.sortingAlgo.Location = new System.Drawing.Point(404, 753);
            this.sortingAlgo.Name = "sortingAlgo";
            this.sortingAlgo.Size = new System.Drawing.Size(207, 24);
            this.sortingAlgo.TabIndex = 16;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(321, 709);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(0, 17);
            this.label7.TabIndex = 17;
            this.label7.Click += new System.EventHandler(this.label7_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Times New Roman", 13.8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.Maroon;
            this.label8.Location = new System.Drawing.Point(399, 707);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(191, 28);
            this.label8.TabIndex = 18;
            this.label8.Text = "Sorting Algorithm";
            this.label8.Click += new System.EventHandler(this.label8_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(1924, 1055);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.sortingAlgo);
            this.Controls.Add(this.applyFilterBtn);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.selectedFilter);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.maxWindoSizeForG);
            this.Controls.Add(this.trimValue);
            this.Controls.Add(this.windoSizeForFilter);
            this.Controls.Add(this.btnZGraph);
            this.Controls.Add(this.btnOpen);
            this.Controls.Add(this.pictureBox1);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Image Filters...";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnOpen;
        private System.Windows.Forms.Button btnZGraph;
        private System.Windows.Forms.TextBox windoSizeForFilter;
        private System.Windows.Forms.TextBox trimValue;
        private System.Windows.Forms.TextBox maxWindoSizeForG;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.ComboBox selectedFilter;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button applyFilterBtn;
        private System.Windows.Forms.ComboBox sortingAlgo;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
    }
}

