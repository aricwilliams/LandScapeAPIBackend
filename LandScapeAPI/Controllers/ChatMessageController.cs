using LandScapeAPI.Models;
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
        public async Task<ActionResult<ChatMessageM>> GetByIdAsync(int id)
        {
            var chatMessagee = await _chatMessage.GetByIdAsync(id);
            if (chatMessagee == null)
            {
                return NotFound();
            }

            return Ok(chatMessagee);
        }

        [HttpPost]
        public async Task<ActionResult<ChatMessageM>> CreateAsync(ChatMessageM chatMessage)
        {
            var createdChatMessage = await _chatMessage.CreateAsync(chatMessage);
            return CreatedAtAction(nameof(GetByIdAsync), new { id = createdChatMessage.Id }, createdChatMessage);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<ChatMessageM>> UpdateAsync(int id, ChatMessageM chatMessage)
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
            var chatMessagee = await _chatMessage.GetByIdAsync(id);
            if (chatMessagee == null)
            {
                return NotFound();
            }

            await _chatMessage.DeleteAsync(chatMessagee);

            return NoContent();
        }
    }
}
