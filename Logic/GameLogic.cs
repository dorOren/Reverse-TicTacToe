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

        private readonly Random m_RandomGenerator = new Random();

        public GameLogic(Board i_Board)
        {
            this.m_GameBoard = i_Board;
        }

        public void IncreaseTurns()
        {
            Turns++;
        }

        public eBoardSigns CheckForLoser(int i_ColumnChosen, int i_RowChosen)
        {
            // Checks and returns a sign that filles a row, column or a diagonal.
            // If no losing condition met, returns the sign "Blank".
            eBoardSigns result = checkForSequenceInColumn(i_ColumnChosen);
            if (result.Equals(eBoardSigns.Blank))
                result = checkForSequenceInRow(i_RowChosen);
            if (result.Equals(eBoardSigns.Blank))
                result = checkForSequenceInDiagonals();
            return result;
        }

        private eBoardSigns checkForSequenceInDiagonals()
        {
            eBoardSigns result = m_GameBoard.GetBoard()[0, 0];

            for (int i = 1; i < m_GameBoard.MatrixSideSize; i++)
            {
                // Look in top-left to bottom-right diagonal.
                if (!m_GameBoard.GetBoard()[i, i].Equals(result))
                {
                    result = eBoardSigns.Blank;
                    break;
                }
            }

            if (result.Equals(eBoardSigns.Blank))
            {
                int cellIndex = m_GameBoard.MatrixSideSize - 1;
                result = m_GameBoard.GetBoard()[0, cellIndex];
                for (int i = 1; i < m_GameBoard.MatrixSideSize; i++)
                {
                    // Look in top-right to bottom-left diagonal.
                    if (!m_GameBoard.GetBoard()[i, --cellIndex].Equals(result))
                    {
                        result = eBoardSigns.Blank;
                        break;
                    }
                }

            }
            return result;
        }

        private eBoardSigns checkForSequenceInRow(int i_RowChosen)
        {
            eBoardSigns result = m_GameBoard.GetBoard()[i_RowChosen, 0];
            for (int i = 1; i < m_GameBoard.MatrixSideSize; i++)
            {
                if (!m_GameBoard.GetBoard()[i_RowChosen, i].Equals(result))
                {
                    result = eBoardSigns.Blank;
                    break;
                }
            }

            return result;
        }

        private eBoardSigns checkForSequenceInColumn(int i_ColumnChosen)
        {
            eBoardSigns result= m_GameBoard.GetBoard()[0, i_ColumnChosen];
            for (int i = 1; i < m_GameBoard.MatrixSideSize; i++)
            {
                if (!m_GameBoard.GetBoard()[i, i_ColumnChosen].Equals(result))
                {
                    result = eBoardSigns.Blank;
                    break;
                }
            }

            return result;
        }


        public PlayerTurnInfo AI_GenerateSymmetricalMove(PlayerTurnInfo i_PrevTurnInfo)
        {
            // In the medium level, the ai chooses vertical symmetrical moves to the player's.
            int matrixSideSize = m_GameBoard.MatrixSideSize;
            PlayerTurnInfo aiMove = new PlayerTurnInfo(matrixSideSize - 1, matrixSideSize - 1);
            if (matrixSideSize % 2 != 0 && i_PrevTurnInfo.CellColumn == (matrixSideSize / 2))
            {
                // If the board's side is odd, we need to consider horizontal symmetrical moves in the middle column.
                aiMove.CellColumn = i_PrevTurnInfo.CellColumn;
                aiMove.CellRow -= i_PrevTurnInfo.CellRow;
            }
            else
            {
                aiMove.CellColumn -= i_PrevTurnInfo.CellColumn;
                aiMove.CellRow = i_PrevTurnInfo.CellRow;
            }
            if (m_GameBoard.GetBoard()[aiMove.CellColumn, aiMove.CellRow].Equals(eBoardSigns.Blank))
            {
                m_GameBoard.MarkCell(eBoardSigns.O, aiMove.CellColumn, aiMove.CellRow);
            }
            else
            {
                // If the ai cant find a symmetrical move -> it uses random.
                while (!m_GameBoard.GetBoard()[aiMove.CellColumn, aiMove.CellRow].Equals(eBoardSigns.Blank))
                {
                    aiMove.CellColumn = m_RandomGenerator.Next(m_GameBoard.MatrixSideSize);
                    aiMove.CellRow = m_RandomGenerator.Next(m_GameBoard.MatrixSideSize);
                }
                m_GameBoard.MarkCell(eBoardSigns.O, aiMove.CellColumn, aiMove.CellRow);
            }

            return aiMove;
        }

        public PlayerTurnInfo AI_GenerateMinMaxAIMove()
        {
            // In the hard level, the ai chooses the best possible move considering all possible moves from all turns ahead.
            // Using a recursion, this method explores all possible paths and returns values representing the end of each;
            // A +1 is a win for the ai, -1 is a lose, and a 0 is a tie.
            // Each turn the ai will choose the path that will have more chance to to end with a win (= +1);
            PlayerTurnInfo bestMove = new PlayerTurnInfo();
            int matrixSideSize = m_GameBoard.MatrixSideSize;
            int score = 0;
            int bestScore = -1000;

            for (int i = 0; i < matrixSideSize; i++)
            {
                for (int j = 0; j < matrixSideSize; j++)
                {
                    if (m_GameBoard.GetSignOfCell(j, i).Equals(eBoardSigns.Blank))
                    {
                        // Mark cell, call recursion, and clear cell to former state while remembering the score given from choosing that cell.
                        m_GameBoard.MarkCell(eBoardSigns.O, j, i);
                        score = ai_generateMinMaxAIMoveRec(new PlayerTurnInfo(j, i), 0, false);
                        m_GameBoard.ClearCell(j, i);
                        if (score > bestScore)
                        {
                            bestScore = score;
                            bestMove.CellRow = i;
                            bestMove.CellColumn = j;
                        }
                    }
                }
            }
            return bestMove;
        }

        private int ai_generateMinMaxAIMoveRec(PlayerTurnInfo i_PrevTurnInfo, int i_Depth, bool i_IsMaximizing)
        {
            // End condition- return +1 if ai wins, -1 if ai loses or 0 in ties.
            eBoardSigns res = CheckForLoser(i_PrevTurnInfo.CellColumn, i_PrevTurnInfo.CellRow);
            int score = 0;
            int bestScore;

            if (!res.Equals(eBoardSigns.Blank))
            {
                if (res.Equals(eBoardSigns.X))
                    score = 1;
                else //res.Equals(eBoardSigns.O)
                    score = -1;
                return score;
            }
            if (CheckIfBoardFilled())
                return 0;

            int matrixSideSize = m_GameBoard.MatrixSideSize;
            if (i_IsMaximizing)
            {
                // Here we want to maximize ai's score
                bestScore = -1000;
                for (int i = 0; i < matrixSideSize; i++)
                {
                    for (int j = 0; j < matrixSideSize; j++)
                    {
                        if (m_GameBoard.GetBoard()[i, j].Equals(eBoardSigns.Blank))
                        {
                            m_GameBoard.MarkCell(eBoardSigns.O, j, i);
                            score = ai_generateMinMaxAIMoveRec(new PlayerTurnInfo(j, i), i_Depth + 1, false);
                            m_GameBoard.ClearCell(j, i);
                            bestScore = Math.Max(score, bestScore);
                        }
                    }
                }
            }

            else //isMinimizing
            {
                bestScore = 1000;
                for (int i = 0; i < matrixSideSize; i++)
                {
                    for (int j = 0; j < matrixSideSize; j++)
                    {
                        if (m_GameBoard.GetBoard()[i, j].Equals(eBoardSigns.Blank))
                        {
                            // Here we want to minimize player's score
                            m_GameBoard.MarkCell(eBoardSigns.X, j, i);
                            score = ai_generateMinMaxAIMoveRec(new PlayerTurnInfo(j, i), i_Depth + 1, true);
                            m_GameBoard.ClearCell(j, i);
                            bestScore = Math.Min(score, bestScore);
                        }
                    }
                }
            }

            return bestScore;
        }

        public bool CheckIfBoardFilled()
        {
            return m_GameBoard.NumberOfBlankCells == 0;
        }

    }
}