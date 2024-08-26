public class BookStoryElement
{
    public int BookId { get; set; }
    public int StoryElementId { get; set; }

    public Book Book { get; set; }
    public StoryElement StoryElement { get; set; }
}
