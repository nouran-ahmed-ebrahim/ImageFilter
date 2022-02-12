using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ZGraphTools;

namespace ImageFilters
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        byte[,] ImageMatrix;

        private void btnOpen_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                //Open the browsed image and display it
                string OpenedFilePath = openFileDialog1.FileName;
                ImageMatrix = ImageOperations.OpenImage(OpenedFilePath);
                ImageOperations.DisplayImage(ImageMatrix, pictureBox1);

            }
        }

        private void btnZGraph_Click(object sender, EventArgs e)
        {
            if (!IsAllGraphInputsEntered())
            {
                return;
            }
            int maxWindowSizeForG = Convert.ToInt32(maxWindoSizeForG.Text);
            int WindowSize = Convert.ToInt32(windoSizeForFilter.Text);
            double[] x_values = new double[maxWindowSizeForG+1];
            x_values[1] = 1;
            double[] y_values_Carve1 = new double[maxWindowSizeForG + 1];
            double[] y_values_Carve2 = new double[maxWindowSizeForG + 1];

            if ((string)selectedFilter.SelectedItem == "Alpha Trim")
            {
                ShowAlphaGraph(WindowSize, maxWindowSizeForG, y_values_Carve1, y_values_Carve2, x_values);
            }
            else if ((string)selectedFilter.SelectedItem == "Adaptive Median")
            {
                ShowAdaptivMedianGraph(WindowSize,maxWindowSizeForG,y_values_Carve1,y_values_Carve2,x_values);
            }
        }

        private void ShowAdaptivMedianGraph(int WindowSize, int maxWindowSizeForG, double[] y_values_Carve1,
                                     double[] y_values_Carve2, double[] x_values)
        {

            for (int i = 3; i <= maxWindowSizeForG; i += 2)
            {
                long start = Environment.TickCount; ;
                ImageOperations.AdaptiveMedian(ImageMatrix, i, 'c');
                long duration = Environment.TickCount - start;

                y_values_Carve1[i] = duration;
                y_values_Carve1[i - 1] = (duration + y_values_Carve1[i - 2]) / 2;
            }

            for (int i = 3; i <= maxWindowSizeForG; i += 2)
            {
                long start = Environment.TickCount; ;
                ImageOperations.AdaptiveMedian(ImageMatrix, i, 'q');
                long duration = Environment.TickCount - start;

                x_values[i] = i;
                x_values[i - 1] = i - 1;
                y_values_Carve2[i] = duration;
                y_values_Carve2[i - 1] = (duration + y_values_Carve2[i - 2]) / 2;
            }

            ZGraphForm ZGF = new ZGraphForm("Adaptive Median Filter", "Window Size", "Time");
            ZGF.add_curve("Counting Sort", x_values, y_values_Carve1, Color.Red);
            ZGF.add_curve("Quick Sort", x_values, y_values_Carve2, Color.Blue);
            ZGF.Show();
        }

        private void ShowAlphaGraph(int WindowSize, int maxWindowSizeForG, double[] y_values_Carve1,
                                     double[] y_values_Carve2, double[] x_values)
        {

            int trimeVal = Convert.ToInt32(trimValue.Text);
            if (trimeVal > 4) trimeVal = 4;
          //  double trimPrecentat = (trimeVal / (double)(WindowSize * WindowSize));
            //int trim;
            for (int i = 3; i <= maxWindowSizeForG; i += 2)
            {
              //  trim = (int)((i * i) * trimPrecentat);
                int start = Environment.TickCount; ;
                ImageOperations.AlphaTrim(ImageMatrix, trimeVal, i, 'c');
                int duration = Environment.TickCount - start;

                y_values_Carve1[i] = duration;
                y_values_Carve1[i - 1] = (duration + y_values_Carve1[i - 2]) / 2;
            }

            for (int i = 3; i <= maxWindowSizeForG; i += 2)
            {
               // trim = (int)((i * i) * trimPrecentat);
                int start = Environment.TickCount; ;
                ImageOperations.AlphaTrim(ImageMatrix, trimeVal, i, 'k');
                int duration = Environment.TickCount - start;

                x_values[i] = i;
                x_values[i - 1] = i - 1;
                y_values_Carve2[i] = duration;
                y_values_Carve2[i - 1] = (duration + y_values_Carve2[i - 2]) / 2;
            }

            ZGraphForm ZGF = new ZGraphForm("Alpha trim Filter", "Window Size", "Time");
            ZGF.add_curve("Counting Sort", x_values, y_values_Carve1, Color.Red);
            ZGF.add_curve("Select kth element", x_values, y_values_Carve2, Color.Blue);
            ZGF.Show();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (selectedFilter.SelectedIndex == 0)
            {
                sortingAlgo.Items[1] = "Selecting Kth";
                trimValue.Enabled = true;
            }
            else
            {
                sortingAlgo.Items[1] = "Quick sort";
                trimValue.Enabled = false;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (IsAllFilterInputesEntered())
            {
                int wSize = Convert.ToInt32(windoSizeForFilter.Text);

                char algorithm;

                if ((string)sortingAlgo.SelectedItem == "Counting sort")
                {
                    algorithm = 'c';
                }
                else if ((string)sortingAlgo.SelectedItem == "Quick sort")
                {
                    algorithm = 'q';
                }
                else
                {
                    algorithm = 'k';
                }

                if ((string)selectedFilter.SelectedItem == "Alpha Trim")
                {
                    int trim = Convert.ToInt32(trimValue.Text);
                    ImageOperations.DisplayImage(ImageOperations.AlphaTrim(ImageMatrix, trim, wSize, algorithm), pictureBox2);
                }
                else if ((string)selectedFilter.SelectedItem == "Adaptive Median")
                {
                    ImageOperations.DisplayImage(ImageOperations.AdaptiveMedian(ImageMatrix, wSize, algorithm), pictureBox2);
                }
            }
        }

        private bool IsAllFilterInputesEntered()
        {
            if (windoSizeForFilter.Text == "" || sortingAlgo.SelectedItem == null ||
                selectedFilter.SelectedItem == null || ((string)selectedFilter.SelectedItem == "Alpha Trim"
                            && trimValue.Text == ""))
            {
                MessageBox.Show("Enter All inputs please", "Incomplete Inputs",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
             
            else if ((string)selectedFilter.SelectedItem == "Alpha Trim"
                && Convert.ToInt32(trimValue.Text) > (Convert.ToInt32(windoSizeForFilter.Text) * Convert.ToInt32(windoSizeForFilter.Text)) / 2)
            {
                MessageBox.Show("Trim Value should be less than or equal half window size", "Invalid Input",
                  MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return IsPhotoEntered();
        }

        private bool IsPhotoEntered()
        {
            if (ImageMatrix == null)
            {
                MessageBox.Show("Choose Photo to apply filter on please", "NO Image",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }

        private bool IsAllGraphInputsEntered()
        {
            if ((string)maxWindoSizeForG.Text == "")
            {
                MessageBox.Show("Enter All inputs please", "Incomplete Inputs",
                   MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return  IsAllFilterInputesEntered();
        }
        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
