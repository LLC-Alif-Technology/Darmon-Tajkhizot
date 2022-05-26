using System.Threading.Tasks;

namespace Contracts.Services
{
    public interface IEmailService
    {
        Task SendPasswordResetMailAsync(string receiverEmail, string token, string backUrl);
    }
}
