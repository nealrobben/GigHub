using GigHub.Core;
using GigHub.Core.Dtos;
using GigHub.Core.Models;
using GigHub.Persistence;
using Microsoft.AspNet.Identity;
using System.Linq;
using System.Web.Http;

namespace GigHub.Controllers.Api
{
    [Authorize]
    public class FollowingsController : ApiController
    {
        private readonly ApplicationDbContext _context;
        private readonly IUnitOfWork _unitOfWork;

        public FollowingsController(IUnitOfWork unitOfWork)
        {
            _context = new ApplicationDbContext();
            _unitOfWork = unitOfWork;
        }

        [HttpPost]
        public IHttpActionResult Follow(FollowingDto dto)
        {

            if (_unitOfWork.Followings.IsFollowing(User.Identity.GetUserId(), dto.FolloweeId))
            {
                return BadRequest("Following already exists");
            }

            var following = new Following
            {
                FollowerId = User.Identity.GetUserId(),
                FolloweeId = dto.FolloweeId
            };

            _unitOfWork.Followings.Add(following);
            _unitOfWork.Complete();

            return Ok();
        }

        [HttpDelete]
        public IHttpActionResult DeleteFollowing(string id)
        {
            // !!! The parameter has to be called 'id' and not 'followingId' or this won't work!!!


            var following = _unitOfWork.Followings.GetFollowing(User.Identity.GetUserId(), id);

            if (following == null)
            {
                return NotFound();
            }

            _unitOfWork.Followings.Remove(following);
            _unitOfWork.Complete();

            return Ok(id);
        }
    }
}
