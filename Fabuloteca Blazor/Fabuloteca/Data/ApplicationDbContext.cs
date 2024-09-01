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
            new Genre { Name = "Horror" },
            new Genre { Name = "Thriller" },
            new Genre { Name = "Crime" },
            new Genre { Name = "Drama" },
            new Genre { Name = "Tragedy" },
            new Genre { Name = "Paranormal" },
            new Genre { Name = "Psychological" },
            new Genre { Name = "Gothic" },
            new Genre { Name = "Epic" },
            new Genre { Name = "Urban Fantasy" },
            new Genre { Name = "High Fantasy" },
            new Genre { Name = "Dark Fantasy" },
            new Genre { Name = "Cyberpunk" },
            new Genre { Name = "Steampunk" },
            new Genre { Name = "Alternate History" },
            new Genre { Name = "Spy Fiction" },
            new Genre { Name = "Legal Fiction" },
            new Genre { Name = "Philosophical Fiction" },
            new Genre { Name = "Magical Realism" },
            new Genre { Name = "Young Adult" },
            new Genre { Name = "New Adult" },
            new Genre { Name = "Erotica" },
            new Genre { Name = "Poetry" },
            new Genre { Name = "Anthology" },
            new Genre { Name = "Graphic Novel" },
            new Genre { Name = "Short Stories" },
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
            new SubGenre { Name = "Dark Fantasy" },
            new SubGenre { Name = "Grimdark" },
            new SubGenre { Name = "Dieselpunk" },
            new SubGenre { Name = "Biopunk" },
            new SubGenre { Name = "Fantasy Romance" },
            new SubGenre { Name = "Historical Fiction" },
            new SubGenre { Name = "Psychological Thriller" },
            new SubGenre { Name = "Noir" },
            new SubGenre { Name = "Gothic" },
            new SubGenre { Name = "Alternate History" },
            new SubGenre { Name = "Spy Fiction" },
            new SubGenre { Name = "Hard Science Fiction" },
            new SubGenre { Name = "Romantic Comedy" },
            new SubGenre { Name = "Epic Fantasy" },
            new SubGenre { Name = "Paranormal" },
            new SubGenre { Name = "Horror" },
            new SubGenre { Name = "Legal Thriller" },
            new SubGenre { Name = "Political Thriller" },
            new SubGenre { Name = "Philosophical Fiction" },
            new SubGenre { Name = "Magical Realism" },
            new SubGenre { Name = "Mythopoeia" },
        });
        SaveChanges();
    }

    public void SeedStoryElements()
    {
        if (StoryElements.Any()) return;

        StoryElements.AddRange(new List<StoryElement>
    {
        new StoryElement { Name = "Fantasy" },
        new StoryElement { Name = "High Fantasy" },
        new StoryElement { Name = "Urban Fantasy" },
        new StoryElement { Name = "Dark Fantasy" },
        new StoryElement { Name = "Science Fiction" },
        new StoryElement { Name = "Hard Science Fiction" },
        new StoryElement { Name = "Dystopian" },
        new StoryElement { Name = "Cyberpunk" },
        new StoryElement { Name = "Space Opera" },
        new StoryElement { Name = "Romance" },
        new StoryElement { Name = "Historical Romance" },
        new StoryElement { Name = "Contemporary Romance" },
        new StoryElement { Name = "Hero's Journey" },
        new StoryElement { Name = "Anti-Hero" },
        new StoryElement { Name = "Coming of Age" },
        new StoryElement { Name = "Slice of Life" },
        new StoryElement { Name = "Drama" },
        new StoryElement { Name = "Tragedy" },
        new StoryElement { Name = "Quest" },
        new StoryElement { Name = "Epic" },
        new StoryElement { Name = "Adventure" },
        new StoryElement { Name = "Mystery" },
        new StoryElement { Name = "Crime" },
        new StoryElement { Name = "Thriller" },
        new StoryElement { Name = "Suspense" },
        new StoryElement { Name = "Adult" },
        new StoryElement { Name = "New Adult" },
        new StoryElement { Name = "Young Adult" },
        new StoryElement { Name = "Sexual" },
        new StoryElement { Name = "Erotica" },
        new StoryElement { Name = "Romantic Erotica" },
        new StoryElement { Name = "Violent" },
        new StoryElement { Name = "Horror" },
        new StoryElement { Name = "Gothic" },
        new StoryElement { Name = "Dark Thriller" },
        new StoryElement { Name = "Problem Solving" },
        new StoryElement { Name = "Detective Fiction" },
        new StoryElement { Name = "Puzzle" },
        new StoryElement { Name = "Legal Drama" },
        new StoryElement { Name = "Collection" },
        new StoryElement { Name = "Anthology" },
        new StoryElement { Name = "Short Stories" },
        new StoryElement { Name = "Poetry" },
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
            new ToneAndMood { Name = "Cozy" },
            new ToneAndMood { Name = "Lighthearted" },
            new ToneAndMood { Name = "Romantic" },
            new ToneAndMood { Name = "Suspenseful" },
            new ToneAndMood { Name = "Tragic" },
            new ToneAndMood { Name = "Inspiring" },
            new ToneAndMood { Name = "Hard" },
            new ToneAndMood { Name = "Melancholic" },
            new ToneAndMood { Name = "Humorous" },
            new ToneAndMood { Name = "Optimistic" },
            new ToneAndMood { Name = "Pessimistic" },
            new ToneAndMood { Name = "Mysterious" },
            new ToneAndMood { Name = "Chilling" },
            new ToneAndMood { Name = "Uplifting" },
            new ToneAndMood { Name = "Grim" },
            new ToneAndMood { Name = "Bleak" },
            new ToneAndMood { Name = "Somber" },
            new ToneAndMood { Name = "Joyful" },
            new ToneAndMood { Name = "Epic" },
            new ToneAndMood { Name = "Reflective" },
            new ToneAndMood { Name = "Nostalgic" },
            new ToneAndMood { Name = "Bittersweet" },
            new ToneAndMood { Name = "Tense" },
            new ToneAndMood { Name = "Playful" },
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
            new Tag { Name = "Harry Potter" },
            new Tag { Name = "Game of Thrones" },
            new Tag { Name = "Marvel" },
            new Tag { Name = "DC Comics" },
            new Tag { Name = "Dune" },
            new Tag { Name = "Sherlock Holmes" },
            new Tag { Name = "Agatha Christie" },
            new Tag { Name = "Stephen King" },
            new Tag { Name = "H.P. Lovecraft" },
            new Tag { Name = "Cyberpunk" },
            new Tag { Name = "Steampunk" },
            new Tag { Name = "Space Opera" },
            new Tag { Name = "Post-Apocalyptic" },
            new Tag { Name = "Zombies" },
            new Tag { Name = "Vampires" },
            new Tag { Name = "Mythology" },
            new Tag { Name = "Arthurian Legend" },
            new Tag { Name = "Norse Mythology" },
            new Tag { Name = "Greek Mythology" },
            new Tag { Name = "Celtic Mythology" },
            new Tag { Name = "Epic Fantasy" },
            new Tag { Name = "Magic" },
            new Tag { Name = "Dragons" },
            new Tag { Name = "Aliens" },
            new Tag { Name = "Time Travel" },
            new Tag { Name = "Parallel Universe" },
            new Tag { Name = "Artificial Intelligence" },
            new Tag { Name = "Robots" },
            new Tag { Name = "Dystopia" },
            new Tag { Name = "Military Sci-Fi" },
            new Tag { Name = "Space Exploration" },
            new Tag { Name = "First Contact" },
            new Tag { Name = "Alternate History" },
            new Tag { Name = "Fantasy Romance" },
            new Tag { Name = "Urban Fantasy" },
            new Tag { Name = "Dark Fantasy" },
            new Tag { Name = "Grimdark" },
            new Tag { Name = "Cozy Mystery" },
            new Tag { Name = "Detective" },
            new Tag { Name = "Espionage" },
            new Tag { Name = "Legal Thriller" },
            new Tag { Name = "Political Thriller" },
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
            new Author { Name = "A.D. Krabis", IsTracked = false },
            new Author { Name = "Aaron Allston", IsTracked = false },
            new Author { Name = "Adam Christopher", IsTracked = false },
            new Author { Name = "Adrian Tchaikovsky", IsTracked = false },
            new Author { Name = "Alexander Freed", IsTracked = false },
            new Author { Name = "Amie Kaufman", IsTracked = false },
            new Author { Name = "Andrzej Sapkowski", IsTracked = true },
            new Author { Name = "Andy Weir", IsTracked = true },
            new Author { Name = "Annabelle Hawthorne", IsTracked = false },
            new Author { Name = "Arthur C. Clarke", IsTracked = false },
            new Author { Name = "Ashley Eckstein", IsTracked = false },
            new Author { Name = "B.K. Evenson", IsTracked = false },
            new Author { Name = "Bastian Knight", IsTracked = false },
            new Author { Name = "Ben Acker", IsTracked = false },
            new Author { Name = "Ben Blacker", IsTracked = false },
            new Author { Name = "Beth Revis", IsTracked = false },
            new Author { Name = "Brian Herbert", IsTracked = false },
            new Author { Name = "Brian Reber", IsTracked = false },
            new Author { Name = "Brian Reed", IsTracked = false },
            new Author { Name = "Brian W. Kernighan", IsTracked = false },
            new Author { Name = "Bruce Sentar", IsTracked = true },
            new Author { Name = "Bruno Redondo", IsTracked = false },
            new Author { Name = "Cale Plamann", IsTracked = true },
            new Author { Name = "Carissa Broadbent", IsTracked = false },
            new Author { Name = "Carol Monda", IsTracked = false },
            new Author { Name = "Cassandra Rose Clarke", IsTracked = false },
            new Author { Name = "CasualFarmer", IsTracked = true },
            new Author { Name = "Cavan Scott", IsTracked = false },
            new Author { Name = "Charles Soule", IsTracked = false },
            new Author { Name = "Chris Broad", IsTracked = false },
            new Author { Name = "Christie Golden", IsTracked = false },
            new Author { Name = "Christy Romano", IsTracked = false },
            new Author { Name = "Chuck Wendig", IsTracked = false },
            new Author { Name = "Claudia Gray", IsTracked = false },
            new Author { Name = "Cory Walker", IsTracked = false },
            new Author { Name = "Craig Alanson", IsTracked = false },
            new Author { Name = "Cressida Cowell", IsTracked = false },
            new Author { Name = "Daniel José Older", IsTracked = false },
            new Author { Name = "Daniel M. Lavery", IsTracked = false },
            new Author { Name = "Daniel Schinhofen", IsTracked = false },
            new Author { Name = "Danusia Stok", IsTracked = false },
            new Author { Name = "Dave Filoni", IsTracked = false },
            new Author { Name = "David Burke", IsTracked = false },
            new Author { Name = "David French", IsTracked = false },
            new Author { Name = "David Griffiths", IsTracked = false },
            new Author { Name = "David Mitchell", IsTracked = false },
            new Author { Name = "Dawn Griffiths", IsTracked = false },
            new Author { Name = "Deacon Frost", IsTracked = false },
            new Author { Name = "Delilah S. Dawson", IsTracked = false },
            new Author { Name = "Dennis E. Taylor", IsTracked = true },
            new Author { Name = "Dennis M. Ritchie", IsTracked = false },
            new Author { Name = "Domagoj Kurmaić", IsTracked = true },
            new Author { Name = "Douglas A. Anderson", IsTracked = false },
            new Author { Name = "Douglas Adams", IsTracked = false },
            new Author { Name = "E.K. Johnston", IsTracked = false },
            new Author { Name = "Edie Skye", IsTracked = false },
            new Author { Name = "Elizabeth Schaefer", IsTracked = false },
            new Author { Name = "Elizabeth Wein", IsTracked = false },
            new Author { Name = "Eric Raab", IsTracked = false },
            new Author { Name = "Eric S. Nylund", IsTracked = true },
            new Author { Name = "Fabien Sanglard", IsTracked = false },
            new Author { Name = "Frank Herbert", IsTracked = false },
            new Author { Name = "Frank O'Connor", IsTracked = false },
            new Author { Name = "Fred Van Lente", IsTracked = false },
            new Author { Name = "Gabriel Garza", IsTracked = false },
            new Author { Name = "Gary D. Schmidt", IsTracked = false },
            new Author { Name = "Gary Whitta", IsTracked = false },
            new Author { Name = "Gentry Lee", IsTracked = false },
            new Author { Name = "Glen Weldon", IsTracked = false },
            new Author { Name = "Gordon Doherty", IsTracked = false },
            new Author { Name = "Greg Rucka", IsTracked = false },
            new Author { Name = "Griffin McElroy", IsTracked = false },
            new Author { Name = "Gwen Grayson", IsTracked = false },
            new Author { Name = "Harmon Cooper", IsTracked = false },
            new Author { Name = "Harper Collins", IsTracked = false },
            new Author { Name = "Holly Black", IsTracked = false },
            new Author { Name = "Ian Doescher", IsTracked = false },
            new Author { Name = "Iban Coello", IsTracked = false },
            new Author { Name = "J.R.R. Tolkien", IsTracked = false },
            new Author { Name = "Jack Campbell", IsTracked = false },
            new Author { Name = "James Luceno", IsTracked = false },
            new Author { Name = "James S.A. Corey", IsTracked = false },
            new Author { Name = "James Swallow", IsTracked = false },
            new Author { Name = "Janina Gavankar", IsTracked = false },
            new Author { Name = "Jason Fry", IsTracked = false },
            new Author { Name = "Jay Kristoff", IsTracked = false },
            new Author { Name = "Jeff VanderMeer", IsTracked = false },
            new Author { Name = "Jeffrey Brown", IsTracked = false },
            new Author { Name = "Jemima Catlin", IsTracked = false },
            new Author { Name = "Jennifer L. Armentrout", IsTracked = false },
            new Author { Name = "Jody Houser", IsTracked = false },
            new Author { Name = "Joe Sabino", IsTracked = false },
            new Author { Name = "Joe Schreiber", IsTracked = false },
            new Author { Name = "John Buscema", IsTracked = false },
            new Author { Name = "John Jackson Miller", IsTracked = false },
            new Author { Name = "John le Carré", IsTracked = false },
            new Author { Name = "John Romero", IsTracked = false },
            new Author { Name = "John Scalzi", IsTracked = false },
            new Author { Name = "Jon Hamm", IsTracked = false },
            new Author { Name = "Jonathan Goff", IsTracked = false },
            new Author { Name = "Jonathan Hickman", IsTracked = false },
            new Author { Name = "Joseph Staten", IsTracked = false },
            new Author { Name = "Joshua Dalzelle", IsTracked = true },
            new Author { Name = "Justin Miller", IsTracked = true },
            new Author { Name = "KamikazePotato", IsTracked = false },
            new Author { Name = "Kamome Shirahama", IsTracked = false },
            new Author { Name = "Karen Traviss", IsTracked = true },
            new Author { Name = "Kelly Gay", IsTracked = false },
            new Author { Name = "Kelly Sue DeConnick", IsTracked = false },
            new Author { Name = "Ken Liu", IsTracked = false },
            new Author { Name = "Kevin Grace", IsTracked = false },
            new Author { Name = "Kieron Gillen", IsTracked = false },
            new Author { Name = "Kirk Mason", IsTracked = false },
            new Author { Name = "Lars Machmüller", IsTracked = false },
            new Author { Name = "Luke Daniels", IsTracked = false },
            new Author { Name = "Luke Ross", IsTracked = false },
            new Author { Name = "MacLeod Andrews", IsTracked = false },
            new Author { Name = "Madeleine Roux", IsTracked = false },
            new Author { Name = "Madeline Miller", IsTracked = false },
            new Author { Name = "Madelyn Black", IsTracked = false },
            new Author { Name = "Marcus Sloss", IsTracked = false },
            new Author { Name = "Martha Wells", IsTracked = false },
            new Author { Name = "Matt Dinniman", IsTracked = false },
            new Author { Name = "Matt Forbeck", IsTracked = false },
            new Author { Name = "Matt Fraction", IsTracked = false },
            new Author { Name = "Matthew Woodring Stover", IsTracked = false },
            new Author { Name = "Meg Cabot", IsTracked = false },
            new Author { Name = "Mel Hudson", IsTracked = false },
            new Author { Name = "Michael A. Stackpole", IsTracked = true },
            new Author { Name = "Michael Hague", IsTracked = false },
            new Author { Name = "Mike Chen", IsTracked = false },
            new Author { Name = "Mike S. Miller", IsTracked = false },
            new Author { Name = "Mitch Gerads", IsTracked = false },
            new Author { Name = "Morgan Lockhart", IsTracked = false },
            new Author { Name = "Mur Lafferty", IsTracked = false },
            new Author { Name = "Neil Hellegers", IsTracked = false },
            new Author { Name = "Neil Patrick Harris", IsTracked = false },
            new Author { Name = "Nicolas Bouvier", IsTracked = false },
            new Author { Name = "Nnedi Okorafor", IsTracked = false },
            new Author { Name = "Pablo Hidalgo", IsTracked = false },
            new Author { Name = "Paul Dini", IsTracked = false },
            new Author { Name = "Paul Renaud", IsTracked = false },
            new Author { Name = "Paul S. Kemp", IsTracked = false },
            new Author { Name = "Peter David", IsTracked = false },
            new Author { Name = "Philip K. Dick", IsTracked = false },
            new Author { Name = "Pierce Brown", IsTracked = false },
            new Author { Name = "Pirateaba", IsTracked = true },
            new Author { Name = "R.C. Bray", IsTracked = false },
            new Author { Name = "Rachel Ní Chuirc", IsTracked = true },
            new Author { Name = "Rae Carson", IsTracked = false },
            new Author { Name = "Rafael Kalleen", IsTracked = false },
            new Author { Name = "Randi Darren", IsTracked = false },
            new Author { Name = "Rebecca Yarros", IsTracked = true },
            new Author { Name = "Renée Ahdieh", IsTracked = false },
            new Author { Name = "Rhaegar", IsTracked = true },
            new Author { Name = "Robert Kirkman", IsTracked = false },
            new Author { Name = "Robert McLees", IsTracked = false },
            new Author { Name = "Robert Venditti", IsTracked = false },
            new Author { Name = "Robt McLees", IsTracked = false },
            new Author { Name = "Ryan Ottley", IsTracked = false },
            new Author { Name = "S.G. Prince", IsTracked = false },
            new Author { Name = "Sabaa Tahir", IsTracked = false },
            new Author { Name = "Sarah J. Maas", IsTracked = true },
            new Author { Name = "Saskia Maarleveld", IsTracked = false },
            new Author { Name = "Scott Meyer", IsTracked = false },
            new Author { Name = "Shane Hammond", IsTracked = false },
            new Author { Name = "Shirtaloon", IsTracked = true },
            new Author { Name = "Stephen Fry", IsTracked = false },
            new Author { Name = "Stephenie Meyer", IsTracked = false },
            new Author { Name = "Sylke Hachmeister", IsTracked = false },
            new Author { Name = "Tao Wong", IsTracked = false },
            new Author { Name = "Tessa Kum", IsTracked = false },
            new Author { Name = "Timothy Zahn", IsTracked = true },
            new Author { Name = "Tobias S. Buckell", IsTracked = false },
            new Author { Name = "Tom Angleberger", IsTracked = false },
            new Author { Name = "Tom King", IsTracked = false },
            new Author { Name = "Tom Taylor", IsTracked = false },
            new Author { Name = "Travis Baldree", IsTracked = true },
            new Author { Name = "Travis Deverell", IsTracked = false },
            new Author { Name = "Troy Denning", IsTracked = false },
            new Author { Name = "Turner Tellborn", IsTracked = false },
            new Author { Name = "TurtleMe", IsTracked = true },
            new Author { Name = "Virgil Knightley", IsTracked = false },
            new Author { Name = "Wil Wheaton", IsTracked = false },
            new Author { Name = "Will Wight", IsTracked = true },
            new Author { Name = "William C. Dietz", IsTracked = false },
            new Author { Name = "Zachary Bacus", IsTracked = false },
            new Author { Name = "Zoraida Córdova", IsTracked = false },
        });
        SaveChanges();
    }

    public void SeedPublishers()
    {
        if (Publishers.Any()) return;

        Publishers.AddRange(new List<Publisher>
        {
            new Publisher { Name = "47North", IsTracked = false },
            new Publisher { Name = "Ace", IsTracked = false },
            new Publisher { Name = "Ace Books", IsTracked = false },
            new Publisher { Name = "Ace Hardcover/Berkley", IsTracked = false },
            new Publisher { Name = "Aethon Books", IsTracked = false },
            new Publisher { Name = "Amazon Digital Services", IsTracked = false },
            new Publisher { Name = "Andy Weir / Galactanet", IsTracked = true },
            new Publisher { Name = "Arrow", IsTracked = false },
            new Publisher { Name = "Audible Originals", IsTracked = false },
            new Publisher { Name = "Audible Studios", IsTracked = false },
            new Publisher { Name = "Audible Studios ", IsTracked = false },
            new Publisher { Name = "Audible Studios on Brilliance Audio", IsTracked = false },
            new Publisher { Name = "Ballantine Books", IsTracked = false },
            new Publisher { Name = "Bantam Press", IsTracked = false },
            new Publisher { Name = "Bloomsbury", IsTracked = false },
            new Publisher { Name = "Bloomsbury Books", IsTracked = false },
            new Publisher { Name = "Bloomsbury Childrens", IsTracked = false },
            new Publisher { Name = "Bloomsbury Children's Books", IsTracked = false },
            new Publisher { Name = "Bloomsbury Publishing", IsTracked = false },
            new Publisher { Name = "Bloomsbury Publishing Plc", IsTracked = false },
            new Publisher { Name = "Bloomsbury USA Childrens", IsTracked = false },
            new Publisher { Name = "Bloomsbury USA Children's", IsTracked = false },
            new Publisher { Name = "Blue Box Press", IsTracked = false },
            new Publisher { Name = "Boycott Books, LLC", IsTracked = false },
            new Publisher { Name = "Crown", IsTracked = false },
            new Publisher { Name = "Dandy House", IsTracked = false },
            new Publisher { Name = "DC", IsTracked = false },
            new Publisher { Name = "Del Rey", IsTracked = false },
            new Publisher { Name = "Del Rey Books", IsTracked = false },
            new Publisher { Name = "Disney Lucasfilm Press", IsTracked = false },
            new Publisher { Name = "Entangled: Red Tower Books", IsTracked = false },
            new Publisher { Name = "Ethan Ellenberg Literary Agency", IsTracked = false },
            new Publisher { Name = "Gallery Books", IsTracked = false },
            new Publisher { Name = "Gollancz", IsTracked = false },
            new Publisher { Name = "Hachette Book Group", IsTracked = false },
            new Publisher { Name = "Head of Zeus", IsTracked = false },
            new Publisher { Name = "Independently published", IsTracked = true },
            new Publisher { Name = "LucasBooks/Del Rey Books/Ballantine Books/Random House, Inc.", IsTracked = true },
            new Publisher { Name = "Podium Publishing", IsTracked = true },
            new Publisher { Name = "Portal Books", IsTracked = true },
            new Publisher { Name = "Random House", IsTracked = true },
            new Publisher { Name = "Random House Inc", IsTracked = true },
            new Publisher { Name = "Random House Worlds", IsTracked = true },
            new Publisher { Name = "Roc", IsTracked = false },
            new Publisher { Name = "Rocket Hat Industries", IsTracked = false },
            new Publisher { Name = "Royal Guard Publishing LLC", IsTracked = true },
            new Publisher { Name = "RoyalRoad", IsTracked = true },
            new Publisher { Name = "Sceptre", IsTracked = false },
            new Publisher { Name = "Scholastic Inc.", IsTracked = false },
            new Publisher { Name = "Simon & Schuster Audio / Halo Books", IsTracked = true },
            new Publisher { Name = "Simon Schuster Audio / Halo Books", IsTracked = true },
            new Publisher { Name = "Spice Rack Press", IsTracked = false },
            new Publisher { Name = "Starlit Publishing", IsTracked = false },
            new Publisher { Name = "Summerhold Publishing", IsTracked = false },
            new Publisher { Name = "The Legion Publishers", IsTracked = false },
            new Publisher { Name = "Tolkien GB", IsTracked = false },
            new Publisher { Name = "Tom Doherty Associates", IsTracked = false },
            new Publisher { Name = "Tor", IsTracked = false },
            new Publisher { Name = "Tor Books", IsTracked = false },
            new Publisher { Name = "Wraithmarked Creative, LLC", IsTracked = false },
        });
        SaveChanges();
    }
}
