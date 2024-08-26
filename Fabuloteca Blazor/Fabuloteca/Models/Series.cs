using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Series
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    [Required]
    public string Name { get; set; }

    public bool? IsTracked { get; set; }
    public bool? IsComplete { get; set; }

    public ICollection<BookSeries> BookSeries { get; set; }
}
