using Alunos.Domain.Alunos;
using MediatR;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using Xunit;

namespace Alunos.Testes.AutoMock
{
    [Collection(nameof(DadosAlunosAutoMockCollection))]
    public class AlunoServiceTesteAutoMockExemplo02
    {

        private readonly DadosAlunosAutoMockFixture _dadosAlunosAutoMockFixture;
        private readonly AlunoService _alunoService;

        public AlunoServiceTesteAutoMockExemplo02(DadosAlunosAutoMockFixture dadosAlunosAutoMockFixture)
        {
            _dadosAlunosAutoMockFixture = dadosAlunosAutoMockFixture;
            _alunoService = _dadosAlunosAutoMockFixture.ObterAlunoService();
        }

        [Fact(DisplayName = "Adicionar Aluno com Sucesso")]
        [Trait("Tipo", "Exemplo 02- Aluno Service AutoMock Testes")]
        public void AlunoService_AdicionarNovo_DeveAdicionarComSucesso()
        {
            // Arrange
            var aluno = _dadosAlunosAutoMockFixture.GerarAlunoValido();

            // Act
            _alunoService.Adicionar(aluno);

            // Assert
            _dadosAlunosAutoMockFixture.Mocker.GetMock<IAlunoRepository>().Verify(r => r.Adicionar(aluno), Times.Once);
            _dadosAlunosAutoMockFixture.Mocker.GetMock<IMediator>().Verify(m => m.Publish(It.IsAny<INotification>(), CancellationToken.None), Times.Once);

        }

        [Fact(DisplayName = "Adicionar Aluno com Falha")]
        [Trait("Tipo", "Exemplo 02- Aluno Service AutoMock Testes")]
        public void AlunoService_AdicionarNovo_DeveFalharAlunoInvalido()
        {
            // Arrange
            var aluno = _dadosAlunosAutoMockFixture.GerarAlunoInvalido();

            // Act
            _alunoService.Adicionar(aluno);

            // Assert
            _dadosAlunosAutoMockFixture.Mocker.GetMock<IAlunoRepository>().Verify(r => r.Adicionar(aluno), Times.Never);
            _dadosAlunosAutoMockFixture.Mocker.GetMock<IMediator>().Verify(m => m.Publish(It.IsAny<INotification>(), CancellationToken.None), Times.Never);

        }

        [Fact(DisplayName = "Obter Alunos com Ativos")]
        [Trait("Tipo", "Exemplo 02- Aluno Service AutoMock Testes")]
        private void AlunoService_ObterAlunosAtivos_DeveRetornar()
        {
            // Arrange
            _dadosAlunosAutoMockFixture.Mocker.GetMock<IAlunoRepository>().Setup(r => r.ObterTodos())
                .Returns(_dadosAlunosAutoMockFixture.ObterColecaoDeAlunos());

            // Act
            var alunos = _alunoService.ObterTodosAtivos();


            // Assert 
            _dadosAlunosAutoMockFixture.Mocker.GetMock<IAlunoRepository>().Verify(r => r.ObterTodos(), Times.Once);
            Assert.True(alunos.Any());
            Assert.False(alunos.Count(c => !c.Ativo) > 0);

        }

    }
}
