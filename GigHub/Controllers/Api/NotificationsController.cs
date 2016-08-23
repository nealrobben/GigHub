using AutoMapper;
using GigHub.Core;
using GigHub.Core.Dtos;
using GigHub.Core.Models;
using GigHub.Persistence;
using Microsoft.AspNet.Identity;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web.Http;

namespace GigHub.Controllers.Api
{
    [Authorize]
    public class NotificationsController : ApiController
    {
        private readonly IUnitOfWork _unitOfWork;

        public NotificationsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IEnumerable<NotificationDto> GetNewNotifications()
        {
            var notifications = _unitOfWork.UserNotifications.GetNewNotifications(User.Identity.GetUserId());

            return notifications.Select(Mapper.Map<Notification,NotificationDto>);
        }

        [HttpPost]
        public IHttpActionResult MarkAsRead()
        {
            var notifications = _unitOfWork.UserNotifications.GetUnreadNoticicationsForUser(User.Identity.GetUserId());

            foreach(UserNotification n in notifications)
            {
                n.Read();
            }

            _unitOfWork.Complete();

            return Ok();
        }
    }
}
