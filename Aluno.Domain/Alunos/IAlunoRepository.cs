using Alunos.Domain.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace Alunos.Domain.Alunos
{
    public interface IAlunoRepository: IRepository<Aluno>
    {
        Aluno ObterPorEmail(string email);

        Aluno ObterPorMatricula(string matricula);
    }
}
