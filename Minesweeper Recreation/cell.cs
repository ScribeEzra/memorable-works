using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibraryMilestone2
{
    public class Cell
    {
        public int row { get; set; }
        public int col { get; set; }
        public bool visited { get; set; }
        public bool live { get; set; }
        public int liveNeighbors { get; set; }

        public Cell()
        {
            this.row = -1;
            this.col = -1;
            this.visited = false;
            this.live = false;
            this.liveNeighbors = 0;
        }
    }
}
