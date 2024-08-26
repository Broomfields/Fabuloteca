public class BookSubGenre
{
    public int BookId { get; set; }
    public int SubGenreId { get; set; }

    public Book Book { get; set; }
    public SubGenre SubGenre { get; set; }
}
