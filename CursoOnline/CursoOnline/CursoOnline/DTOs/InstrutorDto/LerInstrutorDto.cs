using CursoOnline.Domains;

namespace CursoOnline.DTOs.InstrutorDto
{
    public class LerInstrutorDto
    {
        public string? Nome { get; set; }

        public string? AreaDeEspecializacao { get; set; }

        public virtual ICollection<CURSO> CURSO { get; set; } = new List<CURSO>();
    }
}
