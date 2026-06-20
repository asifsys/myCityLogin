using Microsoft.AspNetCore.Mvc;
using myCityLogin.AccountService.API.Interfaces;

namespace myCityLogin.AccountService.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class NotificationController : ControllerBase
    {
        private readonly INotificationService _service;

        public NotificationController(
            INotificationService service)
        {
            _service = service;
        }

        [HttpGet("{userId}")]
        public async Task<IActionResult> Get(long userId)
        {
            var data =  await _service.GetNotificationsAsync(userId);

            return Ok(data);
        }

        [HttpGet("count/{userId}")]
        public async Task<IActionResult> Count(long userId)
        {
            var count = await _service.GetUnreadCountAsync(userId);

            return Ok(count);
        }
    }
}
