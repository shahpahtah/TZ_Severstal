using System.Diagnostics;
using App.Interfaces;
using App.Models;
using Microsoft.AspNetCore.Mvc;
using Notes.Interfaces;
using Web.Models;

namespace Web.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly INoteAppService _noteAppService;
    private readonly INoteDomainService _noteDomainService;
    public HomeController(ILogger<HomeController> logger,INoteAppService noteAppService, INoteDomainService noteDomainService)
    {
        _logger = logger;
        _noteAppService = noteAppService;
        _noteDomainService = noteDomainService;
    }

    public async Task<IActionResult> Index()
    {
        var existingNotes = await _noteAppService.GetAllNotesAsync(); // Fetch from DB

        ViewBag.ExistingNotes = existingNotes;

        var noteList = new NoteListModel { Notes = new List<NoteDto> { new NoteDto() } };
        return View(noteList);
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
