using LandScapeAPI.Models;
using LandScapeAPI.Utility;
using Microsoft.EntityFrameworkCore;

namespace LandScapeAPI.Repo
{
    public class ChatMessage : IChatMessage
    {
        private readonly ProductDbContext _dbContext;

        public ChatMessage(ProductDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<ChatMessageM>> GetAllAsync()
        {
            return await _dbContext.ChatMessages.ToListAsync();
        }
        public async Task<ChatMessageM> GetByIdAsync(int id)
        {
            return await _dbContext.ChatMessages.FindAsync(id);
        }

        public async Task<ChatMessageM> CreateAsync(ChatMessageM chatMessage)
        {
            _dbContext.ChatMessages.Add(chatMessage);
            await _dbContext.SaveChangesAsync();
            return chatMessage;
        }

        public async Task UpdateAsync(ChatMessageM chatMessage)
        {
            _dbContext.Entry(chatMessage).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(ChatMessageM chatMessage)
        {
            _dbContext.ChatMessages.Remove(chatMessage);
            await _dbContext.SaveChangesAsync();
        }
    }
}
