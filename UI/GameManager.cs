using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace UI
{
    public class GameManager
    {
        private string m_Player1Name;
        public string Player1Name
        {
            get
            {
                return m_Player1Name;
            }
            set
            {
                m_Player1Name = value;
            }
        }

        public void Start()
        {
            getGameSettingsFromUser();

        }

        private void getGameSettingsFromUser()
        {
            GameSettingsForm gameSettingsForm = new GameSettingsForm();
            gameSettingsForm.ShowDialog();
            string player1Name;
            int numRows;
            int numCols;
            if (gameSettingsForm.DialogResult == DialogResult.OK)
            {
                player1Name = gameSettingsForm.Player1Name;
                numRows = gameSettingsForm.NumRows;
                numCols = gameSettingsForm.NumCols;
                BoardForm board = new BoardForm(numCols, numRows);
                board.ShowDialog();
            }



        }
    }
}