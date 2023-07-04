using Arpti.Infra.CrossCutting.RabbitMq;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Arpi.Robo.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoboController : Controller
    {
        [HttpGet("instalacao-winrar")]
        public async Task<IActionResult> InstalacaoWinRAR()
        {
            try
            {
                var _rabbitMQService = new RabbitMQService();
				var resposta = _rabbitMQService.PublicarMensagem("WinRAR");

                return Ok(resposta);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

		[HttpGet("instalacao-operagx")]
		public async Task<IActionResult> InstalacaoOperaGX()
		{
			try
			{
				var _rabbitMQService = new RabbitMQService();
				var resposta = _rabbitMQService.PublicarMensagem("OperaGX");

				return Ok(resposta);
			}
			catch (Exception ex)
			{
				return BadRequest(ex.Message);
			}
		}

		[HttpGet("instalacao-vlc")]
		public async Task<IActionResult> InstalacaoVLCPlayer()
		{
			try
			{
				var _rabbitMQService = new RabbitMQService();
				var resposta = _rabbitMQService.PublicarMensagem("VLCPlayer");

				return Ok(resposta);
			}
			catch (Exception ex)
			{
				return BadRequest(ex.Message);
			}
		}

		[HttpGet("instalacao-vscode")]
		public async Task<IActionResult> InstalacaoVSCode()
		{
			try
			{
				var _rabbitMQService = new RabbitMQService();
				var resposta = _rabbitMQService.PublicarMensagem("VSCode");

				return Ok(resposta);
			}
			catch (Exception ex)
			{
				return BadRequest(ex.Message);
			}
		}

		[HttpGet("instalacao-python")]
		public async Task<IActionResult> InstalacaoPython()
		{
			try
			{
				var _rabbitMQService = new RabbitMQService();
				var resposta = _rabbitMQService.PublicarMensagem("Python");

				return Ok(resposta);
			}
			catch (Exception ex)
			{
				return BadRequest(ex.Message);
			}
		}
	}
}
