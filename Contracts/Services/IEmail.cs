using System.Threading.Tasks;

public interface IEmailService
{
    Task SendPasswordResetMailAsync(string receiverEmail, string token, string backUrl);
}
