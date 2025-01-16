using Microsoft.AspNetCore.Mvc;
using oracle_web_api.Interfaces;
namespace oracle_web_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AttentionController : ControllerBase
    {
        private readonly IAttentionService _attentionService;

        public AttentionController(IAttentionService attentionService)
        {
            _attentionService = attentionService;
        }

        // GET api/attention/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var attention = await _attentionService.GetAttentionByIdAsync(id);

                if (attention == null)
                {
                    return NotFound(new
                    {
                        status = false,
                        message = "No se encontraron resultados."
                    });
                }

                return Ok(new
                {
                    status = true,
                    data = attention
                });
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(new
                {
                    status = false,
                    message = $"Error de operación inválida: {ex.Message}"
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new
                {
                    status = false,
                    message = $"Error inesperado: {ex.Message}"
                });
            }
        }
    }
}
