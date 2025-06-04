using System.Diagnostics;
using System.Threading.Tasks;
using AspNetCoreGeneratedDocument;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ProjetoInterdisciplinar.Data;
using ProjetoInterdisciplinar.Models;

namespace ProjetoInterdisciplinar.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly UserManager<AppUsers> _userManager;
    private readonly AppDbContext _context;


    public HomeController(ILogger<HomeController> logger, UserManager<AppUsers> userManager, AppDbContext context)
    {
        _logger = logger;
        _userManager = userManager;
        _context = context;
    }

    public IActionResult Index()
    {
        return View();
    }


    [Authorize(Roles = "Admin")]
    public IActionResult IndexAdmin()
    {
        return View();
    }

    [Authorize]
    public IActionResult Privacy()
    {
        return View();
    }


    public IActionResult Suporte()
    {
        return View();
    }


    public IActionResult SobreNos()
    {
        return View();
    }


    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
