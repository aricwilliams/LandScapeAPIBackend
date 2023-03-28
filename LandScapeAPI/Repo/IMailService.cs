using LandScapeAPI.Models;

namespace LandScapeAPI.Repo
{
    public interface IMailService
    {
        Task<bool> SendAsync(MailData mailData, CancellationToken ct);

    }
}
