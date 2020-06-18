namespace GameOfLife
{
    public class God
    {
        public void AddSeeds(City[,] world, int columnIndex, int rowIndex)
        {
            world[columnIndex, rowIndex].Live = true;
        }

        public City FetchCity(City[,] world, int columnIndex, int rowIndex)
        {
            return world[columnIndex, rowIndex];
        }

        public bool ApplyLifeRules(City city)
        {
            return city.Live && city.LiveNeighbours == 2 || city.LiveNeighbours == 3;
        }
    }
}