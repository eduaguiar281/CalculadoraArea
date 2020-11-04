using Alunos.Domain.Alunos;
using Bogus;
using Bogus.DataSets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
            return GerarAlunos(1, true).FirstOrDefault();
        }

        public IEnumerable<Aluno> ObterColecaoDeAlunos()
        {
            var alunos = new List<Aluno>();

            alunos.AddRange(GerarAlunos(50, true).ToList());
            alunos.AddRange(GerarAlunos(50, false).ToList());

            return alunos;
        }

        public IEnumerable<Aluno> GerarAlunos(int quantidade, bool ativo)
        {
            var genero = new Faker().PickRandom<Name.Gender>();

            var random = new Random();

            //var email = new Faker().Internet.Email("eduardo","aguiar","gmail");
            //var alunofaker = new Faker<Aluno>();
            //alunofaker.RuleFor(c => c.Nome, (f, c) => f.Name.FirstName());

            var alunos = new Faker<Aluno>("pt_BR")
                .CustomInstantiator(f => new Aluno(
                    Guid.NewGuid(),
                    f.Name.FirstName(genero),
                    f.Name.LastName(genero),
                    null,
                    f.Date.Past(25, DateTime.Now.AddYears(-19)),
                    DateTime.Now,
                    "",
                    $"{random.Next(1, 999999):000000}",
                    ativo))
                .RuleFor(c => c.Email, (f, c) =>
                      f.Internet.Email(c.Nome.ToLower(), c.SobreNome.ToLower()));

            return alunos.Generate(quantidade);
        }


        public Aluno GerarAlunoInvalido()
        {
            var genero = new Faker().PickRandom<Name.Gender>();

            var random = new Random();

            var aluno = new Faker<Aluno>("pt_BR")
                .CustomInstantiator(f => new Aluno(
                    Guid.NewGuid(),
                    f.Name.FirstName(genero),
                    f.Name.LastName(genero),
                    null,
                    f.Date.Past(4, DateTime.Now.AddYears(-8)),
                    DateTime.Now,
                    "",
                    $"{random.Next(1,999999):000000}",
                    false));
            return aluno;
        }


        public void Dispose()
        {
        }
    }
}
