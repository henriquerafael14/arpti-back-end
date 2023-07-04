using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Text;
using System.Threading;

namespace Arpti.Infra.CrossCutting.RabbitMq
{
    public class RabbitMQService
	{
		private readonly ConnectionFactory _configuracao;

        public RabbitMQService()
        {
            _configuracao = new ConnectionFactory { HostName = "localhost" };
            _configuracao.Port = 5672;
            _configuracao.UserName = "guest";
            _configuracao.Password = "guest";
        }

        public string PublicarMensagem(string mensagem)
		{
			try
			{
				using (var conexao = _configuracao.CreateConnection())
				using (var canal = conexao.CreateModel())
				{
					canal.QueueDeclare("Arpti_RoboInstalador_Envios", false, false, false, null);
					canal.QueueDeclare("Arpti_RoboInstalador_Respostas", false, false, false, null);

					var body = Encoding.UTF8.GetBytes(mensagem);
					canal.BasicPublish("", "Arpti_RoboInstalador_Envios", null, body);

					var consumer = new EventingBasicConsumer(canal);
					string resposta = null;
					//string usuario = null;

					consumer.Received += (model, ea) =>
					{
						var body = ea.Body.ToArray();
						resposta = Encoding.UTF8.GetString(body);
						//usuario = ea.BasicProperties.CorrelationId;
						//if (usuario != "usuario_catolica")
						//	return "Resposta de usuario não encontrada";
					};

					canal.BasicConsume("Arpti_RoboInstalador_Respostas", true, consumer);

                    while (resposta == null)
                    {
						Thread.Sleep(3000);
					}

					return resposta;
				}
			}
			catch (Exception ex)
			{
				throw ex;
			}
        }
    }
}
