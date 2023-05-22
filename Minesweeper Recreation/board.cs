using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibraryMilestone2
{
    public class Board
    {
        public int size { get; set; }
        public Cell[,] grid;

        public Board(int s)
        {
            this.size = s;
            grid = new Cell[size, size];
        }

        public Board()
        {
            this.size = 10;
            grid = new Cell[size, size];
        }

        public void setLiveNeighbors()
        {
            int difficulty = 20;

            Random random = new Random();

            int generatedNumber;

            int currentRow = 0;
            int currentCol = 0;

            foreach (var cell in grid)
            {
                Cell newCell = new Cell();
                newCell.row = currentRow;
                newCell.col = currentCol;
                newCell.visited = false;
                generatedNumber = random.Next(0, 101);

                if (generatedNumber <= difficulty)
                { 
                    newCell.live = true; 
                }
                if (generatedNumber > difficulty)
                {
                    newCell.live = false;
                }

                grid[currentRow, currentCol] = newCell;

                currentRow++;
                if (currentRow >= this.size)
                {
                    currentRow = 0;
                    currentCol += 1;
                }
            }
        }
        public void setLiveNeighbors(int d)
        {
            int difficulty = d;

            Random random = new Random();

            int generatedNumber;

            int currentRow = 0;
            int currentCol = 0;

            foreach (var cell in grid)
            {
                Cell newCell = new Cell();
                newCell.row = currentRow;
                newCell.col = currentCol;
                newCell.visited = false;
                generatedNumber = random.Next(0, 101);

                if (generatedNumber <= difficulty)
                {
                    newCell.live = true;
                }
                if (generatedNumber > difficulty)
                {
                    newCell.live = false;
                }

                grid[currentRow, currentCol] = newCell;

                currentRow++;
                if (currentRow >= this.size)
                {
                    currentRow = 0;
                    currentCol += 1;
                }
            }
        }

        public void calculateLiveNeighbors()
        {
            foreach (var cell in grid)
            {
                
                int liveCount = 0;


                for (int i = -1; i < 2; i++)
                {
                    if (cell.col + i > -1 && cell.col + i < this.size)
                    for (int j = -1; j < 2; j++)
                    {
                        if (cell.row + j > -1 && cell.row + j < this.size)
                        {
                            Cell neighbor = grid[cell.row + j, cell.col + i];
                            if (neighbor.live == true)
                            {
                                liveCount += 1;
                            }
                        }
                    }
                }
                cell.liveNeighbors = liveCount;
                    
            }
        }
    }
}