using Arpti.Infra.CrossCutting.RabbitMq;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Arpi.Robo.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoboController : Controller
    {
        private readonly RabbitMQService _rabbitMQService;

        public RoboController()
        {
            _rabbitMQService = new RabbitMQService("queue_instalacao");
        }

        [HttpGet("instalacao-winrar")]
        public async Task<IActionResult> InstalacaoWinRAR()
        {
            // Envia uma mensagem para a fila do RabbitMQ
            _rabbitMQService.EnqueueMessage("WinRAR");
            return Ok("Solicitação de instalação enviada com sucesso");
        }
    }
}
