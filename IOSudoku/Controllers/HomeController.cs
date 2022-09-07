using IOSudoku.Models;
using Microsoft.AspNetCore.Mvc;
using SudokuAnalizer;
using System.Diagnostics;

namespace IOSudoku.Controllers
{
    public class GameController : Controller
    {
        private readonly ILogger<GameController> _logger;
        List<string> difficulty = new() { "Easy", "Medium", "Hard", "Extreme" };

        public GameController(ILogger<GameController> logger)
        {
            _logger = logger;
        }

        public IActionResult Game()
        {
            var difficultyLevel = Request.Form["difficulty"][0];
            Random random = new Random();
            int toErase;
            switch (difficultyLevel)
            {
                case "Easy":
                    toErase = random.Next(10, 20);
                    break;
                case "Medium":
                    toErase = random.Next(30, 40);
                    break;
                case "Hard":
                    toErase = random.Next(45, 55);
                    break;
                case "Extreme":
                    toErase = random.Next(60, 75);
                    break;
                default:
                    toErase = random.Next(10, 20);
                    break;
            }


            var orginalGrid = Sudoku.GenerateSudokuGrid();
            var gameGrid = Sudoku.CreateGameGrid(orginalGrid, toErase);

            GameModel model = new GameModel();
            model.Difficulty = difficultyLevel;
            model.OriginalGrid = orginalGrid;
            model.GameGrid = gameGrid;
            return View(model);
        }

        public IActionResult DifficultySelect()
        {
            //todo: Entity model to game statistics
            
            

            return View(difficulty);
        }


        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}