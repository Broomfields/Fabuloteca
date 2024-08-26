using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using static Microsoft.FluentUI.AspNetCore.Components.Icons.Filled.Size16;

public class ApplicationDbContext : DbContext
{
    private readonly IConfiguration _configuration;

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options, IConfiguration configuration)
        : base(options)
    {
        _configuration = configuration;
    }

    public DbSet<Book> Books { get; set; }
    public DbSet<Series> Series { get; set; }
    public DbSet<Author> Authors { get; set; }
    public DbSet<Publisher> Publishers { get; set; }
    public DbSet<Narrator> Narrators { get; set; }
    public DbSet<Genre> Genres { get; set; }
    public DbSet<SubGenre> SubGenres { get; set; }
    public DbSet<StoryElement> StoryElements { get; set; }
    public DbSet<ToneAndMood> ToneAndMoods { get; set; }
    public DbSet<Tag> Tags { get; set; }
    public DbSet<APISource> APISources { get; set; }
    public DbSet<BookAPIReference> BookAPIReferences { get; set; }
    public DbSet<ReadingTracking> ReadingTrackings { get; set; }
    public DbSet<BookSeries> BookSeries { get; set; }
    public DbSet<BookAuthor> BookAuthors { get; set; }
    public DbSet<BookGenre> BookGenres { get; set; }
    public DbSet<BookSubGenre> BookSubGenres { get; set; }
    public DbSet<BookStoryElement> BookStoryElements { get; set; }
    public DbSet<BookToneAndMood> BookToneAndMoods { get; set; }
    public DbSet<BookTag> BookTags { get; set; }
    public DbSet<BookNarrator> BookNarrators { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var connectionString = _configuration.GetConnectionString("DefaultConnection");
        optionsBuilder.UseSqlite(connectionString);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<BookSeries>()
            .HasKey(bs => new { bs.BookId, bs.SeriesId });

        modelBuilder.Entity<BookAuthor>()
            .HasKey(ba => new { ba.BookId, ba.AuthorId });

        modelBuilder.Entity<BookGenre>()
            .HasKey(bg => new { bg.BookId, bg.GenreId });

        modelBuilder.Entity<BookSubGenre>()
            .HasKey(bsg => new { bsg.BookId, bsg.SubGenreId });

        modelBuilder.Entity<BookStoryElement>()
            .HasKey(bse => new { bse.BookId, bse.StoryElementId });

        modelBuilder.Entity<BookToneAndMood>()
            .HasKey(btm => new { btm.BookId, btm.ToneAndMoodId });

        modelBuilder.Entity<BookNarrator>()
            .HasKey(bn => new { bn.BookId, bn.NarratorId });

        modelBuilder.Entity<Book>()
            .HasOne(b => b.Publisher)
            .WithMany(p => p.Books)
            .HasForeignKey(b => b.PublisherId);

        modelBuilder.Entity<BookAPIReference>()
            .HasOne(bar => bar.Book)
            .WithMany(b => b.BookAPIReferences)
            .HasForeignKey(bar => bar.BookId);

        modelBuilder.Entity<BookAPIReference>()
            .HasOne(bar => bar.APISource)
            .WithMany(api => api.BookAPIReferences)
            .HasForeignKey(bar => bar.APISourceId);

        modelBuilder.Entity<ReadingTracking>()
            .HasOne(rt => rt.Book)
            .WithMany(b => b.ReadingTrackings)
            .HasForeignKey(rt => rt.BookId);
    }
    public void SeedData()
    {
        SeedGenres();
        SeedSubGenres();
        SeedStoryElements();
        SeedToneAndMoods();
        SeedTags();
        SeedNarrators();
        SeedAuthors();
        SeedPublishers();
    }

    public void SeedGenres()
    {
        if (Genres.Any()) return;

        Genres.AddRange(new List<Genre>
        {
            new Genre { Name = "Science Fiction" },
            new Genre { Name = "Fantasy" },
            new Genre { Name = "Adventure" },
            new Genre { Name = "Romance" },
            new Genre { Name = "Mythology" },
            new Genre { Name = "Mystery" },
            new Genre { Name = "Western" },
            new Genre { Name = "Historical Fiction" },
            new Genre { Name = "Comedy" },
            new Genre { Name = "Satire" },
            new Genre { Name = "Biography" },
            new Genre { Name = "Dystopian" },
            new Genre { Name = "Noir" },
            new Genre { Name = "Biography" },
            new Genre { Name = "History" },
            new Genre { Name = "Educational" },
            new Genre { Name = "Military" },
        });
        SaveChanges();
    }

    public void SeedSubGenres()
    {
        if (SubGenres.Any()) return;

        SubGenres.AddRange(new List<SubGenre>
        {
            new SubGenre { Name = "Cyberpunk" },
            new SubGenre { Name = "Urban" },
            new SubGenre { Name = "Solarpunk" },
            new SubGenre { Name = "Modern" },
            new SubGenre { Name = "Space Opera" },
            new SubGenre { Name = "High Fantasy" },
            new SubGenre { Name = "Steampunk" },
            new SubGenre { Name = "Cultivation" },
            new SubGenre { Name = "Isekai" },
            new SubGenre { Name = "Progression" },
            new SubGenre { Name = "LitRPG" },
            new SubGenre { Name = "Military" },
            new SubGenre { Name = "Slice of Life" },
            new SubGenre { Name = "Adventure" },
            new SubGenre { Name = "Western" },
            new SubGenre { Name = "Detective" },
            new SubGenre { Name = "Survival" },
            new SubGenre { Name = "Action" },
            new SubGenre { Name = "Classic" },
            new SubGenre { Name = "Educational" },
        });
        SaveChanges();
    }

    public void SeedStoryElements()
    {
        if (StoryElements.Any()) return;

        StoryElements.AddRange(new List<StoryElement>
        {
            new StoryElement { Name = "Fantasy" },
            new StoryElement { Name = "Science Fiction" },
            new StoryElement { Name = "Romance" },
            new StoryElement { Name = "Hero's Journey" },
            new StoryElement { Name = "Slice of Life" },
            new StoryElement { Name = "Quest" },
            new StoryElement { Name = "Mystery" },
            new StoryElement { Name = "Adult" },
            new StoryElement { Name = "Sexual" },
            new StoryElement { Name = "Violent" },
            new StoryElement { Name = "Problem Solving" },
            new StoryElement { Name = "Collection" },
        });
        SaveChanges();
    }

    public void SeedToneAndMoods()
    {
        if (ToneAndMoods.Any()) return;

        ToneAndMoods.AddRange(new List<ToneAndMood>
        {
            new ToneAndMood { Name = "Dark" },
            new ToneAndMood { Name = "Light" },
            new ToneAndMood { Name = "Wholesome" },
            new ToneAndMood { Name = "Lighthearted" },
            new ToneAndMood { Name = "Romantic" },
            new ToneAndMood { Name = "Suspenseful" },
            new ToneAndMood { Name = "Tragic" },
            new ToneAndMood { Name = "Inspiring" },
            new ToneAndMood { Name = "Hard" },
        });
        SaveChanges();
    }

    public void SeedTags()
    {
        if (Tags.Any()) return;

        Tags.AddRange(new List<Tag>
        {
            new Tag { Name = "Star Wars" },
            new Tag { Name = "Thrawn" },
            new Tag { Name = "Star Wars: Legends" },
            new Tag { Name = "Star Wars: Canon" },
            new Tag { Name = "Halo" },
            new Tag { Name = "Lord of the Rings" },
            new Tag { Name = "Warhammer 40K" },
            new Tag { Name = "Warhammer" },
            new Tag { Name = "The Lost Fleet" },
            new Tag { Name = "Pillars of Reality" },
            new Tag { Name = "Ancient Greek" },
        });
        SaveChanges();
    }

    public void SeedNarrators()
    {
        if (Narrators.Any()) return;

        Narrators.AddRange(new List<Narrator>
        {
            new Narrator { Name = "Marc Thompson" },
            new Narrator { Name = "Andrea Parsneau" },
            new Narrator { Name = "Travis Baldree" },
            new Narrator { Name = "Heath Miller" },
            new Narrator { Name = "Scott Brick" },
            new Narrator { Name = "Jonathan Davis" },
            new Narrator { Name = "Ray Porter" },
            new Narrator { Name = "Euan Morton" },
            new Narrator { Name = "Caitilin Davies" },
            new Narrator { Name = "Paul Heitsch" },
            new Narrator { Name = "Simon Vance" },
            new Narrator { Name = "Stephen Bel Davies" },
            new Narrator { Name = "Peter Kenny" },
            new Narrator { Name = "Rosario Dawson" },
            new Narrator { Name = "Stephen Fry" },
            new Narrator { Name = "Ashley Eckstein" },
            new Narrator { Name = "Todd McLaren" },
            new Narrator { Name = "Daniel Davis" },
            new Narrator { Name = "Christian Rummel" },
            new Narrator { Name = "January LaVoy" },
            new Narrator { Name = "Mel Hudson" },
            new Narrator { Name = "Rob Inglis" },
            new Narrator { Name = "Steve Campbell" },
            new Narrator { Name = "Jessica Threet" },
            new Narrator { Name = "Jack Douglas" },
            new Narrator { Name = "Evan Jordan" },
            new Narrator { Name = "Chris Boucher" },
            new Narrator { Name = "Rozelyn Rader" },
            new Narrator { Name = "Lewis Alexander" },
            new Narrator { Name = "Christian J. Gilliland" },
            new Narrator { Name = "Hazel Cohen" },
            new Narrator { Name = "Daniel Thomas May" },
            new Narrator { Name = "Rebecca Soler" },
            new Narrator { Name = "Teddy Hamilton" },
            new Narrator { Name = "Adam Stubbs" },
            new Narrator { Name = "Mia Fothergill" },
            new Narrator { Name = "Raya Kane" },
            new Narrator { Name = "Richard Brock" },
            new Narrator { Name = "Jonathan Waters" },
            new Narrator { Name = "Katana Jones" },
            new Narrator { Name = "Daryl Mayfield" },
            new Narrator { Name = "Jess Trepanier" },
            new Narrator { Name = "Jack Voraces" },
            new Narrator { Name = "Neil Hellegers" },
            new Narrator { Name = "Rebecca Woods" },
            new Narrator { Name = "Daniel Wisniewski" },
            new Narrator { Name = "Stina Nielsen" },
            new Narrator { Name = "Jennifer Ikeda" },
            new Narrator { Name = "Amanda Leigh Cobb" },
            new Narrator { Name = "Elizabeth Evans" },
            new Narrator { Name = "William Hope" },
            new Narrator { Name = "Luke Daniels" },
            new Narrator { Name = "Jeff Gurner" },
            new Narrator { Name = "Gunnar Cauthery" },
            new Narrator { Name = "Marc Vietor" },
            new Narrator { Name = "Macleod Andrews" },
            new Narrator { Name = "Andy Serkis" },
            new Narrator { Name = "Aidan Gillen" },
            new Narrator { Name = "Mark Boyett" },
            new Narrator { Name = "Edoardo Ballerini" },
            new Narrator { Name = "Toby Longworth" },
            new Narrator { Name = "Bruno Roubicek" },
            new Narrator { Name = "Dan Bittner" },
            new Narrator { Name = "Catherine Taber" },
            new Narrator { Name = "Helen Keeley" },
            new Narrator { Name = "Michael Kramer" },
            new Narrator { Name = "Victor Bevine" },
            new Narrator { Name = "Martin Shaw" },
            new Narrator { Name = "R. C. Bray" },
            new Narrator { Name = "Kate Reading" },
        });
        SaveChanges();
    }

    public void SeedAuthors()
    {
        if (Authors.Any()) return;

        Authors.AddRange(new List<Author>
        {
            new Author { Name = "Author One", IsTracked = true },
            new Author { Name = "Author Two", IsTracked = false },
            new Author { Name = "Author Three", IsTracked = true }
        });
        SaveChanges();
    }

    public void SeedPublishers()
    {
        if (Publishers.Any()) return;

        Publishers.AddRange(new List<Publisher>
        {
            new Publisher { Name = "Publisher One", IsTracked = true },
            new Publisher { Name = "Publisher Two", IsTracked = false },
            new Publisher { Name = "Publisher Three", IsTracked = true }
        });
        SaveChanges();
    }
}
