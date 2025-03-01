using Bible_Search.Models;

namespace Bible_Search.Repositories;

public interface IBibleRepository
{
    Task<List<BibleVerse>> SearchVersesAsync(string searchTerm, bool oldTestament, bool newTestament);
    Task<List<BibleBook>> GetAllBooksAsync();
    Task<List<int>> GetChaptersAsync(int bookId);
    Task<List<BibleVerse>> GetVersesAsync(int bookId, int chapter);
    Task<BibleVerse> GetVerseByIdAsync(int id);
    Task<BibleVerse> SetVerseNoteAsync(int id, string note);
}
