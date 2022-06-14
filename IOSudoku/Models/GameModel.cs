namespace IOSudoku.Models
{
    public class GameModel
    {
        public string? Difficulty { get; set; }
        public int[,]? OriginalGrid { get; set; }
        public int[,]? GameGrid { get; set; }
    }
}
