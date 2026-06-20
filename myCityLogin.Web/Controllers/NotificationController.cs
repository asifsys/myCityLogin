using Microsoft.AspNetCore.Mvc;

namespace myCityLogin.Web.Controllers
{
    public class NotificationController : Controller
    {
        private readonly HttpClient _httpClient;

        public NotificationController(
            IHttpClientFactory factory)
        {
            _httpClient = factory.CreateClient();
        }

        public async Task<JsonResult>  GetUnreadCount(long userId=1)
        {
            var count =  await _httpClient.GetFromJsonAsync<int>($"https://localhost:7260/api/notification/count/{userId}");
            return Json(count);
        }

        public async Task<JsonResult> GetNotifications(long userId= 1)
        {
            var data = await _httpClient.GetStringAsync( $"https://localhost:7260/api/notification/{userId}");
            return Json(data);
        }
    }
}
