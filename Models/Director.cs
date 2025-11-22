namespace MovieApi.Models
{
    public class Director
    {
        public int Id { get; set; } // Primary Key
        public string Name { get; set; } = string.Empty;
        public string Nationality { get; set; } = string.Empty;
        public DateTime BirthDate { get; set; }

        // Navigation property: One Director can have many Movies
        public ICollection<Movie> Movies { get; set; } = new List<Movie>();
    }
}