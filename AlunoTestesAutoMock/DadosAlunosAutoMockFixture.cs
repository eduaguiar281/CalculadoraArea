using Alunos.Domain.Alunos;
using Bogus;
using Bogus.DataSets;
using Moq.AutoMock;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Alunos.Testes.AutoMock
{
    [CollectionDefinition(nameof(DadosAlunosAutoMockCollection))]
    public class DadosAlunosAutoMockCollection : ICollectionFixture<DadosAlunosAutoMockFixture>
    { }

    public class DadosAlunosAutoMockFixture : IDisposable
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
                    "",
                    false))
                .RuleFor(c => c.Matricula, (f, c) =>
                      f.Random.Number(99999).ToString());
            return aluno;
        }


        public void Dispose()
        {
        }

    }
}
