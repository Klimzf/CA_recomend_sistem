using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ca_recomend_sistem.Core.Entities
{
    public class User : IEntity
    {
        public Id Id { get; set; }
        public string Name { get; set; }

        public string Email { get; set; }

        public string Number { get; set; }
        public List<UserMovieRating> MovieRatings { get; set; }
    }
}
