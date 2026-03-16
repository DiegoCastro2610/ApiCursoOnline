using CursoOnline.Contexts;
using CursoOnline.Domains;
using CursoOnline.Interface;

namespace CursoOnline.Repository
{
    public class InstrutorRepository : IInstrutorRepository
    {
        private readonly CursoOnlineContext _context;

        public InstrutorRepository(CursoOnlineContext context)
        {
            _context = context;
        }

        public List<INSTRUTOR> Listar()
        {
            return _context.INSTRUTOR.ToList();
        }

        public INSTRUTOR? ObterPorAreaDeEspecialicacao(string AreaDeEspecializacao)
        {
            return _context.INSTRUTOR.FirstOrDefault(I => I.AreaDeEspecializacao == AreaDeEspecializacao);
        }

        public bool EspecialicacaoExiste(string AreaDeEspecializacao)
        {
            var Existe = _context.INSTRUTOR.FirstOrDefault(I => I.AreaDeEspecializacao == AreaDeEspecializacao);

            if (Existe == null)
            {
                return false;
            }
            return true;
        }

        public void Adicionar(INSTRUTOR Instrutor)
        {
           _context.Add(Instrutor);
           _context.SaveChanges();
        }

        public void Atualizar(INSTRUTOR Instrutor)
        {
            INSTRUTOR? instrutordb = _context.INSTRUTOR.FirstOrDefault(I => I.InstrutorID == Instrutor.InstrutorID);

            if(instrutordb == null)
            {
                return;
            }
            instrutordb.Nome = Instrutor.Nome;
            instrutordb.AreaDeEspecializacao = Instrutor.AreaDeEspecializacao;
            _context.SaveChanges();
        }

        public void Remover(string Nome)
        {
            INSTRUTOR? instrutordb = _context.INSTRUTOR.FirstOrDefault(I => I.Nome == Nome);

            if(instrutordb == null)
            {
                return;
            }

            _context.INSTRUTOR.Remove(instrutordb);
            _context.SaveChanges();
        }
    }
}
