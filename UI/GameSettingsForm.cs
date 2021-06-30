using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace UI
{
    public partial class GameSettingsForm : Form
    {
        public int RadioButton
        {
            get
            {
                if (radioButton1.Checked)
                    return 1;
                else
                    return 2;
            }
        }

        public Boolean Player2CheckBox
        {
            get
            {
                return player2CheckBox.Checked;
            }
        }

        public string Player1Name
        {
            get
            {
                return textBoxPlayer1Name.Text;
            }
        }

        public string Player2Name
        {
            get
            {
                return textBoxPlayer2Name.Text;
            }
        }

        public int NumRows
        {
            set { }
            get
            {
                return (int)numRows.Value;
            }
        }
        public int NumCols
        {
            set { }
            get
            {
                return (int)numCols.Value;
            }
        }

        public GameSettingsForm()
        {
            InitializeComponent();
        }


        private void textBox2_TextChanged(object sender, EventArgs e)
        {
        }

        private void label5_Click(object sender, EventArgs e)
        {
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
        }

        private void buttonStart_Click(object sender, EventArgs e)
        {

            if (this.textBoxPlayer1Name.Text.Equals("") || this.textBoxPlayer2Name.Text.Equals(""))
            {
                MessageBox.Show("Illegal name input. Try again.");
            }
            else
            {
                this.DialogResult = DialogResult.OK;
            }
        }

        private void numRows_ValueChanged(object sender, EventArgs e)
        {
            if (this.numRows.Value != this.numCols.Value)
            {
                this.numCols.Value = this.numRows.Value;
            }
        }

        private void numCols_ValueChanged(object sender, EventArgs e)
        {
            if (this.numRows.Value != this.numCols.Value)
            {
                this.numRows.Value = this.numCols.Value;
            }

            if (this.numCols.Value != 3)
                this.radioButton2.Visible = false;
            else // this.numCols.Value == 3
                this.radioButton2.Visible = true;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (this.player2CheckBox.Checked)
            {
                this.textBoxPlayer2Name.Enabled = true;
                this.textBoxPlayer2Name.Clear();
                this.radioButton1.Visible = false;
                this.radioButton2.Visible = false;
            }
            else
            {
                this.textBoxPlayer2Name.Enabled = false;
                this.textBoxPlayer2Name.Text = "Computer";
                this.radioButton1.Visible = true;
                if (this.numCols.Value == 3)
                    this.radioButton2.Visible = true;
            }
        }

        private void GameSettingsForm_Load(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }
}
