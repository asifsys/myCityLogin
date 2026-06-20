namespace myCityLogin.Web.Models.Users
{
    public class ProviderRequest
    {
        public string ProviderType { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Gender { get; set; }

        public DateTime? DOB { get; set; }

        public string ContactNumber { get; set; }

        public string Email { get; set; }

        public string UserName { get; set; }

        public string Password { get; set; }

        //public string ProfileImage { get; set; }

        public string Qualification { get; set; }

        public string Speciality { get; set; }

        public int Experience { get; set; }

        public string RegistrationNumber { get; set; }

        public string Status { get; set; }

        public bool IsActive { get; set; }

        public bool IsCertified { get; set; }

        public AddressModel Address { get; set; } = new();

        public List<CertificationModel> Certifications { get; set; } = new();
    }

    public class AddressModel
    {
        public string Address1 { get; set; }

        public string City { get; set; }

        public string State { get; set; }

        public string PinCode { get; set; }

    }

    public class CertificationModel
    {
        public string CertificationName { get; set; }

        public string CertificateNumber { get; set; }

        public int Year { get; set; }

        public string Provider { get; set; }
    }
}
