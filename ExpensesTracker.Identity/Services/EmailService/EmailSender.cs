using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.UI.Services;

namespace ExpensesTracker.Identity.Services.EmailService
{
    public class EmailSender : IEmailSender
    {
        // TODO: Implement SendGrid
        public Task SendEmailAsync(string email, string subject, string message)
        {
            return Task.CompletedTask;
        }
    }
}
