using Microsoft.AspNetCore.Mvc;
using myCityLogin.Web.Models.Users;

namespace myCityLogin.Web.Controllers
{
    public class ProviderController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public ProviderController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public IActionResult Provider()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateProvider([FromBody] ProviderRequest modelval)
        {
            try
            {
                HttpClient client = _httpClientFactory.CreateClient();

                client.BaseAddress = new Uri("https://localhost:7120/");

                HttpResponseMessage response = await client.PostAsJsonAsync("api/Provider/Create", modelval);
                string responseText = await response.Content.ReadAsStringAsync(); // testing for responding data.

                if (response.IsSuccessStatusCode)
                {
                    return Json(new
                    { 
                        success = true,
                        message = "Provider saved successfully."
                    });
                }

                string error = await response.Content.ReadAsStringAsync();

                return Json(new
                {
                    success = false,
                    message = string.IsNullOrWhiteSpace(error)
                                ? "Failed to save provider."
                                : error
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
