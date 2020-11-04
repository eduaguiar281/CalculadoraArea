using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Alunos.Domain.Tests
{
    [Collection(nameof(AlunoCollection))]
    public class AlunoTesteInvalido
    {
        private readonly AlunoTestsFixtures _alunoTestsFixture;

        public AlunoTesteInvalido(AlunoTestsFixtures alunoTestsFixtures)
        {
            _alunoTestsFixture = alunoTestsFixtures;
        }

        [Fact(DisplayName = "Novo Aluno Inválido")]
        [Trait("Tipo", "Aluno Fixture Testes")]
        public void Cliente_NovoCliente_DeveEstarInvalido()
        {
            // Arrange
            var cliente = _alunoTestsFixture.GerarAlunoInvalido();

            // Act
            var result = cliente.EhValido();

            // Assert 
            Assert.False(result);
            Assert.NotEqual(0, cliente.ValidationResult.Errors.Count);
        }

    }
}
