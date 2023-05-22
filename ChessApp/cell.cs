using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessBoardModel
{
    public class Cell
    {
        public int rowNumber { get; set; }
        public int columnNumber { get; set; }
        public bool currentlyOccupied { get; set; }
        public bool legalNextMove { get; set; }

        public Cell(int r, int c)
        {
            this.rowNumber = r;
            this.columnNumber = c;
            this.currentlyOccupied = false;
            this.legalNextMove = false;
        }

    }
}