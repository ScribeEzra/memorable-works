using ClassLibraryMilestone2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppMilestone2
{
    class Program
    {
        public static void Main(string[] args)
        {
            bool gameEnd = false;
            while (!gameEnd)
            {
                //Set up the game board
                Board board = new Board(10);
                board.setLiveNeighbors(25);
                board.calculateLiveNeighbors();

                //Start the game
                gameLoop(board);


                //Game is over, ask player if they want to play again
                Console.Out.WriteLine("Play Again?");
                Console.Out.WriteLine("0 - No");
                Console.Out.WriteLine("1 - Yes");

                int playerInput = -1;

                while (playerInput < 0 || playerInput > 1)
                {
                    try
                    {
                        int.Parse(Console.ReadLine());
                }
                    catch (Exception e)
                    {
                        Console.Out.WriteLine(e.Message);
                    }
                    if (playerInput < 0 || playerInput > 1)
                    {
                        Console.Out.WriteLine("Please make a valid selection.");
                    }
                }
                if (playerInput == 0)
                {
                    Console.Out.WriteLine("Ending Program...");
                    Console.Out.WriteLine(Environment.NewLine);
                    gameEnd = true;
                }
                if (playerInput == 1)
                {
                    Console.Out.WriteLine("Starting a new game...");
                    Console.Out.WriteLine(Environment.NewLine);
                    gameEnd = false;
                }
            }
            
            
        }

        public static void printBoard(Board b)
        {
            Console.Out.Write("    ");
            int column = 0;
            for (int i = 0; i < b.size; i++)
            {
                Console.Out.Write(" c{0} ", column);
                column++;
            }
            Console.Out.Write(Environment.NewLine);

            Console.Out.Write("   +");
            for (int i = 0; i < b.size; i++)
            {
                Console.Out.Write(" - +");
            }
            Console.Out.Write(Environment.NewLine);
            for (int r = 0; r < b.size; r++)
            {
                Console.Out.Write("r{0} ", r);
                Console.Out.Write("|");
                for (int c = 0; c < b.size; c++)
                {
                    if (b.grid[r, c].live == true)
                    {
                        Console.Out.Write(" * |");
                    }
                    else
                    {
                        Console.Out.Write(" " + b.grid[r, c].liveNeighbors + " |");
                    }
                }
                Console.Out.Write(Environment.NewLine);
                Console.Out.Write("   +");
                for (int i = 0; i < b.size; i++)
                {
                    Console.Out.Write(" - +");
                }
                Console.Out.Write(Environment.NewLine);
            }
        }
        public static void printVisitedInGame(Board b)
        {
            Console.Out.Write("    ");
            int column = 0;
            for (int i = 0; i < b.size; i++)
            {
                Console.Out.Write(" c{0} ", column);
                column++;
            }
            Console.Out.Write(Environment.NewLine);

            Console.Out.Write("   +");
            for (int i = 0; i < b.size; i++)
            {
                Console.Out.Write(" - +");
            }
            Console.Out.Write(Environment.NewLine);
            for (int r = 0; r < b.size; r++)
            {
                Console.Out.Write("r{0} ", r);
                Console.Out.Write("|");
                for (int c = 0; c < b.size; c++)
                {
                    if (b.grid[r, c].visited == false)
                    {
                        Console.Out.Write(" ? |");
                    }
                    else if (b.grid[r, c].live == true)
                    {
                        Console.Out.Write(" * |");
                    }
                    else if (b.grid[r, c].liveNeighbors == 0)
                    {
                        Console.Out.Write("   |");
                    }
                    else
                    {
                        Console.Out.Write(" " + b.grid[r, c].liveNeighbors + " |");
                    }
                }
                Console.Out.Write(Environment.NewLine);
                Console.Out.Write("   +");
                for (int i = 0; i < b.size; i++)
                {
                    Console.Out.Write(" - +");
                }
                Console.Out.Write(Environment.NewLine);
            }
        }
        public static void gameLoop(Board b)
        {
            Console.Out.WriteLine("                 Game Start!");
            bool gameComplete = false;
            printVisitedInGame(b);
            while (!gameComplete)
            {
                int rInput = -1;
                int cInput = -1;
                Console.Out.WriteLine("Decide on a cell you wish to check...");
                while (rInput < 0 || rInput >= b.size)
                {
                    Console.Out.WriteLine("Input the row of the cell you wish to check.");
                    try
                    {
                        rInput = int.Parse(Console.ReadLine());
                    }
                    catch(Exception e)
                    {
                        Console.Out.WriteLine(e.Message);
                        Console.Out.Write(Environment.NewLine);
                    }
                    if (rInput < 0 || rInput >= b.size)
                    {
                        Console.Out.WriteLine("Please select a valid row.");
                        Console.Out.Write(Environment.NewLine);
                    }
                }
                Console.Out.WriteLine("You decided on the row {0}", rInput);
                while (cInput < 0 || cInput >= b.size)
                {
                    Console.Out.WriteLine("Input the column of the cell you wish to check.");
                    try
                    {
                        cInput = int.Parse(Console.ReadLine());
                        Console.Out.Write(Environment.NewLine);
                    }
                    catch (Exception e)
                    {
                        Console.Out.WriteLine(e.Message);
                    }
                    if (cInput < 0 || cInput >= b.size)
                    {
                        Console.Out.WriteLine("Please select a valid column.");
                        Console.Out.Write(Environment.NewLine);
                    }
                }
                Console.Out.WriteLine("You decided on the column {0}", cInput);
                Console.Out.WriteLine("Checking {0}, {1}", rInput, cInput);
                if (b.grid[rInput, cInput].visited)
                {
                    Console.Out.WriteLine("Cell has already been checked.");
                    Console.Out.WriteLine("Please chose another cell.");
                    Console.Out.Write(Environment.NewLine);
                }
                else
                {
                    b.grid[rInput, cInput].visited = true;
                    printVisitedInGame(b);

                    //lose if cell was a bomb
                    if (b.grid[rInput, cInput].live)
                    {
                        gameOver(b);
                        gameComplete = true;
                    }
                    //helper method that checks if the board has been cleared
                    if (boardIsClear(b))
                    {
                        gameWin(b);
                        gameComplete = true;
                    }
                    Console.Out.Write(Environment.NewLine);
                }

            }
        }
        public static bool boardIsClear(Board b)
        {
            bool clear = true;
            for (int r = 0; r < b.size; r++)
            {
                for (int c = 0; c < b.size; c++)
                {
                    if (!b.grid[r, c].visited && !b.grid[r, c].live)
                    {
                        clear = false;
                    }
                }
            }
            return clear;
        }
        public static void gameOver(Board b)
        {
            Console.Out.WriteLine("You Detonated a Bomb!");
            Console.Out.WriteLine("                 Game Over!");
            printBoard(b);
        }
        public static void gameWin(Board b)
        {
            Console.Out.WriteLine("You Cleared the Board Without Detonating a Bomb!");
            Console.Out.WriteLine("                 You Win!");
            printBoard(b);
        }
    }
}