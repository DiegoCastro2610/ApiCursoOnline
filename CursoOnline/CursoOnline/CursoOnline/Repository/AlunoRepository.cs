using CursoOnline.Contexts;
using CursoOnline.Domains;
using CursoOnline.Interface;
using System.Security.Cryptography;

namespace CursoOnline.Repository
{
    public class AlunoRepository : IAlunoRepository
    {
        private readonly CursoOnlineContext _context;

        public AlunoRepository(CursoOnlineContext context)
        {
            _context = context;
        }

        public List<ALUNO> Listar()
        {
            return _context.ALUNO.ToList();
        }

        public ALUNO? ObterPorEmail(string email)
        {
            return _context.ALUNO.FirstOrDefault(A => A.Email == email);
        }

        public bool EmailExiste(string email)
        {
            var Aluno = _context.ALUNO.FirstOrDefault(A => A.Email == email);

            if(Aluno == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public void Adicionar(ALUNO aluno)
        {
            _context.Add(aluno);
            _context.SaveChanges();
        }

        public void Atualizar(ALUNO aluno)
        {
            ALUNO? alunoDb = _context.ALUNO.FirstOrDefault(A => A.AlunoID == aluno.AlunoID);

            if(alunoDb == null)
            {
                return;
            }

            alunoDb.Nome = aluno.Nome;
            alunoDb.Email = aluno.Email;

            _context.SaveChanges();
        }

        public void Remover(string email)
        {
            ALUNO? aluno = _context.ALUNO.FirstOrDefault(A => A.Email == email);

            if(aluno == null)
            {
                return;
            }

            _context.ALUNO.Remove(aluno);
            _context.SaveChanges();

        }

    }
}
