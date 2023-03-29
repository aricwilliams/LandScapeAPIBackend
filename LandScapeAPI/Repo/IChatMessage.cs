namespace LandScapeAPI.Repo
{
    public interface IChatMessage
    {
        Task<List<ChatMessage>> GetAllAsync();
        Task<ChatMessage> GetByIdAsync(int id);
        Task<ChatMessage> CreateAsync(ChatMessage chatMessage);
        Task UpdateAsync(ChatMessage chatMessage);
        Task DeleteAsync(ChatMessage chatMessage);
    }
}
