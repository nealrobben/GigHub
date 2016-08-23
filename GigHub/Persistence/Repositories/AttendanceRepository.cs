using GigHub.Core.Models;
using GigHub.Core.Repositories;
using GigHub.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GigHub.Persistence.Repositories
{
    public class AttendanceRepository : IAttendanceRepository
    {
        private readonly ApplicationDbContext _context;

        public AttendanceRepository(ApplicationDbContext context)
        {
            this._context = context;
        }

        public IEnumerable<Attendance> GetFutureAttendances(string userId)
        {
            return _context.Attendances
                .Where(g => g.AttendeeId == userId && g.Gig.DateTime > DateTime.Now)
                .ToList();
        }

        public Attendance GetAttendance(string userId, int gigId)
        {
            return _context.Attendances.SingleOrDefault(g => g.AttendeeId == userId && g.GigId == gigId);
        }

        public void Add(Attendance attendance)
        {
            _context.Attendances.Add(attendance);
        }

        public void Remove(Attendance attendance)
        {
            _context.Attendances.Remove(attendance);
        }

        public bool IsAttending(int gigId, string userId)
        {
            return _context.Attendances.Any(g => g.GigId == gigId && g.AttendeeId == userId);
        }

        public Attendance GetAttendance(int gigId, string userId)
        {
            return _context.Attendances.SingleOrDefault(g => g.AttendeeId == userId && g.GigId == gigId);
        }
    }
}