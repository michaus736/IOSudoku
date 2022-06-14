using Medallion;

namespace SudokuAnalizer
{
    public class Sudoku
    {

        static int counter = 0;

        public static int[,] GenerateSudokuGrid()
        {
            int[,] grid;
            do
            {
                grid = new int[9, 9];
                Sudoku.FillSudoku(grid);
            } while (!Sudoku.IsValid(grid));

            return grid;
        }




        public static void FillSudoku(int[,] grid)
        {
            if (grid.GetLength(0) != grid.GetLength(1)) throw new ArgumentException("grid doesn't have the same dimention size");

            int N = grid.GetLength(0) * grid.GetLength(1);
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
        /// <param name="grid">square grid to check</param>
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

        public static bool IsValid(int[,] grid)
        {
            if (grid == null) return false; //array is null or row is null
            if (grid.GetLength(0) != grid.GetLength(1)) return false; //NxN size
            foreach (var item in grid)
            {
                if (item <= 1 && item > grid.GetLength(0)) return false;
            }
            if (Math.Sqrt((double)grid.Length) != Math.Floor(Math.Sqrt((double)grid.Length))) return false; //square root of size is integer

            //creating sequence
            string seq = "123456789";

            //checking rows
            List<int[]> Rows = new List<int[]>();
            for(int i = 0; i < grid.GetLength(0); i++)
            {
                Rows.Add(grid.SliceRow(i).ToArray());
            }
            var sortedStrRows = Rows.Select(x => string.Join("", x.OrderBy(x => x).ToList()));
            if (!(sortedStrRows.All(x => x == seq))) return false;

            //checking columns

            var sortedSrCols = Enumerable.Range(0, grid.GetLength(0)).Select(x =>
            {
                List<int> list = new List<int>();
                for (int i = 0; i < grid.GetLength(0); i++)
                {
                    list.Add(grid[i, x]);
                }

                return string.Join("", list.OrderBy(x => x));
            });

            if (!(sortedSrCols.All(x => x == seq))) return false;

            //checking squares
            List<List<int>> list = new List<List<int>>();
            int N = grid.GetLength(0), square = (int)Math.Sqrt(grid.GetLength(0));

            for (int i = 0; i < N; i += square)
            {
                for (int j = 0; j < N; j += square)
                {
                    List<int> sq = new List<int>();
                    for (int k = i; k < i + square; k++)
                    {
                        for (int l = j; l < j + square; l++)
                        {
                            sq.Add(grid[k,l]);
                        }
                    }
                    list.Add(sq);
                }
            }
            var sortedSrSquares = list.Select(x => string.Join<int>("", x.OrderBy(x => x).ToList()));
            if (!(sortedSrSquares.All(x => x == seq))) return false;

            return true;
        }



    }
}