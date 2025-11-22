namespace MovieApi.Models
{
    public class Actor
    {
        public int Id { get; set; } // Primary Key
        public string Name { get; set; } = string.Empty;
        public string Nationality { get; set; } = string.Empty;
        public DateTime BirthDate { get; set; }

        // Navigation property: Many-to-Many with Movies
        public ICollection<Movie> Movies { get; set; } = new List<Movie>();
    }
}