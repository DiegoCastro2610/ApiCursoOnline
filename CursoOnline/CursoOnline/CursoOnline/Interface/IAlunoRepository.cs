using CursoOnline.Domains;

namespace CursoOnline.Interface
{
    public interface IAlunoRepository
    {
        List<ALUNO> Listar();

        ALUNO? ObterPorEmail(string email);

        bool EmailExiste(string email);

        void Adicionar(ALUNO aluno);

        void Atualizar(ALUNO aluno);

        void Remover(string email);
    }
}
