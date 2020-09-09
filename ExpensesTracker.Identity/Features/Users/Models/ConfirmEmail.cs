namespace ExpensesTracker.Identity.Features.Users.Models
{
    public class ConfirmEmail
    {
        public class ConfirmEmailRequest
        {
            public string Code { get; set; }
        }
    }
}
