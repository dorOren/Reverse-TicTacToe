
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
        
        private void InitializeComponent(int i_NumCols, int i_NumRows, int i_Length, int i_Height)
        {
            this.SuspendLayout();
            // 
            // BoardForm
            // 
            this.ClientSize = new System.Drawing.Size(284, 261);
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
                    m_ButtonMatrix[i, j].Location = new System.Drawing.Point(i * 40 + 10, j * 40 + 10);
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
    }

 
}