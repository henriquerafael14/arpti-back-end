using RabbitMQ.Client;
using System.Text;

namespace Arpti.Infra.CrossCutting.RabbitMq
{
    public class RabbitMQService
    {
        private readonly string _queueName;
        private readonly ConnectionFactory _configuracao;
        private readonly IConnection _conexao;
        private readonly IModel _canal;

        public RabbitMQService(string queueName)
        {
            _queueName = queueName;

            //var configuracao = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("RabbitMqConfig.json").Build();

            //_configuracao = new ConnectionFactory { HostName = configuracao.GetSection("HostName").Value };
            //_configuracao.Port = Convert.ToInt32(configuracao.GetSection("Port").Value);
            //_configuracao.UserName = configuracao.GetSection("Usuario").Value;
            //_configuracao.Password = configuracao.GetSection("Senha").Value;

            _configuracao = new ConnectionFactory { HostName = "localhost" };
            _configuracao.Port = 5672;
            _configuracao.UserName = "guest";
            _configuracao.Password = "guest";
            _conexao = _configuracao.CreateConnection();
            _canal = _conexao.CreateModel();

            _canal.QueueDeclare(queue: _queueName, durable: false, exclusive: false, autoDelete: false, arguments: null);
        }

        public void EnqueueMessage(string message)
        {
            // Publica uma mensagem na fila do RabbitMQ
            var body = Encoding.UTF8.GetBytes(message);
            _canal.BasicPublish(exchange: "", routingKey: _queueName, basicProperties: null, body: body);
        }

        public void Dispose()
        {
            // Fecha a conexão com o RabbitMQ
            _canal.Close();
            _conexao.Close();
        }
    }
}
