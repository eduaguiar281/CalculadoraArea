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
        public void Aluno_NovoAluno_DeveEstarInvalido()
        {
            // Arrange
            var aluno = _alunoTestsFixture.GerarAlunoInvalido();

            // Act
            var result = aluno.EhValido();

            // Assert 
            Assert.False(result);
            Assert.NotEqual(0, aluno.ValidationResult.Errors.Count);
        }

    }
}
