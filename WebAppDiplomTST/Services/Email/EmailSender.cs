using Microsoft.AspNetCore.Identity.UI.Services;

namespace WebAppDiplomTST.Services.Email
{
    public class EmailSender : IEmailSender
    {
        public async Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            //TODO Create Email services
            await Task.CompletedTask;
        }
    }
}
