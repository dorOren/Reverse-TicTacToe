using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using UI;
using Logic;
using Logic.Enums;

namespace UI
{
    public partial class BoardForm : Form
    {
        public Board GameBoard { get; }
        public GameLogic Game { get; }
        public Player Player1 { get; }
        public Player Player2 { get; }
        public eLevelDifficulty LevelDifficulty { get; set; }

        private Button[,] m_ButtonMatrix;

        public BoardForm(int i_NumCols, int i_NumRows, ePlayerType i_PlayerType, string i_Player1Name, string i_Player2Name, eLevelDifficulty i_LevelDifficulty)
        {
            GameBoard = new Board(i_NumCols, i_NumRows);
            Game = new GameLogic(GameBoard);
            Player1 = new Player(eBoardSigns.X, ePlayerType.Human, i_Player1Name);
            Player2 = new Player(eBoardSigns.O, i_PlayerType, i_Player2Name);
            LevelDifficulty = i_LevelDifficulty;
            int width = (i_NumCols * 42) + 35+80;
            int heigh = (i_NumRows * 42) + 80;
            InitializeComponent(i_NumCols, i_NumRows, width, heigh, i_PlayerType);
        }

        private void buttons_Click(object sender, EventArgs e)
        {
            Button thisButton = (Button)sender;
            eBoardSigns sign;
            if (thisButton.Enabled)
            {
                thisButton.Enabled = false;
                if (Game.Turns % 2 == 0)
                {
                    sign = Player1.Sign;
                }
                else
                {
                    sign = Player2.Sign;
                }
                thisButton.BackColor = Color.LightCoral;
                thisButton.Text = sign.ToString();
                Game.IncreaseTurns();

                int rowNum = (int)thisButton.Tag % GameBoard.MatrixSideSize;
                int colNum = (int)thisButton.Tag / GameBoard.MatrixSideSize;
                GameBoard.MarkCell(sign, colNum, rowNum);

                eBoardSigns loser = Game.CheckForLoser(colNum, rowNum);
                if (!loser.Equals(eBoardSigns.Blank))
                {
                    winningForm(sign);
                }

                else if (Game.CheckIfBoardFilled())
                {
                    tieForm();
                }

                else if (Player2.PlayerType.Equals(ePlayerType.Computer) && Game.Turns % 2 != 0)
                {
                    PlayerTurnInfo turnInfo = new PlayerTurnInfo(colNum,rowNum);
                    computerMove(turnInfo);
                }
            }
        }

        private void updateScore()
        {
            // Updates the score on the screen
            this.player1Label.Text = $"{Player1.PlayerName} : {Player1.Score}";
            this.player2Label.Text = $"{Player2.PlayerName} : {Player2.Score}";
        }

        private void computerMove(PlayerTurnInfo i_PrevTurnInfo)
        {
            PlayerTurnInfo generatedMove;
            if (LevelDifficulty.Equals(eLevelDifficulty.MediumLevel))
                generatedMove = Game.AI_GenerateSymmetricalMove(i_PrevTurnInfo);
            else //LevelDifficulty.Equals(eLevelDifficulty.HardLevel)
                generatedMove = Game.AI_GenerateMinMaxAIMove();
            m_ButtonMatrix[generatedMove.CellColumn, generatedMove.CellRow].PerformClick();
        }

        private void winningForm(eBoardSigns i_Sign)
        {
            DialogResult result;
            if (i_Sign.Equals(eBoardSigns.O))
            {
                string msg = $"{Player1.PlayerName} Won!{Environment.NewLine}Would you like to play another round?";
                string caption = $"{Player1.PlayerName} Won!";
                result = MessageBox.Show(msg, caption, MessageBoxButtons.YesNo);
                Player1.IncreaseScoreByOne();
            }
            else
            {
                string msg = $"{Player2.PlayerName} Won!{Environment.NewLine}Would you like to play another round?";
                string caption = $"{Player2.PlayerName} Won!";
                result = MessageBox.Show(msg, caption, MessageBoxButtons.YesNo);
                Player2.IncreaseScoreByOne();
            }
            if (result == DialogResult.Yes)
            {
                updateScore();
                ClearBoard();
                Game.Turns = 0;
            }
            else
            {
                Application.Exit();
            }
        }

        public void ClearBoard()
        {
            GameBoard.ClearBoard();
            foreach(Button button in m_ButtonMatrix)
            {
                button.Enabled = true;
                button.Text = "";
                button.BackColor = Control.DefaultBackColor;
            }
        }

        private void tieForm()
        {

            string msg = $"Tie!{Environment.NewLine}Would you like to play another round?";
            string caption = "Tie!";
            DialogResult result = MessageBox.Show(msg, caption, MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                ClearBoard();
                Game.Turns = 0;
            }
            else
            {
                Application.Exit();
            }
        }
    }
}