using IOSudoku.Models;
using Microsoft.AspNetCore.Mvc;
using SudokuAnalizer;
using System.Diagnostics;

namespace IOSudoku.Controllers
{
    public class GameController : Controller
    {
        private readonly ILogger<GameController> _logger;
        List<string> difficulty = new() { "easy", "medium", "hard", "extreme" };

        public GameController(ILogger<GameController> logger)
        {
            _logger = logger;
        }

        public IActionResult Game()
        {
            var difficultyLevel = Request.Form["difficulty"][0];

            var orginalGrid = Sudoku.GenerateSudokuGrid();

            GameModel model = new GameModel();
            model.Difficulty = difficultyLevel;
            model.OriginalGrid = orginalGrid;
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