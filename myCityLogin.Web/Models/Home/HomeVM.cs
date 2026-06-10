using System.ComponentModel.DataAnnotations;

namespace myCityLogin.Web.Models.Home
{
    public class HomeVM
    {
        public List<HospitalVm> HospitalList {  get; set; }
    }

    public class HospitalVm
    {
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public string Location { get; set; } = string.Empty;

        public string Address { get; set; } = string.Empty;

        public string Phone { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;

        public string Specialization { get; set; } = string.Empty;

        public bool IsActive { get; set; } = true;

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
