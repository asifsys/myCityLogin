namespace myCityLogin.Web.Models.Hospital
{
    
    public class HospitalVM
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Location { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Specialization { get; set; } = string.Empty;
        public bool IsActive { get; set; }
        public DateTime CreatedAt { get; set; }
    }

    //public class HospitalSearchVM
    //{
    //    public string? Location { get; set; }
    //    public string? Keyword { get; set; }
    //    public List<HospitalVM> Results { get; set; } = new();
    //}

    public class HospitalSearchResponse
    {
        public List<HospitalVM> Data { get; set; }
        public int Total { get; set; }
    }
}
