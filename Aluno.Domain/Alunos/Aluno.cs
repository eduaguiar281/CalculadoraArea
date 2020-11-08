using Alunos.Domain.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace Alunos.Domain.Alunos
{
    public class Aluno: BaseEntity
    {

        public Aluno(Guid id, string nome, string sobreNome, 
            List<string> responsaveis, DateTime dataNascimento, 
            DateTime dataCadastro, string email, string matricula, 
            bool ativo)
        {
            Id = id == Guid.Empty ? Guid.NewGuid() : id;
            Nome = nome;
            SobreNome = sobreNome;
            Responsaveis = responsaveis ?? new List<string>();
            DataNascimento = dataNascimento;
            DataCadastro = dataCadastro;
            Email = email;
            Matricula = matricula;
            Ativo = ativo;
        }
        public string Nome { get; private set; }
        public string SobreNome { get; private set; }
        public List<string> Responsaveis { get; private set; }
        public DateTime DataNascimento { get; private set; }
        public DateTime DataCadastro { get; private set; }
        public string Email { get; private set; }
        public string Matricula { get; private set; }
        public bool Ativo { get; private set; }
        public string NomeCompleto()
        {
            return $"{Nome} {SobreNome}";
        }
        public bool EhMaiorDeIdade()
        {
            return DataNascimento > DateTime.Now.AddYears(-18) ;
        }

        public void Inativar()
        {
            Ativo = false;
        }

        public override bool EhValido()
        {
            ValidationResult = new AlunoValidacao().Validate(this);
            return ValidationResult.IsValid;
        }

    }
}
