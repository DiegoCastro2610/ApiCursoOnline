using CursoOnline.Domains;
using CursoOnline.DTOs.AlunoDto;
using CursoOnline.Interface;
using CursoOnline.Repository;
using Microsoft.EntityFrameworkCore;
using static CursoOnline.Exceptions.DomainExcepition;

namespace CursoOnline.Applications.Service
{
    public class AlunoService
    {
        private readonly IAlunoRepository _repository;

        public AlunoService(IAlunoRepository repository)
        {
            _repository = repository; 
        }

        private static LerAlunoDto LerDto(ALUNO aluno)
        {
            LerAlunoDto LerAluno = new LerAlunoDto
            {
                Email = aluno.Email,
                Nome = aluno.Nome
            };

            return LerAluno;
        }

        public List<LerAlunoDto> Listar()
        {
            List<ALUNO> AlunoDb = _repository.Listar();

            List<LerAlunoDto> ListarAlunoDto = AlunoDb.Select(A => LerDto(A)).ToList();

            return ListarAlunoDto;
        }
      
        private static void ValidarEmail(string email)
        {
            if (string.IsNullOrEmpty(email) || !email.Contains("@"))
            {
                throw new DomainException("Email invalido");
            }
        }

        public LerAlunoDto ObterPorEmail(string email)
        {
            ALUNO? alunoDb = _repository.ObterPorEmail(email);

            if(alunoDb == null)
            {
                throw new DomainException("Não Existe esse email");
            }

            return LerDto(alunoDb);
        }

        public LerAlunoDto Adicionar(CriarAlunoDto alunoDto)
        {
            ValidarEmail(alunoDto.Email);

            if(_repository.EmailExiste(alunoDto.Email))
            {
                throw new DomainException("Esse email ja existe");
            }

            ALUNO aluno = new ALUNO
            {
                Nome = alunoDto.Nome,
                Email = alunoDto.Email,
            };

            _repository.Adicionar(aluno);

            return LerDto(aluno);
        }

        public LerAlunoDto Atualizar(string email, CriarAlunoDto alunoDto)
        {
            ValidarEmail(alunoDto.Email);

            ALUNO? alunoDb = _repository.ObterPorEmail(email);

            if (alunoDb == null)
            {
                throw new DomainException("Não existe esse aluno");
            }

            alunoDb.Nome = alunoDto.Nome;
            alunoDb.Email = alunoDb.Email;

            _repository.Atualizar(alunoDb);

            return LerDto(alunoDb);
        }

        public void Remover(string email)
        {
            ALUNO? alunoDb = _repository.ObterPorEmail(email);

            if(alunoDb == null)
            {
                throw new DomainException("Não existe esse aluno");
            }

            _repository.Remover(email);
        }


    }
}
