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

        private Button[,] m_ButtonMatrix;

        public BoardForm(int i_NumCols, int i_NumRows, ePlayerType i_PlayerType)
        {
            GameBoard = new Board(i_NumCols, i_NumRows);
            Game = new GameLogic(GameBoard);
            Player1 = new Player(eBoardSigns.X, ePlayerType.Human);
            Player2 = new Player(eBoardSigns.O, i_PlayerType);
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
                thisButton.Text = sign.ToString();
                Game.IncreaseTurns();

                int rowNum = (int)thisButton.Tag % GameBoard.MatrixSideSize;
                int colNum = (int)thisButton.Tag / GameBoard.MatrixSideSize;
                GameBoard.MarkCell(sign, colNum, rowNum);
                if (Game.CheckForLoser(colNum, rowNum, sign))
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
            string opponent = "Player 2";
            int player1Score = Player1.Score;
            int player2Score = Player2.Score;
            if (Player2.PlayerType.Equals(ePlayerType.Computer))
            {
                opponent = "Computer";
            }
            this.player1Label.Text = $"Player 1 : {player1Score}";
            this.player2Label.Text = $"{opponent} : {player2Score}";
        }

        private void computerMove(PlayerTurnInfo i_PrevTurnInfo)
        {
            PlayerTurnInfo generatedMove;
            generatedMove = Game.GenerateComputerMove(Player2.Sign, i_PrevTurnInfo);
            m_ButtonMatrix[generatedMove.CellColumn, generatedMove.CellRow].PerformClick();
        }

        private void winningForm(eBoardSigns i_Sign)
        {
            DialogResult result;
            if (i_Sign.Equals(eBoardSigns.O))
            {
                string msg = $"Player 1 Won!{Environment.NewLine}Would you like to play another round?";
                string caption = "Player 1 Won!";
                result = MessageBox.Show(msg, caption, MessageBoxButtons.YesNo);
                Player1.IncreaseScoreByOne();
            }
            else
            {
                string opponent;
                if (Player2.PlayerType.Equals(ePlayerType.Computer))
                {
                    opponent = "Computer";
                }
                else
                {
                    opponent = "Player 2";
                }
                string msg = $"{opponent} Won!{Environment.NewLine}Would you like to play another round?";
                string caption = $"{opponent} Won!";
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