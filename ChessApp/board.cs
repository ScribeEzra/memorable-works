using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessBoardModel
{
    public class Board
    {
        public int Size { get; set; }
        public Cell[,] theGrid { get; set; }

        public Board(int s)
        {
            Size = s;
            theGrid = new Cell[Size, Size];
            for (int c = 0; c < Size; c++)
            {
                for (int r = 0; r < Size; r++)
                {
                    theGrid[r, c] = new Cell(r, c);
                }
            }
        }

        public void markNextLegalMoves(Cell currentCell, string chessPiece)
        {
            //marks legal moves depending on the piece, verifying the move is valid before attempting to mark
            switch (chessPiece)
            {
                case "Knight":
                    validateLegalMove(currentCell.rowNumber - 2, currentCell.columnNumber - 1);
                    validateLegalMove(currentCell.rowNumber - 2, currentCell.columnNumber + 1);
                    validateLegalMove(currentCell.rowNumber - 1, currentCell.columnNumber + 2);
                    validateLegalMove(currentCell.rowNumber + 1, currentCell.columnNumber + 2);
                    validateLegalMove(currentCell.rowNumber + 2, currentCell.columnNumber + 1);
                    validateLegalMove(currentCell.rowNumber + 2, currentCell.columnNumber - 1);
                    validateLegalMove(currentCell.rowNumber + 1, currentCell.columnNumber - 2);
                    validateLegalMove(currentCell.rowNumber - 1, currentCell.columnNumber - 2);
                    break;
                case "King":
                    validateLegalMove(currentCell.rowNumber - 1, currentCell.columnNumber);
                    validateLegalMove(currentCell.rowNumber + 1, currentCell.columnNumber);
                    validateLegalMove(currentCell.rowNumber, currentCell.columnNumber - 1);
                    validateLegalMove(currentCell.rowNumber, currentCell.columnNumber + 1);
                    validateLegalMove(currentCell.rowNumber - 1, currentCell.columnNumber - 1);
                    validateLegalMove(currentCell.rowNumber - 1, currentCell.columnNumber + 1);
                    validateLegalMove(currentCell.rowNumber + 1, currentCell.columnNumber - 1);
                    validateLegalMove(currentCell.rowNumber + 1, currentCell.columnNumber + 1);
                    break;
                case "Queen":
                    for (int i = -Size; i < Size; i++)
                    {
                        validateLegalMove(currentCell.rowNumber - i, currentCell.columnNumber);
                        validateLegalMove(currentCell.rowNumber + i, currentCell.columnNumber);
                        validateLegalMove(currentCell.rowNumber, currentCell.columnNumber - i);
                        validateLegalMove(currentCell.rowNumber, currentCell.columnNumber + i);
                        validateLegalMove(currentCell.rowNumber - i, currentCell.columnNumber - i);
                        validateLegalMove(currentCell.rowNumber - i, currentCell.columnNumber + i);
                        validateLegalMove(currentCell.rowNumber + i, currentCell.columnNumber - i);
                        validateLegalMove(currentCell.rowNumber + i, currentCell.columnNumber + i);
                    }
                    break;
                case "Rook":
                    for (int i = -Size; i < Size; i++)
                    {
                        validateLegalMove(currentCell.rowNumber - i, currentCell.columnNumber);
                        validateLegalMove(currentCell.rowNumber + i, currentCell.columnNumber);
                        validateLegalMove(currentCell.rowNumber, currentCell.columnNumber - i);
                        validateLegalMove(currentCell.rowNumber, currentCell.columnNumber + i);
                    }
                    break;
                case "Bishop":
                    for (int i = -Size; i < Size; i++)
                    {
                        validateLegalMove(currentCell.rowNumber - i, currentCell.columnNumber - i);
                        validateLegalMove(currentCell.rowNumber - i, currentCell.columnNumber + i);
                        validateLegalMove(currentCell.rowNumber + i, currentCell.columnNumber - i);
                        validateLegalMove(currentCell.rowNumber + i, currentCell.columnNumber + i);
                    }
                    break;
                case "Pawn":
                    validateLegalMove(currentCell.rowNumber + 1, currentCell.columnNumber);
                    validateLegalMove(currentCell.rowNumber - 1, currentCell.columnNumber);
                    break;
                default:
                    break;
            }

        }
        public bool validateLegalMove(int r, int c)
        {
            //Checks to see if legal move is on the board
            if (r >= 0 && r < Size && c >= 0 && c < Size)
            {
                theGrid[r, c].legalNextMove = true;
                return true;
            }
            else
            {
                return false;
            }
        }
        public void clearBoard()
        {
            //Clears the board before testing another piece
            for (int c = 0; c < Size; c++)
            {
                for (int r = 0; r < Size; r++)
                {
                    theGrid[r, c].legalNextMove = false;
                    theGrid[r, c].currentlyOccupied = false;
                }
            }
        }
    }
}