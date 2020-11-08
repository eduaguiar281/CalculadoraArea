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
        private readonly DadosAlunosAutoMockFixture _dadosAlunoAutoMockFixture;
        private readonly AlunoService _alunoService;

        public AlunoServiceTesteAutoMockExemplo02(DadosAlunosAutoMockFixture dadosAlunosAutoMockFixture)
        {
            _dadosAlunoAutoMockFixture = dadosAlunosAutoMockFixture;
            _alunoService = _dadosAlunoAutoMockFixture.ObterAlunoService();
        }

        [Fact(DisplayName = "Adicionar Aluno com Sucesso")]
        [Trait("Tipo", "Exemplo 02- Aluno Service AutoMock Testes")]
        public void AlunoService_AdicionarNovo_DeveAdicionarComSucesso()
        {
            //Arrange
            var aluno = _dadosAlunoAutoMockFixture.GerarAlunoValido();

            //Act
            _alunoService.Adicionar(aluno);

            //Assert
            _dadosAlunoAutoMockFixture.Mocker.GetMock<IAlunoRepository>().Verify(r => r.Adicionar(aluno), Times.Once);
            _dadosAlunoAutoMockFixture.Mocker.GetMock<IMediator>().Verify(m => m.Publish(It.IsAny<INotification>(), CancellationToken.None), Times.Once);
        }

        [Fact(DisplayName = "Adicionar Aluno com Falha")]
        [Trait("Tipo", "Exemplo 02- Aluno Service AutoMock Testes")]
        public void AlunoService_AdicionarNovo_DeveFalharAlunoInvalido()
        {
            // Arrange
            var aluno = _dadosAlunoAutoMockFixture.GerarAlunoInvalido();

            // Act
            _alunoService.Adicionar(aluno);

            // Assert
            _dadosAlunoAutoMockFixture.Mocker.GetMock<IAlunoRepository>().Verify(r => r.Adicionar(aluno), Times.Never);
            _dadosAlunoAutoMockFixture.Mocker.GetMock<IMediator>().Verify(m => m.Publish(It.IsAny<INotification>(), CancellationToken.None), Times.Never);

        }

        [Fact(DisplayName = "Obter Alunos com Ativos")]
        [Trait("Tipo", "Exemplo 02- Aluno Service AutoMock Testes")]
        private void AlunoService_ObterAlunosAtivos_DeveRetornar()
        {
            // Arrange
            _dadosAlunoAutoMockFixture.Mocker.GetMock<IAlunoRepository>().Setup(r => r.ObterTodos())
                .Returns(_dadosAlunoAutoMockFixture.ObterColecaoDeAlunos());

            // Act
            var alunos = _alunoService.ObterTodosAtivos();


            // Assert 
            _dadosAlunoAutoMockFixture.Mocker.GetMock<IAlunoRepository>().Verify(r => r.ObterTodos(), Times.Once);
            Assert.True(alunos.Any());
            Assert.False(alunos.Count(c => !c.Ativo) > 0);

        }

    }
}
