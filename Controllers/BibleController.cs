using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Bible_Search.Models;
using Bible_Search.Repositories;

namespace Bible_Search.Controllers;

public class BibleController : Controller
{
    private readonly ILogger<BibleController> _logger;
    private readonly IBibleRepository _bibleRepository;

    public BibleController(ILogger<BibleController> logger, IBibleRepository bibleRepository)
    {
        _logger = logger;
        _bibleRepository = bibleRepository;
    }

    public IActionResult Index()
    {
        return View("Search");
    }
    public async Task<IActionResult> Reference()
    {
        var books = await _bibleRepository.GetAllBooksAsync();
        return View("Reference", books);
    }

    [HttpGet]
    public async Task<IActionResult> Search(string searchTerm, bool oldTestament, bool newTestament)
    {
        var verses = await _bibleRepository.SearchVersesAsync(searchTerm, oldTestament, newTestament);
        ViewData["SearchTerm"] = searchTerm;
        return PartialView("_Results", verses);
    }

    public async Task<IActionResult> VerseDetails(int id)
    {
        var verse = await _bibleRepository.GetVerseByIdAsync(id);
        return View("VerseDetails", verse);
    }

    [HttpPost]
    public async Task<IActionResult> SetVerseNote(int id, string note)
    {
        var verse = await _bibleRepository.SetVerseNoteAsync(id, note);
        if (verse == null)
        {
            return NotFound();
        }
        return Content(verse.Note);
    }
    
    public async Task<IActionResult> GetChapters(int bookId)
    {
        var chapters = await _bibleRepository.GetChaptersAsync(bookId);
        return Json(chapters);
    }
    
    public async Task<IActionResult> GetVerses(int bookId, int chapter)
    {
        var verses = await _bibleRepository.GetVersesAsync(bookId, chapter);
        return Json(verses);
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}