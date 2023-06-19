using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Arpti.Robo.Executor.Result;
using FlaUI.Core;
using FlaUI.UIA3;
using Arpti.Domain.Robo;
using System.IO;

namespace Arpti.Robo.Executor
{
    public class RoboExecutorService
    {
        private readonly ILogger<RoboExecutorService> _logger;

        public RoboExecutorService(ILogger<RoboExecutorService> logger)
        {
            _logger = logger;
        }

        public async Task<ProcessoInstalacaoResult> StartInstallationProcess(string programName)
        {
            var result = new ProcessoInstalacaoResult();
            string downloadsFolderPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "Downloads");

            try
            {
                // Inicie o processo de instalação do programa especificado
                var app = Application.AttachOrLaunch(new ProcessStartInfo($"{downloadsFolderPath}\\winrar-x64-622br.exe"));

                using (var automation = new UIA3Automation())
                {
                    var roboInstaladorService = new RoboInstaladorService(app, automation);
                    roboInstaladorService.InstalarWinRAR();
                }

                result.Success = true;
                result.Message = "Processo de instalação concluído com sucesso.";
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Ocorreu um erro durante o processo de instalação: " + ex.Message;
                _logger.LogError(ex, result.Message);
            }

            return result;
        }
    }
}
