using System;
using System.Collections.Generic;

namespace CursoOnline.Domains;

public partial class CURSO
{
    public int CursoID { get; set; }

    public string? Nome { get; set; }

    public int? CargaHoraria { get; set; }

    public bool? StatusCurso { get; set; }

    public int? FK_InstrutorID { get; set; }

    public virtual INSTRUTOR? FK_Instrutor { get; set; }

    public virtual ICollection<MATRICULA> MATRICULA { get; set; } = new List<MATRICULA>();
}
