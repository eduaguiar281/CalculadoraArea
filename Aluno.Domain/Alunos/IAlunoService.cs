using System;
using System.Collections.Generic;
using System.Text;

namespace Alunos.Domain.Alunos
{
    public interface IAlunoService: IDisposable
    {
        IEnumerable<Aluno> ObterTodosAtivos();
        void Adicionar(Aluno aluno);
        void Atualizar(Aluno aluno);
        void Remover(Aluno aluno);
        void Inativar(Aluno aluno);

    }
}
