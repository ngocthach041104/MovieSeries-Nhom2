using System;
using System.Collections.Generic;

namespace Pj.CoreLayer.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public DateTime CreatedAt { get; set; }

        // Quan hệ 1-n với Review
        public ICollection<Review> Reviews { get; set; }

        // Quan hệ 1-n với Rating
        public ICollection<Rating> Ratings { get; set; }
    }
}
