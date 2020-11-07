using Alunos.Domain.Alunos;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Alunos.Domain.Tests
{
    [Collection(nameof(AlunoCollection))]
    public class AlunoTesteInvalido
    {
        private readonly AlunoTestsFixtures _alunoTestsFixtures;

        public AlunoTesteInvalido(AlunoTestsFixtures alunoTestsFixtures)
        {
            _alunoTestsFixtures = alunoTestsFixtures;
        }

        [Fact(DisplayName = "Aluno Email Inválido")]
        [Trait("Tipo", "Aluno Fixture Testes")]
        public void Aluno_NovoAluno_EmailEhInvalido()
        {
            // Arrange
            var aluno = _alunoTestsFixtures.GerarAlunoInvalido();

            // Act
            aluno.EhValido();


            // Assert
            Assert.Contains("Email informado não é válido!",
                aluno.ValidationResult.ToString());

        }

        [Fact(DisplayName = "Aluno Sem Responsavel")]
        [Trait("Tipo", "Aluno Fixture Testes")]
        public void Aluno_NovoAluno_AlunoSemResponsavelEhInvalido()
        {
            //Arrange
            var aluno = _alunoTestsFixtures.GerarAlunoInvalido();

            // Act
            aluno.EhValido();


            // Assert
            Assert.Contains("O aluno menor de idade deve ter no mínimo 1 responsável!",
                aluno.ValidationResult.ToString());
        }
    }
}
