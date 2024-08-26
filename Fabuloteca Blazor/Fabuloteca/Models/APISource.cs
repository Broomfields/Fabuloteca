using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class APISource
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    [Required]
    public string Name { get; set; }

    [Required]
    public string BaseUrl { get; set; }

    public string ApiKey { get; set; }

    public ICollection<BookAPIReference> BookAPIReferences { get; set; }
}
