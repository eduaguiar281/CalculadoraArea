using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Aluno.Domain.Alunos
{
    public class AlunoService: IAlunoService
    {
        private readonly IAlunoRepository _alunoRepository;
        private readonly IMediator _mediator;

        public AlunoService(IAlunoRepository alunoRepository,
                              IMediator mediator)
        {
            _alunoRepository = alunoRepository;
            _mediator = mediator;
        }

        public IEnumerable<Aluno> ObterTodosAtivos()
        {
            return _alunoRepository.ObterTodos().Where(c => c.Ativo);
        }

        public void Adicionar(Aluno aluno)
        {
            if (!aluno.EhValido())
                return;

            _alunoRepository.Adicionar(aluno);
            _mediator.Publish(new AlunoEmailNotification("admin@me.com", aluno.Email, "Olá", "Bem vindo!"));
        }

        public void Atualizar(Aluno aluno)
        {
            if (!aluno.EhValido())
                return;

            _alunoRepository.Atualizar(aluno);
            _mediator.Publish(new AlunoEmailNotification("admin@me.com", aluno.Email, "Mudanças", "Dê uma olhada!"));
        }

        public void Inativar(Aluno aluno)
        {
            if (!aluno.EhValido())
                return;

            aluno.Inativar();
            _alunoRepository.Atualizar(aluno);
            _mediator.Publish(new AlunoEmailNotification("admin@me.com", aluno.Email, "Até breve", "Até mais tarde!"));
        }

        public void Remover(Aluno aluno)
        {
            _alunoRepository.Remover(aluno.Id);
            _mediator.Publish(new AlunoEmailNotification("admin@me.com", aluno.Email, "Adeus", "Tenha uma boa jornada!"));
        }

        public void Dispose()
        {
            _alunoRepository.Dispose();
        }

    }
}
