using Alunos.Domain.Alunos;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Alunos.Domain.Tests
{
    [CollectionDefinition(nameof(AlunoCollection))]
    public class AlunoCollection : ICollectionFixture<AlunoTestsFixtures>
    {
        public AlunoCollection()
        {

        }

    }

    public class AlunoTestsFixtures : IDisposable
    {

        public AlunoTestsFixtures()
        {

        }

        public Aluno GerarAlunoValido()
        {
            var aluno = new Aluno
                (Guid.NewGuid(),
                "Eduardo",
                 "Rodrigues de Aguiar",
                 null,
                 new DateTime(1978, 03, 04),
                 DateTime.Now,
                 "eduaguiar281@hotmail.com",
                 "123456",
                 true);
            return aluno;
        }

        public Aluno GerarAlunoInvalido()
        {
            var aluno = new Aluno
                (Guid.NewGuid(),
                 "Maria",
                 "da Silva",
                 null,
                 DateTime.Now.AddYears(-7),
                 DateTime.Now,
                 "eduaguiar281",
                 "123416",
                 true);
            return aluno;
        }

        public void Dispose()
        {
        }
    }
}
