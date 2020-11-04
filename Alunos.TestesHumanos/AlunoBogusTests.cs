using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Alunos.TestesHumanos
{
    [Collection(nameof(AlunoBogusCollection))]
    public class AlunoBogusTests
    {
        private readonly AlunoTestesBogusFixture _alunoTestesBogusFixture;

        public AlunoBogusTests(AlunoTestesBogusFixture alunoTestesBogusFixture)
        {
            _alunoTestesBogusFixture = alunoTestesBogusFixture;
        }

        [Fact(DisplayName = "Novo Aluno Válido")]
        [Trait("Tipo", "Aluno Bogus Testes")]
        public void Aluno_NovoAluno_DeveEstarValido()
        {
            // Arrange
            var aluno = _alunoTestesBogusFixture.GerarAlunoValido();

            // Act
            var result = aluno.EhValido();

            // Assert 
            Assert.True(result);
            Assert.Equal(0, aluno.ValidationResult.Errors.Count);
        }

        [Fact(DisplayName = "Novo Aluno Inválido")]
        [Trait("Tipo", "Aluno Bogus Testes")]
        public void Aluno_NovoAluno_DeveEstarInvalido()
        {
            // Arrange
            var aluno = _alunoTestesBogusFixture.GerarAlunoInvalido();

            // Act
            var result = aluno.EhValido();

            // Assert 
            Assert.False(result);
            Assert.NotEqual(0, aluno.ValidationResult.Errors.Count);
        }

        [Fact(DisplayName = "Lista de Aluno Valido")]
        [Trait("Tipo", "Aluno Bogus Testes")]
        public void Aluno_Lista_DeveEstarValido()
        {
            // Arrange
            var alunos = _alunoTestesBogusFixture.ObterColecaoDeAlunos();

            // Act & Assert
            Assert.All(alunos, (a) => Assert.True(a.EhValido()));
        }

    }
}
