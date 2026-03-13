using CursoOnline.Domains;

namespace CursoOnline.DTOs.MatriculaDto
{
    public class LerMatriculaDto
    {
        public bool? StatusMatricula { get; set; }

        public virtual ALUNO? FK_Aluno { get; set; }

        public virtual CURSO? FK_Curso { get; set; }
    }
}
