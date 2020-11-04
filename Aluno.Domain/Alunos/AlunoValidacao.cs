using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Alunos.Domain.Alunos
{
    public class AlunoValidacao: AbstractValidator<Aluno>
    {
        public AlunoValidacao()
        {
            RuleFor(c => c.Nome)
                .NotEmpty().WithMessage("Por favor, certifique-se de ter inserido o nome")
                .Length(2, 150).WithMessage("O nome deve ter entre 2 e 150 caracteres");

            RuleFor(c => c.SobreNome)
                .NotEmpty().WithMessage("Por favor, certifique-se de ter inserido o sobrenome")
                .Length(2, 150).WithMessage("O Sobrenome deve ter entre 2 e 150 caracteres");

            RuleFor(a => a.DataNascimento)
                .NotEmpty().WithMessage("Data de Nascimento é obrigatório");
            
            RuleFor(c => c)
                .Must(SemResponsavel)
                .WithMessage("O aluno menor de idade deve ter no mínimo 1 responsável!");

            RuleFor(c => c.Email)
                .NotEmpty()
                .EmailAddress();

            RuleFor(c => c.Id)
                .NotEqual(Guid.Empty);
        }
        public static bool SemResponsavel(Aluno aluno)
        {
            return !aluno.EhMaiorDeIdade() && aluno.Responsaveis.Count == 0;
        }

    }
}
