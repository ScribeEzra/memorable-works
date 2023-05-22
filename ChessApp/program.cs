using ChessBoardModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessBoardConsoleApp
{
    class Program
    {
        static Board gameBoard = new Board(8);
        static void Main(string[] args)
        {
            bool gameEnd = false;
            
            while (!gameEnd)
            {
                //Show the empty chess board
                Console.Out.WriteLine("This is the game board:");
                printBoard(gameBoard);
                //Get the location of the chess piece
                Cell chosenPiece = setCurrentCell();
                //Calculate and mark the cells where legal moves are possible
                string role = confirmPiece();
                gameBoard.markNextLegalMoves(chosenPiece, role);
                //Show the chess board using . as an empty square, X for the piece location, and + for legal
                Console.Out.WriteLine("You chose to place a {0} at cell {1}, {2}", role, chosenPiece.rowNumber.ToString(), chosenPiece.columnNumber.ToString());
                Console.Out.WriteLine("Your piece can make these legal moves:");
                printBoard(gameBoard);

                //Ask if user wishes to test another piece
                int userInput = -1;
                while (userInput < 0 || userInput > 1)
                {
                    Console.Out.WriteLine("Do you wish to test another piece?");
                    Console.Out.WriteLine("0 - No");
                    Console.Out.WriteLine("1 - Yes");

                    try
                    {
                        userInput = int.Parse(Console.ReadLine());
                    }
                    catch (Exception e)
                    {
                        Console.Out.WriteLine(e.Message);
                    }
                    if (userInput < 0 || userInput > 1)
                    {
                        Console.Out.WriteLine("Please make a valid choice.");
                    }
                }
                if (userInput == 0)
                {
                    Console.Out.WriteLine("Ending Program...");
                    gameEnd = true;
                }
                else
                {
                    Console.Out.WriteLine("Testing Another Piece...");
                    gameEnd = false;
                }
                gameBoard.clearBoard();
            }

        }

        public static void printBoard(Board gameBoard)
        {
            //. = Empty square
            //X = Piece location
            //+ = Legal move

            int rowNum = 0;
            int colNum = 0;

            Console.Out.Write("    ");
            for (int i = 0; i < gameBoard.Size; i++)
            {
                Console.Out.Write("c{0}  ", colNum);
                colNum++;
            }
            Console.Out.Write(Environment.NewLine);

            Console.Out.Write("   |");
            for (int i = 0; i < gameBoard.Size - 1; i++)
            {
                Console.Out.Write("====");
            }
            Console.Out.Write("===");
            Console.Out.Write("|");
            Console.Out.Write(Environment.NewLine);

            for (int i = 0; i < gameBoard.Size; i++)
            {
                Console.Out.Write("r{0} | ", rowNum);
                rowNum++;
                for (int j = 0; j < gameBoard.Size; j++)
                {
                    if (gameBoard.theGrid[i, j].currentlyOccupied)
                    {
                        Console.Out.Write("X ");
                    }
                    else if (gameBoard.theGrid[i, j].legalNextMove)
                    {
                        Console.Out.Write("+ ");
                    }
                    else
                    {
                        Console.Out.Write(". ");
                    }
                    Console.Out.Write("| ");
                }
                Console.Out.Write(Environment.NewLine);
                if (i < gameBoard.Size - 1)
                {
                    Console.Out.Write("   |");
                    for (int k = 0; k < gameBoard.Size - 1; k++)
                    {
                        Console.Out.Write("----");
                    }
                    Console.Out.Write("---");
                    Console.Out.Write("|");
                    Console.Out.Write(Environment.NewLine);
                }
                
            }

            Console.Out.Write("   |");
            for (int i = 0; i < gameBoard.Size - 1; i++)
            {
                Console.Out.Write("====");
            }
            Console.Out.Write("===");
            Console.Out.Write("|");
            Console.Out.Write(Environment.NewLine);
        }

        public static Cell setCurrentCell()
        {
            //Sets currentlyOccupied on cell chosen by user
            //Added try/catch exception handling
            int currentRow = -1;
            int currentColumn = -1;
            Console.Out.WriteLine("Enter your current piece's row.");
            try
            {
                currentRow = int.Parse(Console.ReadLine());
            }
            catch (Exception e)
            {
                Console.Out.WriteLine(e.Message);
            }

            Console.Out.WriteLine("Enter your current piece's column.");
            try
            {
                currentColumn = int.Parse(Console.ReadLine());
            }
            catch (Exception e)
            {
                Console.Out.WriteLine(e.Message);
            }

            while ((validatePlacement(currentRow, currentColumn, gameBoard)) == false)
            {
                Console.Out.WriteLine("Enter your current piece's row.");
                try
                {
                    currentRow = int.Parse(Console.ReadLine());
                }
                catch (Exception e)
                {
                    Console.Out.WriteLine(e.Message);
                }

                Console.Out.WriteLine("Enter your current piece's column.");
                try
                {
                    currentColumn = int.Parse(Console.ReadLine());
                }
                catch (Exception e)
                {
                    Console.Out.WriteLine(e.Message);
                }
                
            }

            return gameBoard.theGrid[currentRow, currentColumn];
        }
        public static bool validatePlacement(int r, int c, Board b)
        {
            //Checks to see if placement is in range
            if (r >= 0 && r < b.Size && c >= 0 && c < b.Size)
            {
                b.theGrid[r, c].currentlyOccupied = true;
                return true;
            }
            else
            {
                Console.Out.WriteLine("Row/Column Out of Bounds.");
                return false;
            }
        }

        public static string confirmPiece()
        {
            //Confirms the role of the chosen piece
            //Added try/catch exception handling
            int chosenPiece = -1;
            while (chosenPiece < 0 || chosenPiece > 6)
            {
                Console.Out.WriteLine("What kind of chess piece is your piece?");
                Console.Out.WriteLine("0 - Knight");
                Console.Out.WriteLine("1 - King");
                Console.Out.WriteLine("2 - Queen");
                Console.Out.WriteLine("3 - Rook");
                Console.Out.WriteLine("4 - Bishop");
                Console.Out.WriteLine("5 - Pawn");

                try
                {
                    chosenPiece = int.Parse(Console.ReadLine());
                }
                catch (Exception e)
                {
                    Console.Out.WriteLine(e.Message);
                }
                

                if (chosenPiece < 0 || chosenPiece > 6)
                {
                    Console.Out.WriteLine("Please make a valid choice.");
                }
            }

            switch (chosenPiece)
            {
                case 0:
                    return "Knight";
                    break;
                case 1:
                    return "King";
                    break;
                case 2:
                    return "Queen";
                    break;
                case 3:
                    return "Rook";
                    break;
                case 4:
                    return "Bishop";
                    break;
                case 5:
                    return "Pawn";
                    break;
                default:
                    return "Knight";
                    break;
            }

        }
    }
}