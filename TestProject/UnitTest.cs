using SudokuAnalizer;
using System.Linq;
namespace TestProject
{
    public class UnitTest
    {
        [Fact]
        public void GenerateGridTest()
        {

            var grid = Sudoku.GenerateSudokuGrid();

            Assert.True(Sudoku.IsValid(grid));
        }

        [Fact]
        public void CreateGameGrid()
        {
            var grid = Sudoku.GenerateSudokuGrid();
            int toErase = 15;

            var gameGrid = Sudoku.CreateGameGrid(grid, toErase);
            if (gameGrid == null) throw new Exception();


            int zeros = 0;
            for(int i = 0; i < gameGrid.GetLength(0); i++)
            {
                for(int j=0; j < gameGrid.GetLength(1); j++)
                {
                    if (gameGrid[i,j] == 0) zeros++;
                }
            }

            Assert.True(toErase==zeros);

        }
    }
}