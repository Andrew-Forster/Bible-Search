using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bible_Search.Models;


public class BibleVerse
{
    [Key] 
    [Column("id")]
    public int Id { get; set; }

    [Column("book_id")]
    public int BookId { get; set; }

    [Column("chapter")]
    public int Chapter { get; set; }

    [Column("verse")]
    public int VerseNumber { get; set; }

    [Column("text")]
    public string Text { get; set; }
    
    public BibleBook Book { get; set; }
}