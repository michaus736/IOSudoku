using SudokuAnalizer;

namespace TestProject
{
    public class UnitTest
    {
        [Fact]
        public void Test()
        {
            int[,] grid = new int[9, 9];
            for(int i = 0; i < grid.GetLength(0); i++)
            {
                for(int j = 0; j < grid.GetLength(1); j++)
                {
                    grid[i, j] = 0;
                }
            }

            
            Assert.Equal(grid.GetLength(0), grid.GetLength(1));
        }
    }
}