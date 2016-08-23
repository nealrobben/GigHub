using System.Collections.Generic;
using GigHub.Core.Models;

namespace GigHub.Core.Repositories
{
    public interface IAttendanceRepository
    {
        Attendance GetAttendance(string userId, int gigId);
        IEnumerable<Attendance> GetFutureAttendances(string userId);
        void Add(Attendance attendance);
        void Remove(Attendance attendance);
        bool IsAttending(int gigId, string userId);
        Attendance GetAttendance(int gigId, string userId);
    }
}