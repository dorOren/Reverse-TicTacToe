using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Logic.Enums;

namespace Logic
{
    public class GameLogic
    {
        private readonly Board m_GameBoard;
        public int Turns { get; set; }

        private Random m_RandomGenerator = new Random();

        public GameLogic(Board i_Board)
        {
            this.m_GameBoard = i_Board;
        }

        public void IncreaseTurns()
        {
            Turns++;
        }

        public bool CheckForLoser(int i_ColumnChosen, int i_RowChosen, eBoardSigns i_MarkedSign)
        {
            return (checkForSequenceInColumn(i_ColumnChosen, i_MarkedSign)
                    || checkForSequenceInRow(i_RowChosen, i_MarkedSign) || checkForSequenceInDiagonals(i_MarkedSign));
        }

        private bool checkForSequenceInDiagonals(eBoardSigns i_MarkedSign)
        {
            bool foundSequence = true;
            for (int i = 0; i < m_GameBoard.MatrixSideSize; i++) // Check main diagonal. 
            {
                if (m_GameBoard.GetBoard()[i, i] != i_MarkedSign)
                {
                    foundSequence = false;
                    break;
                }
            }

            if (!foundSequence) // Check secondary diagonal.
            {
                int cellIndex = m_GameBoard.MatrixSideSize - 1;
                for (int i = 0; i < m_GameBoard.MatrixSideSize; i++)
                {

                    if (m_GameBoard.GetBoard()[i, cellIndex--] != i_MarkedSign)
                    {
                        foundSequence = false;
                        break;
                    }
                }

            }
            return foundSequence;
        }

        private bool checkForSequenceInRow(int i_RowChosen, eBoardSigns i_MarkedSign)
        {
            bool result = true;
            for (int i = 0; i < m_GameBoard.MatrixSideSize; i++)
            {
                if (m_GameBoard.GetBoard()[i_RowChosen, i] != i_MarkedSign)
                {
                    result = false;
                    break;
                }
            }

            return result;
        }

        private bool checkForSequenceInColumn(int i_ColumnChosen, eBoardSigns i_MarkedSign)
        {
            bool result = true;
            for (int i = 0; i < m_GameBoard.MatrixSideSize; i++)
            {
                if (m_GameBoard.GetBoard()[i, i_ColumnChosen] != i_MarkedSign)
                {
                    result = false;
                    break;
                }
            }

            return result;
        }


        public PlayerTurnInfo GenerateComputerMove(eBoardSigns i_ComputerSign, PlayerTurnInfo i_PrevTurnInfo)
        {
            int matrixSideSize = m_GameBoard.MatrixSideSize;
            PlayerTurnInfo aiMove = new PlayerTurnInfo(matrixSideSize - 1, matrixSideSize - 1);
            if (matrixSideSize % 2 != 0 && i_PrevTurnInfo.CellColumn == (matrixSideSize / 2))
            {
                aiMove.CellColumn = i_PrevTurnInfo.CellColumn;
                aiMove.CellRow -= i_PrevTurnInfo.CellRow;
            }
            else
            {
                aiMove.CellColumn -= i_PrevTurnInfo.CellColumn;
                aiMove.CellRow = i_PrevTurnInfo.CellRow;
            }
            if (m_GameBoard.GetSignOfCell(aiMove.CellColumn, aiMove.CellRow).Equals(eBoardSigns.Blank))
            {
                m_GameBoard.MarkCell(i_ComputerSign, aiMove.CellColumn, aiMove.CellRow);
            }
            else
            {
                while (!m_GameBoard.GetSignOfCell(aiMove.CellColumn, aiMove.CellRow).Equals(eBoardSigns.Blank))
                {
                    aiMove.CellColumn = m_RandomGenerator.Next(m_GameBoard.MatrixSideSize);
                    aiMove.CellRow = m_RandomGenerator.Next(m_GameBoard.MatrixSideSize);
                }
                m_GameBoard.MarkCell(i_ComputerSign, aiMove.CellColumn, aiMove.CellRow);
            }

            return aiMove;
        }

        private PlayerTurnInfo chooseRandomCell()
        {
            PlayerTurnInfo result = new PlayerTurnInfo();
            Random rand = new Random();
            result.CellColumn = rand.Next(0, m_GameBoard.MatrixSideSize);
            result.CellRow = rand.Next(0, m_GameBoard.MatrixSideSize);
            return result;
        }

        public bool CheckIfBoardFilled()
        {
            return m_GameBoard.NumberOfBlankCells == 0;
        }

    }
}