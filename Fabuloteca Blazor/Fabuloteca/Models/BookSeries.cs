public class BookSeries
{
    public int BookId { get; set; }
    public int SeriesId { get; set; }
    public float PositionInSeries { get; set; }

    public Book Book { get; set; }
    public Series Series { get; set; }
}
