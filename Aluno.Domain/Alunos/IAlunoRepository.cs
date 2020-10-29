using Aluno.Domain.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aluno.Domain.Alunos
{
    public interface IAlunoRepository: IRepository<Aluno>
    {
        Aluno ObterPorEmail(string email);

        Aluno ObterPorMatricula(string matricula);
    }
}
