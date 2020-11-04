using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Alunos.Domain.Tests
{
    [Collection(nameof(AlunoCollection))]
    public class AlunoTesteValido
    {
        private readonly AlunoTestsFixtures _alunoTestsFixture;

        public AlunoTesteValido(AlunoTestsFixtures alunoTestsFixtures)
        {
            _alunoTestsFixture = alunoTestsFixtures;
        }

        [Fact(DisplayName = "Novo Aluno Válido")]
        [Trait("Tipo", "Aluno Fixture Testes")]
        public void Cliente_NovoCliente_DeveEstarValido()
        {
            // Arrange
            var cliente = _alunoTestsFixture.GerarAlunoValido();

            // Act
            var result = cliente.EhValido();

            // Assert 
            Assert.True(result);
            Assert.Equal(0, cliente.ValidationResult.Errors.Count);
        }

    }
}
