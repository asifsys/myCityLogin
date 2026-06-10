using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using myCityLogin.Web.Models.Home;

namespace myCityLogin.Web.Controllers
{
    public class UserController :Controller
    {

        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IConfiguration _configuration;
        private readonly HttpClient _httpClient;

        public UserController(
            IHttpClientFactory httpClientFactory,
            IConfiguration configuration,
            HttpClient httpClient)
        {
            _httpClientFactory = httpClientFactory;
            _configuration = configuration;
            _httpClient = httpClient;
        }

        public async Task<IActionResult> Login([FromBody] UserVM model)
        {
            try
            {
                string apiUrl = "https://localhost:7260/api/auth/login";

                var response = await _httpClient.PostAsJsonAsync(apiUrl, model);

                var result = await response.Content.ReadAsStringAsync();

                return Json(new
                {
                    success = response.IsSuccessStatusCode,
                    message = result
                });
            }
            catch (Exception ex)
            {
                return Json(new
                {
                    success = false,
                    message = ex.Message
                });
            }
        }

        [HttpPost]
        public async Task<IActionResult> RegisterUser([FromBody] UserVM model)
        {
            try
            {
                string apiUrl = "https://localhost:7260/api/auth/register";

                var response = await _httpClient.PostAsJsonAsync( apiUrl, model);

                var result =   await response.Content.ReadAsStringAsync();

                return Json(new
                {
                    success = response.IsSuccessStatusCode,
                    message = result
                });
            }
            catch (Exception ex)
            {
                return Json(new
                {
                    success = false,
                    message = ex.Message
                });
            }
        }

    }
}
