using System;
using System.Collections.Generic;

namespace CursoOnline.Domains;

public partial class ALUNO
{
    public int AlunoID { get; set; }

    public string? Nome { get; set; }

    public string? Email { get; set; }

    public virtual ICollection<MATRICULA> MATRICULA { get; set; } = new List<MATRICULA>();
}
