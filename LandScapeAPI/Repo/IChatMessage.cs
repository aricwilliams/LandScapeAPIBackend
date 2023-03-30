using LandScapeAPI.Models;

namespace LandScapeAPI.Repo
{
    public interface IChatMessage
    {
        Task<List<ChatMessageM>> GetAllAsync();
        Task<ChatMessageM> GetByIdAsync(int id);
        Task<ChatMessageM> CreateAsync(ChatMessageM chatMessage);
        Task UpdateAsync(ChatMessageM chatMessage);
        Task DeleteAsync(ChatMessageM chatMessage);
    }
}
