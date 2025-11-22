namespace MovieApi.Models
{
    public class Movie
    {
        public int Id { get; set; } // Primary Key
        public string Title { get; set; } = string.Empty;
        public int Year { get; set; }
        public string Genre { get; set; } = string.Empty;

        // Foreign Key for Director
        public int DirectorId { get; set; }

        // Navigation property: Many-to-One with Director
        public Director Director { get; set; } = null!;

        // Navigation property: Many-to-Many with Actors
        public ICollection<Actor> Actors { get; set; } = new List<Actor>();
    }
}