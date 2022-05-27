using SudokuAnalizer;

namespace TestProject
{
    public class UnitTest
    {
        [Fact]
        public void Test()
        {

            var grid = Sudoku.GenerateSudokuGrid();

            Assert.True(Sudoku.IsValid(grid));
        }
    }
}