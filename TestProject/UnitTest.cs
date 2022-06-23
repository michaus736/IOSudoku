using SudokuAnalizer;
using System.Linq;
namespace TestProject;

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
        int toErase = 40;

        var gameGrid = Sudoku.CreateGameGrid(grid, toErase);
        if (gameGrid == null) throw new Exception();


        int zeros = gameGrid.Count2D(0);
        

        Assert.True(toErase==zeros);

    }
}