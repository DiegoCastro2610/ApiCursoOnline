using CursoOnline.Domains;

namespace CursoOnline.DTOs.MatriculaDto
{
    public class CriarMatriculaDto
    {
        public CURSO? FK_CursoNome { get; set; }

        public ALUNO? FK_AlunoNome { get; set; }
    }
}
