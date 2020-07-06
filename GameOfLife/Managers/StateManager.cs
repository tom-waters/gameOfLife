using System.Collections.Generic;
using System.Linq;

namespace GameOfLife
{
    public class StateManager
    {
        private List<Cell> _previousState = new List<Cell>();
        public List<Cell> CurrentState = new List<Cell>();

        public void RefreshStates()
        {
            _previousState.Clear();
            _previousState.AddRange(CurrentState);
            CurrentState.Clear();
        }

        public void ProcessWorldForCurrentState(World world)
        {
            var cellManager = new CellManager();
            for (int rowIndex = 0; rowIndex < world.Grid.GetLength(1); rowIndex++)
            {
                for (int columnIndex = 0; columnIndex < world.Grid.GetLength(0); columnIndex++)
                {
                    var cell = cellManager.CreateCell(columnIndex, rowIndex);
                    cellManager.AssignNeighbourProperties(cell, world, _previousState);
                    DetermineIfCellShouldLive(cell);
                }
            }
        }

        private void DetermineIfCellShouldLive(Cell cell)
        {
            cell.Live = CellWasLiveIn(_previousState, cell);
            if (!CellMeetsConditionsForLife(cell, cell.Live)) return;
            CurrentState.Add(cell);
        }

        private bool CellWasLiveIn(List<Cell> previousState, Cell cell)
        {
            return previousState.Any(seed => 
                seed.Position.X == cell.Position.X && 
                seed.Position.Y == cell.Position.Y);
        }
        private bool CellMeetsConditionsForLife(Cell cell, bool cellWasLive)
        {
            return ((cellWasLive && cell.LiveNeighbours == 2) || 
                    (cellWasLive && cell.LiveNeighbours == 3) || 
                    (!cellWasLive && cell.LiveNeighbours == 3));
        }
    }
}