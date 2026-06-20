namespace myCityLogin.AccountService.API.Models
{
    public class Notification
    {
        public long Id { get; set; }

        public long UserId { get; set; }

        public string Title { get; set; }

        public string Message { get; set; }

        public bool IsRead { get; set; }

        public DateTime CreatedAt { get; set; }
    }
}
