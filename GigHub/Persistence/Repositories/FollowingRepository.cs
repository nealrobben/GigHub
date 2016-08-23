using GigHub.Core.Models;
using GigHub.Core.Repositories;
using GigHub.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GigHub.Persistence.Repositories
{
    public class FollowingRepository : IFollowingRepository
    {
        private readonly ApplicationDbContext _context;

        public FollowingRepository(ApplicationDbContext context)
        {
            this._context = context;
        }

        public Following GetFollowing(string userId, string artistId)
        {
            return _context.Followings.SingleOrDefault(g => g.FollowerId == userId && g.FolloweeId == artistId);
        }

        public void Add(Following following)
        {
            _context.Followings.Add(following);
        }

        public void Remove(Following following)
        {
            _context.Followings.Remove(following);
        }

        public bool IsFollowing(string userId, string followeeId)
        {
            return _context.Followings.Any(f => f.FollowerId == userId && f.FolloweeId == followeeId);
        }
    }
}