namespace myCityLogin.HospitalService.API.Models
{
    public class Provider
    {
        public int Id { get; set; }

        public string ProviderCode { get; set; }

        public string ProviderJson { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime CreatedDate { get; set; }
    }
}
