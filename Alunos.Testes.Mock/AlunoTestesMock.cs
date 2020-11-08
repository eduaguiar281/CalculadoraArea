using Alunos.Domain.Alunos;
using MediatR;
using Moq;
using System.Linq;
using System.Threading;
using Xunit;

namespace Alunos.Testes.Mock
{
    [Collection(nameof(AlunoMockCollection))]
    public class AlunoTestesMock
    {
        public readonly AlunoTestesMockFixture _alunoTestesMockFixture;

        public AlunoTestesMock(AlunoTestesMockFixture alunoTestesMockFixture)
        {
            _alunoTestesMockFixture = alunoTestesMockFixture;
        }

        [Fact(DisplayName = "Adicionar Aluno com Sucesso")]
        [Trait("Tipo", "Aluno Service Mock Testes")]
        public void AlunoService_AdicionarNovo_DeveAdicionarComSucesso()
        {
            // Arrange
            var aluno = _alunoTestesMockFixture.GerarAlunoValido();
            var alunoRepo = new Mock<IAlunoRepository>();
            var mediator = new Mock<IMediator>();
            var alunoService = new AlunoService(alunoRepo.Object, mediator.Object);

            // Act
            alunoService.Adicionar(aluno);

            // Assert
            alunoRepo.Verify(r => r.Adicionar(aluno), Times.Once);
            mediator.Verify(m => m.Publish(It.IsAny<INotification>(), CancellationToken.None), Times.Once);

        }

        [Fact(DisplayName = "Adicionar Aluno com Falha")]
        [Trait("Tipo", "Aluno Service Mock Testes")]
        public void AlunoService_AdicionarNovo_DeveFalharAlunoInvalido()
        {
            // Arrange
            var aluno = _alunoTestesMockFixture.GerarAlunoInvalido();
            var alunoRepo = new Mock<IAlunoRepository>();
            var mediator = new Mock<IMediator>();
            var alunoService = new AlunoService(alunoRepo.Object, mediator.Object);

            // Act
            alunoService.Adicionar(aluno);

            // Assert
            alunoRepo.Verify(r => r.Adicionar(aluno), Times.Never);
            mediator.Verify(m => m.Publish(It.IsAny<INotification>(), CancellationToken.None), Times.Never);
        }


        [Fact(DisplayName = "Obter Alunos com Ativos")]
        [Trait("Tipo", "Aluno Service Mock Testes")]
        public void AlunoService_ObterAlunosAtivos_DeveRetornar()
        {
            // Arrange
            var alunoRepo = new Mock<IAlunoRepository>();
            var mediator = new Mock<IMediator>();
            alunoRepo.Setup(a => a.ObterTodos())
                .Returns(_alunoTestesMockFixture.ObterColecaoDeAlunos());
            
            var alunoService = new AlunoService(alunoRepo.Object, mediator.Object);

            // Act
            var alunos = alunoService.ObterTodosAtivos();

            // Assert 
            alunoRepo.Verify(r => r.ObterTodos(), Times.Once);
            Assert.True(alunos.Any());
            Assert.False(alunos.Count(a => !a.Ativo) > 0);
        }
    }
}
