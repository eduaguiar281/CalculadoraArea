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
            var mediatr = new Mock<IMediator>();

            var clienteService = new AlunoService(alunoRepo.Object, mediatr.Object);

            // Act
            clienteService.Adicionar(aluno);

            // Assert
               //Assert.True(aluno.EhValido());
            alunoRepo.Verify(r => r.Adicionar(aluno), Times.Once);
            mediatr.Verify(m => m.Publish(It.IsAny<INotification>(), CancellationToken.None), Times.Once);

        }

        [Fact(DisplayName = "Adicionar Aluno com Falha")]
        [Trait("Tipo", "Aluno Service Mock Testes")]
        public void AlunoService_AdicionarNovo_DeveFalharAlunoInvalido()
        {
            // Arrange
            var aluno = _alunoTestesMockFixture.GerarAlunoInvalido();
            var alunoRepo = new Mock<IAlunoRepository>();
            var mediatr = new Mock<IMediator>();

            var clienteService = new AlunoService(alunoRepo.Object, mediatr.Object);

            // Act
            clienteService.Adicionar(aluno);

            // Assert
                //Assert.False(aluno.EhValido());
            alunoRepo.Verify(r => r.Adicionar(aluno), Times.Never);
            mediatr.Verify(m => m.Publish(It.IsAny<INotification>(), CancellationToken.None), Times.Never);
        }


        [Fact(DisplayName = "Obter Alunos com Ativos")]
        [Trait("Tipo", "Aluno Service Mock Testes")]
        public void AlunoService_ObterAlunosAtivos_DeveRetornar()
        {
            // Arrange
            var alunoRepo = new Mock<IAlunoRepository>();
            var mediatr = new Mock<IMediator>();

            alunoRepo.Setup(c => c.ObterTodos())
                .Returns(_alunoTestesMockFixture.ObterColecaoDeAlunos());
            var alunoService = new AlunoService(alunoRepo.Object, mediatr.Object);

            // Act
            var clientes = alunoService.ObterTodosAtivos();

            // Assert 
            alunoRepo.Verify(r => r.ObterTodos(), Times.Once);
            Assert.True(clientes.Any());
            Assert.False(clientes.Count(c => !c.Ativo) > 0);
        }
    }
}
