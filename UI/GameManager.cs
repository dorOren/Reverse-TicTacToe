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
        public void Start()
        {
            getGameSettingsFromUser();
        }

        private void getGameSettingsFromUser()
        {
            GameSettingsForm gameSettingsForm = new GameSettingsForm();
            gameSettingsForm.ShowDialog();
            string player1Name;
            string player2Name;
            int numRows;
            int numCols;
            eLevelDifficulty radioButton= eLevelDifficulty.None;
            ePlayerType playerType;
            if (gameSettingsForm.DialogResult == DialogResult.OK)
            {
                player1Name = gameSettingsForm.Player1Name;
                numRows = gameSettingsForm.NumRows;
                numCols = gameSettingsForm.NumCols;
                player2Name = gameSettingsForm.Player2Name;
                if (gameSettingsForm.Player2CheckBox)
                {
                    playerType = ePlayerType.Human;
                }
                else
                {
                    playerType = ePlayerType.Computer;
                    if (gameSettingsForm.RadioButton == 1)
                        radioButton = eLevelDifficulty.MediumLevel;
                    else
                        radioButton = eLevelDifficulty.HardLevel;
                }
                BoardForm board = new BoardForm(numCols, numRows, playerType, player1Name, player2Name, radioButton);
                board.ShowDialog();
            }
        }
    }
}