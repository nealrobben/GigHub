using GigHub.Core.Models;
using GigHub.Core.Repositories;
using GigHub.Persistence;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace GigHub.Persistence.Repositories
{
    public class GigRepository : IGigRepository
    {
        private readonly IApplicationDbContext _context;

        public GigRepository(IApplicationDbContext context)
        {
            this._context = context;
        }

        public Gig GetGig(int gigId)
        {
            return _context.Gigs.Single(g => g.Id == gigId);
        }

        public Gig GetGigWithAttendees(int gigId)
        {
            return _context.Gigs
                .Include(g => g.Attendances.Select(a => a.Attendee))
                .SingleOrDefault(g => g.Id == gigId);
        }

        public Gig GetGigWithArtistAndGenre(int gigId)
        {
            return _context.Gigs
                .Include(g => g.Artist)
                .Include(g => g.Genre)
                .SingleOrDefault(g => g.Id == gigId);
        }

        public IEnumerable<Gig> GetMyUpcomingGigs(string userId)
        {
            return _context.Gigs
                .Where(a => a.ArtistId == userId && a.DateTime > DateTime.Now && !a.IsCanceled)
                .Include(a => a.Genre);
        }

        public IEnumerable<Gig> GetUpcomingGigs()
        {
            return _context.Gigs
                .Include(m => m.Artist)
                .Include(m => m.Genre)
                .Where(m => m.DateTime > DateTime.Now && !m.IsCanceled);
        }

        public IEnumerable<Gig> GetGigsUserAttending(string userId)
        {
            return _context.Attendances
                .Where(a => a.AttendeeId == userId)
                .Select(a => a.Gig)
                .Include(g => g.Artist)
                .Include(g => g.Genre)
                .ToList();
        }

        public void Add(Gig gig)
        {
            _context.Gigs.Add(gig);
        }
    }
}