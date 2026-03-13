using System;
using System.Collections.Generic;

namespace CursoOnline.Domains;

public partial class MATRICULA
{
    public int MatriculaID { get; set; }

    public int? FK_CursoID { get; set; }

    public int? FK_AlunoID { get; set; }

    public bool? StatusMatricula { get; set; }

    public virtual ALUNO? FK_Aluno { get; set; }

    public virtual CURSO? FK_Curso { get; set; }
}
