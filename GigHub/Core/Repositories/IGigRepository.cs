using System.Collections.Generic;
using GigHub.Core.Models;

namespace GigHub.Core.Repositories
{
    public interface IGigRepository
    {
        void Add(Gig gig);
        Gig GetGig(int gigId);
        IEnumerable<Gig> GetGigsUserAttending(string userId);
        Gig GetGigWithArtistAndGenre(int gigId);
        Gig GetGigWithAttendees(int gigId);
        IEnumerable<Gig> GetMyUpcomingGigs(string userId);
        IEnumerable<Gig> GetUpcomingGigs();
    }
}