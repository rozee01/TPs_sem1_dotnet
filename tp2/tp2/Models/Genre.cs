namespace tp2.Models
{
    public class Genre
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        // Propriété de navigation pour représenter que plusieurs films correspondent à un même genre
        public ICollection<Movie> Movies { get; set; }
    }
}
