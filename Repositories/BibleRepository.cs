using Bible_Search.Data;
using Bible_Search.Models;
using Microsoft.EntityFrameworkCore;

namespace Bible_Search.Repositories;

public class BibleRepository : IBibleRepository
{
    private readonly BibleDbContext _context;

    public BibleRepository(BibleDbContext context)
    {
        _context = context;
    }
    public async Task<List<BibleVerse>> SearchVersesAsync(string searchTerm, bool oldTestament, bool newTestament)
    {
        var query = _context.BibleVerses.AsQueryable();

        if (!oldTestament)
            query = query.Where(v => v.BookId > 39);
        if (!newTestament)
            query = query.Where(v => v.BookId < 40);

        return await query
            .Include(v => v.Book)
            .Where(v => v.Text.Contains(searchTerm))
            .ToListAsync();
    }

    public async Task<List<BibleBook>> GetAllBooksAsync()
    {
        return await _context.BibleBooks
            .Select(b => new BibleBook { Id = b.Id, Name = b.Name }) // Include ID
            .ToListAsync();
    }


    public async Task<List<int>> GetChaptersAsync(int bookId)
    {
        return await _context.BibleVerses.Where(v => v.BookId == bookId)
            .Select(v => v.Chapter)
            .Distinct()
            .OrderBy(c => c)
            .ToListAsync();
    }

    public async Task<List<BibleVerse>> GetVersesAsync(int bookId, int chapter)
    {
        return await _context.BibleVerses.Where(v => v.BookId == bookId && v.Chapter == chapter)
            .ToListAsync(); 
    }

    public async Task<BibleVerse> GetVerseByIdAsync(int id)
    {
        return await _context.BibleVerses
            .Include(v => v.Book)
            .FirstOrDefaultAsync(v => v.Id == id);
    }
    
    public async Task<BibleVerse> SetVerseNoteAsync(int id, string note)
    {
        var verse = await _context.BibleVerses.FirstOrDefaultAsync(v => v.Id == id);
        verse.Note = note;
        await _context.SaveChangesAsync();
        return verse;
    }

}