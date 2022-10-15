using System.Text.Encodings.Web;
using System.Threading.Tasks;

namespace project.Services
{
    public static class EmailSenderExtensions
    {
        public static Task SendEmailConfirmationAsync(this IEmailSender emailSender, string email, string link)
        {
            string linkEncoded = $"Please confirm your account by clicking this link: <a href='{HtmlEncoder.Default.Encode(link)}'>link</a>";
            return emailSender.SendEmailAsync(email, "Confirm your email", linkEncoded);
        }
    }
}
