using CursoOnline.Domains;

namespace CursoOnline.DTOs.MatriculaDto
{
    public class LerMatriculaDto
    {
        public bool? StatusMatricula { get; set; }

        public CURSO? FK_CursoNome { get; set; }

        public ALUNO? FK_AlunoNome { get; set; }
    }
}
