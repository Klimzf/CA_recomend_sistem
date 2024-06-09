using CA_recomend_sistem.Core.Entities;
using CA_recomend_sistem.Core.Interfaces;

namespace CA_recomend_sistem.Application.Services;

public class MovieRecommendationService : IMovieRecommendationService
{
    private readonly IUserRepository _userRepository;
    private readonly IMovieRepository _movieRepository;
    private readonly IUserMovieRatingRepository _userMovieRatingRepository;

    public MovieRecommendationService(
        IUserRepository userRepository,
        IMovieRepository movieRepository,
        IUserMovieRatingRepository userMovieRatingRepository)
    {
        _userRepository = userRepository;
        _movieRepository = movieRepository;
        _userMovieRatingRepository = userMovieRatingRepository;
    }

    public async Task<IEnumerable<Movie>> GetRecommendedMoviesAsync()
    {
        var movies = await _movieRepository.GetAllMoviesAsync();
        return movies.OrderByDescending(m => m.Rating).Take(5);
    }

    public async Task<IEnumerable<Movie>> GetRecommendedMoviesForUserAsync(int userId)
    {
        var user = await _userRepository.GetUserByIdAsync(userId);
        if (user == null)
        {
            return new List<Movie>();
        }

        var userRatings = await _userMovieRatingRepository.GetUserMovieRatingsAsync(userId);
        var allMovies = await _movieRepository.GetAllMoviesAsync();

        var recommendedMovies = allMovies
            .Where(movie => !userRatings.Any(r => r.MovieId == movie.Id))
            .OrderByDescending(movie => movie.Rating)
            .Take(5);

        return recommendedMovies;
    }
}


