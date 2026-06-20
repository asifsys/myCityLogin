using Microsoft.AspNetCore.Mvc;
using myCityLogin.Web.Models.Hospital;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Web.Helpers;

namespace myCityLogin.Web.Controllers
{
    public class HospitalController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IConfiguration _configuration;
        private readonly HttpClient _httpClient;

        public HospitalController(
            IHttpClientFactory httpClientFactory,
            IConfiguration configuration,
            HttpClient httpClient)
        {
            _httpClientFactory = httpClientFactory;
            _configuration = configuration;
            _httpClient = httpClient;
        }



        [HttpGet]
        public async Task<IActionResult>
            SearchHospital(string location, string category, int page = 1 , int pageSize = 10)

        {
            string apiUrl = $"https://localhost:7120/api/Hospital/SearchAll" + $"?location={location}" + $"&category={category}" + $"&page={page}" + $"&pageSize={pageSize}";

            var response = await _httpClient.GetAsync(apiUrl);

            var jsonData = await response.Content.ReadAsStringAsync();

            //var result = JObject.Parse(jsonData);
            var result = JsonConvert.DeserializeObject<HospitalSearchResponse>(jsonData);

            int lastPage = (int)Math.Ceiling((double)result.Total / pageSize);

            return Json(new
            {
                // data = result["data"].ToObject<object>(),
                data = result.Data,
                last_page = lastPage
            });
        }


        [HttpGet]
        public async Task<IActionResult> GetHospitalsByValue(string? location, string? keyword)
        {
            try
            {
                var client = _httpClientFactory.CreateClient("HospitalAPI");
                var query = $"api/hospital/search?location={location}&keyword={keyword}";
                var response = await client.GetAsync(query);

                if (response.IsSuccessStatusCode)
                {
                    var json = await response.Content.ReadAsStringAsync();
                    var hospitals = System.Text.Json.JsonSerializer.Deserialize<List<HospitalVM>>(
                        json,
                        new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

                    return Json(new { data = hospitals ?? new List<HospitalVM>() });
                }
            }
            catch { }

            return Json(new { data = new List<HospitalVM>() });
        }

        [HttpGet]
        public async Task<JsonResult> Search(string location, string category)
        {
            string apiUrl =
                $"https://localhost:7120/api/Hospital/Search?location={location}&category={category}";

            var response = await _httpClient.GetAsync(apiUrl);

            if (!response.IsSuccessStatusCode)
            {
                return Json(new List<HospitalVM>());
            }

            var data = await response.Content.ReadFromJsonAsync<List<HospitalVM>>();

            return Json(data);
        }

    }
}
