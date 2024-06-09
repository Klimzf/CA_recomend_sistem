using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ca_recomend_sistem.Core.Data;

public class UserMovieRatingRepository : IUserMovieRatingRepository
{
    public async Task<IEnumerable<UserMovieRating>> GetUserMovieRatingsAsync(int userId)
    {
        var ratings = new List<UserMovieRating>
            {
                new UserMovieRating { UserId = 1, MovieId = 1, Rating = 5 },
                new UserMovieRating { UserId = 1, MovieId = 2, Rating = 4 },
                new UserMovieRating { UserId = 2, MovieId = 3, Rating = 5 },
                new UserMovieRating { UserId = 2, MovieId = 4, Rating = 3 }
            };
        return await Task.FromResult(ratings.Where(r => r.UserId == userId));
    }
}
