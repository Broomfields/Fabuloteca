using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class BookAPIReference
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    [ForeignKey("Book")]
    public int BookId { get; set; }

    [ForeignKey("APISource")]
    public int APISourceId { get; set; }

    [Required]
    public string ExternalId { get; set; }

    public Book Book { get; set; }
    public APISource APISource { get; set; }
}
