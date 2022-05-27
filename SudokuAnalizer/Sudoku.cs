using Medallion;

namespace SudokuAnalizer
{
    public class Sudoku
    {

        static int counter = 0;

        public static void FillSudoku(int[,] grid)
        {
            if (grid.GetLength(0) != grid.GetLength(1)) throw new ArgumentException("grid doesn't have the same dimention size");

            int N = 9 * 9;
            for(int i = 0; i < N; i++)
            {
                int row = i / 9;
                int col = i % 9;
                if(grid[row,col] == 0)
                {
                    int[] numbers = new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
                    numbers = numbers.Shuffled().ToArray();
                    foreach (var value in numbers)
                    {
                        
                        if (!grid.SliceRow(row).Any(item => item == value))
                        {
                            if(!grid.SliceColumn(col).Any(item => item == value))
                            {
                                int[] square = new int[9];
                                List<int> list = new List<int>();
                                int squareCounter = 0;
                                if(row < 3)
                                {
                                    if(col < 3)
                                    {
                                        for(int loop = 0; loop < 3; loop++)
                                        {
                                            for(int innerLoop=0;innerLoop < 3; innerLoop++)
                                            {
                                                square[squareCounter++] = grid[loop, innerLoop];
                                                list.Add(grid[loop, innerLoop]);
                                            }
                                        }
                                    }
                                    else if(col < 6)
                                    {
                                        for (int loop = 0; loop < 3; loop++)
                                        {
                                            for (int innerLoop = 3; innerLoop < 6; innerLoop++)
                                            {
                                                square[squareCounter++] = grid[loop, innerLoop];
                                                list.Add(grid[loop, innerLoop]);
                                            }
                                        }
                                    }
                                    else
                                    {
                                        for (int loop = 0; loop < 3; loop++)
                                        {
                                            for (int innerLoop = 6; innerLoop < 9; innerLoop++)
                                            {
                                                square[squareCounter++] = grid[loop, innerLoop];
                                                list.Add(grid[loop, innerLoop]);
                                            }
                                        }
                                    }
                                }
                                else if (row < 6)
                                {
                                    if (col < 3)
                                    {
                                        for (int loop = 3; loop < 6; loop++)
                                        {
                                            for (int innerLoop = 0; innerLoop < 3; innerLoop++)
                                            {
                                                square[squareCounter++] = grid[loop, innerLoop];
                                                list.Add(grid[loop, innerLoop]);
                                            }
                                        }
                                    }
                                    else if (col < 6)
                                    {
                                        for (int loop = 3; loop < 6; loop++)
                                        {
                                            for (int innerLoop = 3; innerLoop < 6; innerLoop++)
                                            {
                                                square[squareCounter++] = grid[loop, innerLoop];
                                                list.Add(grid[loop, innerLoop]);
                                            }
                                        }
                                    }
                                    else
                                    {
                                        for (int loop = 3; loop < 6; loop++)
                                        {
                                            for (int innerLoop = 6; innerLoop < 9; innerLoop++)
                                            {
                                                square[squareCounter++] = grid[loop, innerLoop];
                                                list.Add(grid[loop, innerLoop]);
                                            }
                                        }
                                    }
                                }
                                else
                                {
                                    if (col < 3)
                                    {
                                        for (int loop = 6; loop < 9; loop++)
                                        {
                                            for (int innerLoop = 0; innerLoop < 3; innerLoop++)
                                            {
                                                square[squareCounter++] = grid[loop, innerLoop];
                                                list.Add(grid[loop, innerLoop]);
                                            }
                                        }
                                    }
                                    else if (col < 6)
                                    {
                                        for (int loop = 6; loop < 9; loop++)
                                        {
                                            for (int innerLoop = 3; innerLoop < 6; innerLoop++)
                                            {
                                                square[squareCounter++] = grid[loop, innerLoop];
                                                list.Add(grid[loop, innerLoop]);
                                            }
                                        }
                                    }
                                    else
                                    {
                                        for (int loop = 6; loop < 9; loop++)
                                        {
                                            for (int innerLoop = 6; innerLoop < 9; innerLoop++)
                                            {
                                                square[squareCounter++] = grid[loop, innerLoop];
                                                list.Add(grid[loop, innerLoop]);
                                            }
                                        }
                                    }
                                }

                                int test = 69;
                                if (!list.Any(item => item == value))
                                {
                                    grid[row, col] = value;
                                    if (CheckIfFull(grid))
                                    {
                                        return;
                                    }
                                    else
                                    {
                                        FillSudoku(grid);
                                        return;
                                    }
                                }
                            }
                        }
                    }
                    break;
                }
            }
            



        }
        /// <summary>
        /// checks if grid is already filled with numbers
        /// </summary>
        /// <param name="grid"></param>
        /// <returns>returns true if grid is full, false otherwise</returns>
        /// <exception cref="ArgumentException">throws exception, if grid does't have the same dimention</exception>
        public static bool CheckIfFull(int[,] grid)
        {
            if (grid.GetLength(0) != grid.GetLength(1)) throw new ArgumentException("grid doesn't have the same dimention");
            for(int i = 0; i < grid.GetLength(0); i++)
            {
                for(int j = 0; j < grid.GetLength(1); j++)
                {
                    if (grid[i, j] == 0) return false;
                }
            }
            return true;
        }





    }
}