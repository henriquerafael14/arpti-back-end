using FlaUI.Core;
using FlaUI.Core.AutomationElements;
using FlaUI.Core.Input;
using FlaUI.UIA3;
using System;
using System.Diagnostics;
using System.Linq;
using System.Threading;

namespace Arpti.Domain.Robo
{
    public class RoboInstaladorService
    {
        private Application _app;
        private UIA3Automation _automation;

        public RoboInstaladorService(Application app, UIA3Automation automation)
        {
            _app = app;
            _automation = automation;
        }

        public void FecharAplicativo() => _app.Close();

        public void InstalarWinRAR()
        {
            var telaDeInstalacao = _app.GetMainWindow(_automation);
            if (telaDeInstalacao == null)
                FecharAplicativo();

            var botaoInstalar = telaDeInstalacao.FindFirstDescendant(x => x.ByText("Instalar")).AsButton();
            if (botaoInstalar == null)
                throw new Exception("O botão de Instalar não foi encontrado!");

            Mouse.MoveTo(botaoInstalar.GetClickablePoint());
            Mouse.LeftClick();

            Thread.Sleep(2000);
            Application appConfirmacao = ObterNovoProcesso("Configurações do WinRAR");

            var telaDeConfirmacao = appConfirmacao.GetMainWindow(_automation);
            var botaoOk = telaDeConfirmacao.FindFirstDescendant(x => x.ByText("OK")).AsButton();
            if (botaoOk == null)
                throw new Exception("O botão de OK não foi encontrado!");

            Mouse.MoveTo(botaoOk.GetClickablePoint());
            Mouse.LeftClick();

            Thread.Sleep(2000);
            Application appConcluido = ObterNovoProcesso("Instalação do WinRAR");

            var telaConcluido = appConcluido.GetMainWindow(_automation);
            var botaoConcluido = telaConcluido.FindFirstDescendant(x => x.ByText("Concluído")).AsButton();
            if (botaoConcluido == null)
                throw new Exception("O botão de OK não foi encontrado!");

            Mouse.MoveTo(botaoConcluido.GetClickablePoint());
            Mouse.LeftClick();
        }

        public void InstalarOperaGX()
        {
            // Obtém a janela de confirmação de instalação do WinRAR
            var telaDeInstalacao = _app.GetMainWindow(_automation);
            if (telaDeInstalacao == null)
                FecharAplicativo();

            var botaoInstalar = telaDeInstalacao.FindFirstDescendant(telaDeInstalacao => telaDeInstalacao.ByText("Aceitar e instalar")).AsButton();
            if (botaoInstalar == null)
                throw new Exception("O botão de Aceitar termos não foi encontrado!");

            Mouse.MoveTo(botaoInstalar.GetClickablePoint());
            Mouse.LeftClick();

            Thread.Sleep(2000);
            var telaDeAceite = _app.GetMainWindow(_automation);
            if (telaDeAceite == null)
                FecharAplicativo();
            var botaoAceitar = telaDeAceite.FindFirstDescendant(telaDeAceite => telaDeAceite.ByText("Aceitar")).AsButton();
            if (botaoAceitar == null)
                throw new Exception("O botão de Aceitar instalação não foi encontrado!");

            Mouse.MoveTo(botaoAceitar.GetClickablePoint());
            Mouse.LeftClick();
        }

        private static Application ObterNovoProcesso(string nomeProcesso)
        {
            var processos = Process.GetProcesses().ToList();
            var novoProcesso = processos.Where(p => p.MainWindowTitle == nomeProcesso).First();
            if (novoProcesso == null)
                throw new Exception("Ocorreu um erro ao finalizar instalação do WinRAR!");

            var app = Application.Attach(novoProcesso);
            return app;
        }
    }
}
