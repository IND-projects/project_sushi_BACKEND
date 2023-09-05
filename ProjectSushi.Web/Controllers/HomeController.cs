using Microsoft.AspNetCore.Mvc;
using ProjectSushi.Web.Models;
using System.Diagnostics;
using ProjectSushi.Database.ProjectSushiDbContext;
using ProjectSushi.Database.Services;
using ProjectSushi.Database.Entities;

namespace ProjectSushi.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IUseDatabaseService _useDatabaseService;

        public HomeController(ILogger<HomeController> logger, IUseDatabaseService useDatabaseService)
        {
            _useDatabaseService = useDatabaseService;
        }

        [HttpGet]
        //[Route("GetRolls")]
        public async Task<IActionResult> GetRolls()
        {
            try
            {
                var rolls = await _useDatabaseService.GetAllRolls();
                if (!rolls.IsSuccess)
                    return BadRequest(rolls.ErrorMessage);
                return Ok(rolls.RollsList);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
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