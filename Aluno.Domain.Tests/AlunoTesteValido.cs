using Alunos.Domain.Alunos;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Alunos.Domain.Tests
{
    [Collection(nameof(AlunoCollection))]
    public class AlunoTesteValido
    {
        private readonly AlunoTestsFixtures _alunoTestsFixtures;
        public AlunoTesteValido(AlunoTestsFixtures alunoTestsFixtures)
        {
            _alunoTestsFixtures = alunoTestsFixtures;
        }

        [Fact(DisplayName = "Novo Aluno Válido")]
        [Trait("Tipo", "Aluno Fixture Testes")]
        public void Aluno_NovoAluno_DeveEstarValido()
        {
            // Arrange
            var aluno = _alunoTestsFixtures.GerarAlunoValido();

            // Act
            var result = aluno.EhValido();

            // Assert 
            Assert.True(result);
            Assert.Equal(0, aluno.ValidationResult.Errors.Count);
        }

    }
}
