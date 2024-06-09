using Ca_recomend_sistem.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ca_recomend_sistem.Core;
public record Id(Guid Value);
public interface IEntity
{
    Id Id { get; }
}

public interface IMovieRepository
{
    Task<IEnumerable<Movie>> GetAllMoviesAsync();
}

public interface IMovieRecommendationService
{
    Task<IEnumerable<Movie>> GetRecommendedMoviesAsync();
    Task<IEnumerable<Movie>> GetRecommendedMoviesForUserAsync(Id userId);
}

public interface IUserRepository
{
    Task<User> GetUserByIdAsync(Id userId);
}

public interface IUserMovieRatingRepository
{
    Task<IEnumerable<UserMovieRating>> GetUserMovieRatingsAsync(Id userId);
}
