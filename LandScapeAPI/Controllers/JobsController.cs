using LandScapeAPI.Models;
using LandScapeAPI.Repo;
using Microsoft.AspNetCore.Mvc;

namespace LandScapeAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JobsController : ControllerBase
    {
        private readonly IJobs _jobs;

        public JobsController(IJobs jobs)
        {
            _jobs = jobs;
        }

        [HttpGet]
        public async Task<ActionResult<List<JobsM>>> GetAllAsync()
        {
            var jobss = await _jobs.GetAllAsync();
            return Ok(jobss);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<JobsM>> GetByIdAsync(int id)
        {
            var job = await _jobs.GetByIdAsync(id);
            if (job == null)
            {
                return NotFound();
            }

            return Ok(job);
        }

        [HttpPost]
        public async Task<ActionResult<JobsM>> CreateAsync(JobsM job)
        {
            var createdJob = await _jobs.CreateAsync(job);
            return CreatedAtAction(nameof(GetByIdAsync), new { id = createdJob.Id }, createdJob);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<JobsM>> UpdateAsync(int id, JobsM job)
        {
            if (id != job.Id)
            {
                return BadRequest();
            }

            var existingJob = await _jobs.GetByIdAsync(id);
            if (existingJob == null)
            {
                return NotFound();
            }

            await _jobs.UpdateAsync(job);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var job = await _jobs.GetByIdAsync(id);
            if (job == null)
            {
                return NotFound();
            }

            await _jobs.DeleteAsync(job);

            return NoContent();
        }
    }
}
