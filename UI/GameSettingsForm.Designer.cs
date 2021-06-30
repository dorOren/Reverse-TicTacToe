
using System.Windows.Forms;

namespace UI
{
    partial class GameSettingsForm
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

        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.player1Label = new System.Windows.Forms.Label();
            this.textBoxPlayer1Name = new System.Windows.Forms.TextBox();
            this.player2CheckBox = new System.Windows.Forms.CheckBox();
            this.player2Label = new System.Windows.Forms.Label();
            this.textBoxPlayer2Name = new System.Windows.Forms.TextBox();
            this.boardSizeLabel = new System.Windows.Forms.Label();
            this.rowsLabel = new System.Windows.Forms.Label();
            this.colsLabel = new System.Windows.Forms.Label();
            this.numRows = new System.Windows.Forms.NumericUpDown();
            this.startButton = new System.Windows.Forms.Button();
            this.numCols = new System.Windows.Forms.NumericUpDown();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            ((System.ComponentModel.ISupportInitialize)(this.numRows)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numCols)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(30, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Players: ";
            // 
            // player1Label
            // 
            this.player1Label.AutoSize = true;
            this.player1Label.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.player1Label.Location = new System.Drawing.Point(66, 46);
            this.player1Label.Name = "player1Label";
            this.player1Label.Size = new System.Drawing.Size(57, 15);
            this.player1Label.TabIndex = 1;
            this.player1Label.Text = "Player 1: ";
            // 
            // textBoxPlayer1Name
            // 
            this.textBoxPlayer1Name.Location = new System.Drawing.Point(129, 44);
            this.textBoxPlayer1Name.MaxLength = 10;
            this.textBoxPlayer1Name.Name = "textBoxPlayer1Name";
            this.textBoxPlayer1Name.Size = new System.Drawing.Size(88, 23);
            this.textBoxPlayer1Name.TabIndex = 2;
            this.textBoxPlayer1Name.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // player2CheckBox
            // 
            this.player2CheckBox.AutoSize = true;
            this.player2CheckBox.Location = new System.Drawing.Point(45, 72);
            this.player2CheckBox.Name = "player2CheckBox";
            this.player2CheckBox.Size = new System.Drawing.Size(15, 14);
            this.player2CheckBox.TabIndex = 3;
            this.player2CheckBox.UseVisualStyleBackColor = true;
            this.player2CheckBox.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // player2Label
            // 
            this.player2Label.AutoSize = true;
            this.player2Label.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.player2Label.Location = new System.Drawing.Point(66, 70);
            this.player2Label.Name = "player2Label";
            this.player2Label.Size = new System.Drawing.Size(57, 15);
            this.player2Label.TabIndex = 4;
            this.player2Label.Text = "Player 2: ";
            // 
            // textBoxPlayer2Name
            // 
            this.textBoxPlayer2Name.Enabled = false;
            this.textBoxPlayer2Name.Location = new System.Drawing.Point(129, 70);
            this.textBoxPlayer2Name.MaxLength = 10;
            this.textBoxPlayer2Name.Name = "textBoxPlayer2Name";
            this.textBoxPlayer2Name.Size = new System.Drawing.Size(88, 23);
            this.textBoxPlayer2Name.TabIndex = 5;
            this.textBoxPlayer2Name.Text = "Computer";
            this.textBoxPlayer2Name.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            // 
            // boardSizeLabel
            // 
            this.boardSizeLabel.AutoSize = true;
            this.boardSizeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.boardSizeLabel.Location = new System.Drawing.Point(29, 153);
            this.boardSizeLabel.Name = "boardSizeLabel";
            this.boardSizeLabel.Size = new System.Drawing.Size(70, 15);
            this.boardSizeLabel.TabIndex = 6;
            this.boardSizeLabel.Text = "Board Size:";
            this.boardSizeLabel.Click += new System.EventHandler(this.label4_Click);
            // 
            // rowsLabel
            // 
            this.rowsLabel.AutoSize = true;
            this.rowsLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.rowsLabel.Location = new System.Drawing.Point(42, 180);
            this.rowsLabel.Name = "rowsLabel";
            this.rowsLabel.Size = new System.Drawing.Size(41, 15);
            this.rowsLabel.TabIndex = 7;
            this.rowsLabel.Text = "Rows:";
            this.rowsLabel.Click += new System.EventHandler(this.label5_Click);
            // 
            // colsLabel
            // 
            this.colsLabel.AutoSize = true;
            this.colsLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.colsLabel.Location = new System.Drawing.Point(159, 180);
            this.colsLabel.Name = "colsLabel";
            this.colsLabel.Size = new System.Drawing.Size(37, 15);
            this.colsLabel.TabIndex = 8;
            this.colsLabel.Text = "Cols: ";
            // 
            // numRows
            // 
            this.numRows.Location = new System.Drawing.Point(89, 180);
            this.numRows.Maximum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.numRows.Minimum = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.numRows.Name = "numRows";
            this.numRows.Size = new System.Drawing.Size(37, 23);
            this.numRows.TabIndex = 9;
            this.numRows.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.numRows.ValueChanged += new System.EventHandler(this.numRows_ValueChanged);
            // 
            // startButton
            // 
            this.startButton.Location = new System.Drawing.Point(29, 222);
            this.startButton.Name = "startButton";
            this.startButton.Size = new System.Drawing.Size(245, 28);
            this.startButton.TabIndex = 11;
            this.startButton.Text = "Start";
            this.startButton.UseVisualStyleBackColor = true;
            this.startButton.Click += new System.EventHandler(this.buttonStart_Click);
            // 
            // numCols
            // 
            this.numCols.Location = new System.Drawing.Point(212, 180);
            this.numCols.Maximum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.numCols.Minimum = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.numCols.Name = "numCols";
            this.numCols.Size = new System.Drawing.Size(37, 23);
            this.numCols.TabIndex = 9;
            this.numCols.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.numCols.ValueChanged += new System.EventHandler(this.numCols_ValueChanged);
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Location = new System.Drawing.Point(129, 99);
            this.radioButton1.Name = "Medium Level";
            this.radioButton1.Size = new System.Drawing.Size(94, 19);
            this.radioButton1.TabIndex = 13;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "Medium Level";
            this.radioButton1.UseVisualStyleBackColor = true;
            this.radioButton1.Checked = true;
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(129, 125);
            this.radioButton2.Name = "Hard Level";
            this.radioButton2.Size = new System.Drawing.Size(94, 19);
            this.radioButton2.TabIndex = 14;
            this.radioButton2.TabStop = true;
            this.radioButton2.Text = "Hard Level";
            this.radioButton2.UseVisualStyleBackColor = true;
            // 
            // GameSettingsForm
            // 
            this.AcceptButton = this.startButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(282, 257);
            this.Controls.Add(this.radioButton2);
            this.Controls.Add(this.radioButton1);
            this.Controls.Add(this.startButton);
            this.Controls.Add(this.numCols);
            this.Controls.Add(this.numRows);
            this.Controls.Add(this.colsLabel);
            this.Controls.Add(this.rowsLabel);
            this.Controls.Add(this.boardSizeLabel);
            this.Controls.Add(this.textBoxPlayer2Name);
            this.Controls.Add(this.player2Label);
            this.Controls.Add(this.player2CheckBox);
            this.Controls.Add(this.textBoxPlayer1Name);
            this.Controls.Add(this.player1Label);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(298, 296);
            this.MinimumSize = new System.Drawing.Size(298, 296);
            this.Name = "GameSettingsForm";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "Game Settings";
            this.Load += new System.EventHandler(this.GameSettingsForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numRows)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numCols)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label player1Label;
        private System.Windows.Forms.TextBox textBoxPlayer1Name;
        private System.Windows.Forms.CheckBox player2CheckBox;
        private System.Windows.Forms.Label player2Label;
        private System.Windows.Forms.TextBox textBoxPlayer2Name;
        private System.Windows.Forms.Label boardSizeLabel;
        private System.Windows.Forms.Label rowsLabel;
        private System.Windows.Forms.Label colsLabel;
        private System.Windows.Forms.NumericUpDown numRows;
        private System.Windows.Forms.Button startButton;
        private NumericUpDown numCols;
        private RadioButton radioButton1;
        private RadioButton radioButton2;
    }
}