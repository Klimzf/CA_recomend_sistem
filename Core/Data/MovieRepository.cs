using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA_recomend_sistem.Core.Data;

public class MovieRepository : IMovieRepository
{
    public async Task<IEnumerable<Movie>> GetAllMoviesAsync()
    {
        var movies = new List<Movie>
            {
                new Movie { Id = 1, Title = "Inception", Genre = "Sci-Fi", Rating = 8.8 },
                new Movie { Id = 2, Title = "The Matrix", Genre = "Sci-Fi", Rating = 8.7 },
                new Movie { Id = 3, Title = "Interstellar", Genre = "Sci-Fi", Rating = 8.6 },
                new Movie { Id = 4, Title = "The Dark Knight", Genre = "Action", Rating = 9.0 },
                new Movie { Id = 5, Title = "Fight Club", Genre = "Drama", Rating = 8.8 },
                new Movie { Id = 6, Title = "Pulp Fiction", Genre = "Crime", Rating = 8.9 }
            };
        return await Task.FromResult(movies);
    }
}
