
using System.Windows.Forms;
using UI;

namespace UI
{
    partial class BoardForm
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
            this.SuspendLayout();
            // 
            // BoardForm
            // 
            this.ClientSize = new System.Drawing.Size(282, 253);
            this.Name = "BoardForm";
            this.Load += new System.EventHandler(this.BoardForm_Load);
            this.ResumeLayout(false);

        }

        private void generateButtonMatrix(int i_NumCols, int i_NumRows)
        {
            Button[,] buttonMatrix = new Button[i_NumRows, i_NumCols];

            for (int i = 0; i < i_NumRows; i++)
            {
                for (int j = 0; j < i_NumCols; j++)
                {
                    buttonMatrix[i, j] = new Button();
                    Button button = buttonMatrix[i, j];
                    buttonMatrix[i, j].Location = new System.Drawing.Point(i * 40 + 10, j * 40 + 10);
                    buttonMatrix[i, j].Name = "button";
                    buttonMatrix[i, j].Size = new System.Drawing.Size(44, 40);
                    buttonMatrix[i, j].TabIndex = 0;
                    buttonMatrix[i, j].UseVisualStyleBackColor = true;
                    buttonMatrix[i, j].Click += new System.EventHandler(this.buttons_Click);
                    this.Controls.Add(buttonMatrix[i, j]);


                }
            }
        }

        #endregion

    }
}