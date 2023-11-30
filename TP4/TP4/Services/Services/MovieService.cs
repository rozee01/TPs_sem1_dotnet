using TP4.Models;

namespace TP4.Services.Services
{
    public class MovieService
    {
        private readonly AppDbContext _dbContext;

        public MovieService(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<Movie> GetMoviesByGenre(string genreName)
        {
            // Utiliser LINQ pour récupérer tous les films associés au genre spécifié
            var movies = _dbContext.Movies
                .Where(movie => movie.Genre.GenreName == genreName)  // Filtrer par le nom du genre
                .ToList();

            return movies;
        }
        public List<Movie> GetMoviesOrderedByReleaseDate()
        {
            // Utiliser LINQ pour récupérer tous les films ordonnés par date de sortie croissante
            var orderedMovies = _dbContext.Movies
                .OrderBy(movie => movie.ReleaseDate)
                .ToList();

            return orderedMovies;
        }
        public List<Movie> GetMoviesByGenreId(int genreId)
        {
            // Utiliser LINQ pour récupérer les films par leur genre ID
            var moviesByGenre = _dbContext.Movies
                .Where(movie => movie.GenreId == genreId)
                .ToList();

            return moviesByGenre;
        }
    }

}
