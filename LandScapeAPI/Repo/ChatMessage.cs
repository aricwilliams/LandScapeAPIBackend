using LandScapeAPI.Utility;

namespace LandScapeAPI.Repo
{
    public class ChatMessage : IChatMessage
    {
        private readonly ProductDbContext _dbContext;

        public ChatMessageRepository(ProductDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<ChatMessage>> GetAllAsync()
        {
            return await _dbContext.ChatMessages.ToListAsync();
        }
        public async Task<ChatMessage> GetByIdAsync(int id)
        {
            return await _dbContext.ChatMessages.FindAsync(id);
        }

        public async Task<ChatMessage> CreateAsync(ChatMessage chatMessage)
        {
            _dbContext.ChatMessages.Add(chatMessage);
            await _dbContext.SaveChangesAsync();
            return chatMessage;
        }

        public async Task UpdateAsync(ChatMessage chatMessage)
        {
            _dbContext.Entry(chatMessage).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(ChatMessage chatMessage)
        {
            _dbContext.ChatMessages.Remove(chatMessage);
            await _dbContext.SaveChangesAsync();
        }
    }
}
