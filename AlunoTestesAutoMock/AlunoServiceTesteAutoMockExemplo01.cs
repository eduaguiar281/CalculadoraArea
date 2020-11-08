using Alunos.Domain.Alunos;
using MediatR;
using Moq;
using Moq.AutoMock;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using Xunit;

namespace Alunos.Testes.AutoMock
{

    [Collection(nameof(DadosAlunosAutoMockCollection))]
    public class AlunoServiceTesteAutoMockExemplo01
    {
        private readonly DadosAlunosAutoMockFixture _dadosAlunoAutoMockFixture;

        public AlunoServiceTesteAutoMockExemplo01(DadosAlunosAutoMockFixture dadosAlunosAutoMockFixture)
        {
            _dadosAlunoAutoMockFixture = dadosAlunosAutoMockFixture;
        }

        [Fact(DisplayName = "Adicionar Aluno com Sucesso")]
        [Trait("Tipo", "Exemplo 01- Aluno Service AutoMock Testes")]
        public void AlunoService_AdicionarNovo_DeveAdicionarComSucesso()
        {
            // Arrange
            var aluno = _dadosAlunoAutoMockFixture.GerarAlunoValido();
            var mocker = new AutoMocker();
            var alunoService = mocker.CreateInstance<AlunoService>();

            // Act
            alunoService.Adicionar(aluno);

            // Assert
            mocker.GetMock<IAlunoRepository>().Verify(r => r.Adicionar(aluno), Times.Once);
            mocker.GetMock<IMediator>().Verify(m => m.Publish(It.IsAny<INotification>(), CancellationToken.None), Times.Once);
        }

        [Fact(DisplayName = "Adicionar Aluno com Falha")]
        [Trait("Tipo", "Exemplo 01- Aluno Service AutoMock Testes")]
        public void AlunoService_AdicionarNovo_DeveFalharAlunoInvalido()
        {
            // Arrange
            var aluno = _dadosAlunoAutoMockFixture.GerarAlunoInvalido();
            var mocker = new AutoMocker();
            var alunoService = mocker.CreateInstance<AlunoService>();

            // Act
            alunoService.Adicionar(aluno);

            // Assert
            mocker.GetMock<IAlunoRepository>().Verify(r => r.Adicionar(aluno), Times.Never);
            mocker.GetMock<IMediator>().Verify(m => m.Publish(It.IsAny<INotification>(), CancellationToken.None), Times.Never);
        }

        [Fact(DisplayName = "Obter Alunos com Ativos")]
        [Trait("Tipo", "Exemplo 01- Aluno Service AutoMock Testes")]
        public void AlunoService_ObterAlunosAtivos_DeveRetornar()
        {
            // Arrange
            var aluno = _dadosAlunoAutoMockFixture.GerarAlunoInvalido();
            var mocker = new AutoMocker();
            var alunoService = mocker.CreateInstance<AlunoService>();

            mocker.GetMock<IAlunoRepository>().Setup(a => a.ObterTodos())
                .Returns(_dadosAlunoAutoMockFixture.ObterColecaoDeAlunos());

            // Act
            var alunos = alunoService.ObterTodosAtivos();

            // Assert 
            mocker.GetMock<IAlunoRepository>().Verify(r => r.ObterTodos(), Times.Once);
            Assert.True(alunos.Any());
            Assert.False(alunos.Count(a => !a.Ativo) > 0);
        }

    }
}
