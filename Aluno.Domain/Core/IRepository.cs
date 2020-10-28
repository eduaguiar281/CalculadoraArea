using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Aluno.Domain.Core
{
    public interface IRepository<TEntity> : IDisposable where TEntity : BaseEntity
    {
        void Adicionar(TEntity obj);
        TEntity ObterPorId(Guid id);
        IEnumerable<TEntity> ObterTodos();
        void Atualizar(TEntity obj);
        void Remover(Guid id);
        IEnumerable<TEntity> Buscar(Expression<Func<TEntity, bool>> predicate);
        int Commit();
    }
}
