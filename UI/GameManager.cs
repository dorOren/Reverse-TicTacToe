using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using Logic;
using Logic.Enums;

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
            ePlayerType playerType;
            if (gameSettingsForm.DialogResult == DialogResult.OK)
            {
                player1Name = gameSettingsForm.Player1Name;
                numRows = gameSettingsForm.NumRows;
                numCols = gameSettingsForm.NumCols;
               if(gameSettingsForm.Player2CheckBox)
                {
                    playerType = ePlayerType.Human;
                }
                else
                {
                    playerType = ePlayerType.Computer;
                }
                BoardForm board = new BoardForm(numCols, numRows, playerType);
                board.ShowDialog();
            }



        }
    }
}