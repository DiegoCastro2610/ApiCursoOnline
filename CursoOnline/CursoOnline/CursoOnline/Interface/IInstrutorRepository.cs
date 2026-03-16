using CursoOnline.Domains;

namespace CursoOnline.Interface
{
    public interface IInstrutorRepository
    {
        List<INSTRUTOR> Listar();

        INSTRUTOR? ObterPorAreaDeEspecialicacao(string AreaDeEspecializacao);

        bool EspecialicacaoExiste(string AreaDeEspecializacao);

        void Adicionar(INSTRUTOR Instrutor);

        void Atualizar(INSTRUTOR Instrutor);

        void Remover(string Nome);
    }
}
