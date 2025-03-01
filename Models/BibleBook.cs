namespace Bible_Search.Models;

public class BibleBook
{
    public int Id { get; set; }
    public string Name { get; set; }
    public ICollection<BibleVerse> Verses { get; set; }
}