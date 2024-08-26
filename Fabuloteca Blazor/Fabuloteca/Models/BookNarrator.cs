public class BookNarrator
{
    public int BookId { get; set; }
    public int NarratorId { get; set; }

    public Book Book { get; set; }
    public Narrator Narrator { get; set; }
}
