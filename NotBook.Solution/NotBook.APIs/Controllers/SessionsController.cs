using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NotBook.Application.DTOs;
using NotBook.Application.IServices;

namespace NotBook.APIs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SessionsController : ControllerBase
    {
        private readonly ISessionService _sessionService;

        public SessionsController(ISessionService sessionService)
        {
            _sessionService = sessionService;
        }
        [HttpPost]

        public async Task<IActionResult> CreateSession(CreateSessionDto dto)
        {
            try
            {
                var result = await _sessionService.CreateSessionAsync(dto);
                return Ok(result);
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }
        [HttpPost("join")]
        public async Task<IActionResult> JoinSession(JoinSessionDto dto)
        {
            try
            {
                var result = await _sessionService.JoinSessionAsync(dto);
                return Ok(result);
            }
            catch (InvalidOperationException ex)
            {
                return NotFound(new { message = ex.Message });
            }
        }
    }
}
