using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Authentication;

namespace GameOfLife
{
    public class Cell
    {
        public Dictionary<string, Coordinates> Neighbours;
        public Coordinates Position;
        public bool Live;
        public int LiveNeighbours;
        
        public Cell(Coordinates position)
        {
            Position = position;
        }
    }
}

