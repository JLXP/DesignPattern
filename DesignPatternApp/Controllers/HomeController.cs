using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using DesignPatternApp.Models;
using DesignPattern.RepositoryPattern;
using DesignPatterns.Models.Models;

namespace DesignPatternApp.Controllers;

public class HomeController : Controller
{
    private readonly IRepository<Beer> _repository;

    public HomeController(IRepository<Beer> repository)
    {
        _repository = repository;
    }

    public IActionResult Index()
    {
        IEnumerable<Beer> lst = _repository.Get();
        return View("Index", lst);
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
