using GigHub.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GigHub.Core.Repositories
{
    public interface IUserNotificationsRepository
    {
        IEnumerable<UserNotification> GetUnreadNoticicationsForUser(string userId);
        IEnumerable<Notification> GetNewNotifications(string userId);
    }
}
