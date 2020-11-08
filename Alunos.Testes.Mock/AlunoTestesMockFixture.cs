using Alunos.Domain.Alunos;
using Bogus;
using Bogus.DataSets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace Alunos.Testes.Mock
{

    [CollectionDefinition(nameof(AlunoMockCollection))]
    public class AlunoMockCollection : ICollectionFixture<AlunoTestesMockFixture>
    { }
    public class AlunoTestesMockFixture : IDisposable
    {

        public IEnumerable<Aluno> ObterColecaoDeAlunos()
        {
            var alunos = new List<Aluno>();

            alunos.AddRange(GerarAlunos(50, true).ToList());
            alunos.AddRange(GerarAlunos(50, false).ToList());

            return alunos;

        }

        private IEnumerable<Aluno> GerarAlunos(int quantidade, bool ativo)
        {
            var genero = new Faker().PickRandom<Name.Gender>();

            var alunos = new Faker<Aluno>("pt_BR")
                .CustomInstantiator(f => new Aluno(
                    Guid.NewGuid(),
                    f.Name.FirstName(genero),
                    f.Name.LastName(genero),
                    null,
                    f.Date.Past(25, DateTime.Now.AddYears(-19)),
                    DateTime.Now,
                    "",
                    "",
                    ativo))
                .RuleFor(c => c.Email, (f, c) =>
                      f.Internet.Email(c.Nome.ToLower(), c.SobreNome.ToLower()))
                .RuleFor(c => c.Matricula, (f, c) =>
                      f.Random.Number(99999).ToString());

            return alunos.Generate(quantidade);

        }

        public Aluno GerarAlunoValido()
        {

            return GerarAlunos(1, true).FirstOrDefault();
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
