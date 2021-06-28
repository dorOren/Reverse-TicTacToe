
using Logic.Enums;
using System.Collections.Generic;
using System.Windows.Forms;
using UI;

namespace UI
{
    partial class BoardForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent(int i_NumCols, int i_NumRows, int i_Width, int i_Height, ePlayerType i_PlayerType)
        {
            this.player1Label = new System.Windows.Forms.Label();
            this.player2Label = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // player1Label
            // 
            this.player1Label.AutoSize = false;
            this.player1Label.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            this.player1Label.Dock = DockStyle.Left;
            // 
            // player2Label
            // 
            this.player2Label.AutoSize = false;
            this.player2Label.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.player2Label.Dock = DockStyle.Right;
            //
            // Both Labels
            //
            updateScore();
            // 
            // BoardForm
            // 
            this.ClientSize = new System.Drawing.Size(284, 261);
            generateButtonMatrix(i_NumCols, i_NumRows);
            this.Controls.Add(this.player1Label);
            this.Controls.Add(this.player2Label);
            this.Text = "Reverse TicTacToe";
            this.MinimumSize = new System.Drawing.Size(i_Width, i_Height);
            this.MaximumSize = new System.Drawing.Size(i_Width, i_Height);
            this.MaximizeBox = false;
            this.SizeGripStyle = SizeGripStyle.Hide;
            this.Name = "BoardForm";
            this.ResumeLayout(false);

        }

        private void generateButtonMatrix(int i_NumCols, int i_NumRows)
        {
            m_ButtonMatrix = new Button[i_NumRows, i_NumCols];
            int buttonNum = 0;
            for (int i = 0; i < i_NumRows; i++)
            {
                for (int j = 0; j < i_NumCols; j++)
                {
                    m_ButtonMatrix[i, j] = new Button();
                    Button button = m_ButtonMatrix[i, j];
                    m_ButtonMatrix[i, j].Location = new System.Drawing.Point(i * 42 + 10+40, j * 42 + 10);
                    m_ButtonMatrix[i, j].Name = "button";
                    m_ButtonMatrix[i, j].Size = new System.Drawing.Size(40, 40);
                    m_ButtonMatrix[i, j].TabIndex = 0;
                    m_ButtonMatrix[i, j].UseVisualStyleBackColor = true;
                    m_ButtonMatrix[i, j].Tag = buttonNum;
                    m_ButtonMatrix[i, j].TabStop = false;
                    m_ButtonMatrix[i, j].Click += new System.EventHandler(this.buttons_Click);
                    this.Controls.Add(m_ButtonMatrix[i, j]);
                    buttonNum++;
                }
            }
        }

        #endregion
        private System.Windows.Forms.Label player1Label;
        private System.Windows.Forms.Label player2Label;
    }

 
}