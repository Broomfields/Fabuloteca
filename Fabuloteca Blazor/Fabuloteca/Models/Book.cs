using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Book
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    [Required]
    public string Title { get; set; }

    [Required]
    public DateTime PublicationDate { get; set; }

    [ForeignKey("Publisher")]
    public int PublisherId { get; set; }

    public string CoverImage { get; set; }

    [Required]
    public string ISBN { get; set; }

    public Publisher Publisher { get; set; }
    public ICollection<BookSeries> BookSeries { get; set; }
    public ICollection<BookAuthor> BookAuthors { get; set; }
    public ICollection<BookGenre> BookGenres { get; set; }
    public ICollection<BookSubGenre> BookSubGenres { get; set; }
    public ICollection<BookStoryElement> BookStoryElements { get; set; }
    public ICollection<BookToneAndMood> BookToneAndMoods { get; set; }
    public ICollection<BookTag> BookTags { get; set; }
    public ICollection<BookNarrator> BookNarrators { get; set; }
    public ICollection<BookAPIReference> BookAPIReferences { get; set; }
    public ICollection<ReadingTracking> ReadingTrackings { get; set; }
}
