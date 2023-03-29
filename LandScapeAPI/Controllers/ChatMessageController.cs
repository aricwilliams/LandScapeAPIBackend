using LandScapeAPI.Repo;
using Microsoft.AspNetCore.Mvc;

namespace LandScapeAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChatMessageController : ControllerBase
    {
        private readonly IChatMessage _chatMessage;

        public ChatMessageController(IChatMessage chatMessage)
        {
            _chatMessage = chatMessage;
        }

        [HttpGet]
        public async Task<ActionResult<List<ChatMessage>>> GetAllAsync()
        {
            var chatMessages = await _chatMessage.GetAllAsync();
            return Ok(chatMessages);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ChatMessage>> GetByIdAsync(int id)
        {
            var chatMessage = await _chatMessage.GetByIdAsync(id);
            if (chatMessage == null)
            {
                return NotFound();
            }

            return Ok(chatMessage);
        }

        [HttpPost]
        public async Task<ActionResult<ChatMessage>> CreateAsync(ChatMessage chatMessage)
        {
            var createdChatMessage = await _chatMessage.CreateAsync(chatMessage);
            return CreatedAtAction(nameof(GetByIdAsync), new { id = createdChatMessage.Id }, createdChatMessage);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<ChatMessage>> UpdateAsync(int id, ChatMessage chatMessage)
        {
            if (id != chatMessage.Id)
            {
                return BadRequest();
            }

            var existingChatMessage = await _chatMessage.GetByIdAsync(id);
            if (existingChatMessage == null)
            {
                return NotFound();
            }

            await _chatMessage.UpdateAsync(chatMessage);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var chatMessage = await _chatMessage.GetByIdAsync(id);
            if (chatMessage == null)
            {
                return NotFound();
            }

            await _chatMessage.DeleteAsync(chatMessage);

            return NoContent();
        }
    }
}
