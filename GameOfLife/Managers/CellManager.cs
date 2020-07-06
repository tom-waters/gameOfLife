using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace GameOfLife
{
    public class CellManager
    {

        public Cell CreateCell(int columnIndex, int rowIndex)
        {
            return new Cell(new Coordinates(columnIndex, rowIndex));
        }

        public void AssignNeighbourProperties(Cell cell, World world, List<Cell> state)
        {
            cell.Neighbours = Neighbours.FindNeighbours(cell, world);
            cell.LiveNeighbours = SetNumberOfLiveNeighbours(state, cell);
        }
        
        private int SetNumberOfLiveNeighbours(List<Cell> previousState, Cell cell)
        {
            cell.LiveNeighbours = 0;
            return cell.Neighbours.Count(neighbour => previousState.Any(city => neighbour.Value.X == city.Position.X && neighbour.Value.Y == city.Position.Y));
        }
    }
}