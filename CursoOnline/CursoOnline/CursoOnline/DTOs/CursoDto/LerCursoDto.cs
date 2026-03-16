using CursoOnline.Domains;

namespace CursoOnline.DTOs.CursoDto
{
    public class LerCursoDto
    {
        public string? Nome { get; set; }

        public int? CargaHoraria { get; set; }

        public bool? StatusCurso { get; set; }

        public INSTRUTOR? NomeInstrutor { get; set; }
    }
}
