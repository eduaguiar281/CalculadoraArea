using Alunos.Domain.Alunos;
using Bogus;
using Bogus.DataSets;
using System;
using Xunit;

namespace Alunos.TestesHumanos
{
    [CollectionDefinition(nameof(AlunoBogusCollection))]
    public class AlunoBogusCollection : ICollectionFixture<AlunoTestesBogusFixture>
    { }


    public class AlunoTestesBogusFixture : IDisposable
    {

        public Aluno GerarAlunoValido()
        {
            var genero = new Faker().PickRandom<Name.Gender>();

            var aluno = new Faker<Aluno>("pt_BR")
                .CustomInstantiator(f => new Aluno(
                    Guid.NewGuid(),
                    f.Name.FirstName(genero),
                    f.Name.LastName(genero),
                    null,
                    f.Date.Past(25, DateTime.Now.AddYears(-19)),
                    DateTime.Now,
                    "",
                    f.IndexFaker.ToString(),
                    true))
                .RuleFor(c => c.Email, (f, c) =>
                      f.Internet.Email(c.Nome.ToLower(), c.SobreNome.ToLower()));
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
