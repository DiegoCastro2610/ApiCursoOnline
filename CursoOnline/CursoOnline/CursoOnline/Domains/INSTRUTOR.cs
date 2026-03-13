using System;
using System.Collections.Generic;

namespace CursoOnline.Domains;

public partial class INSTRUTOR
{
    public int InstrutorID { get; set; }

    public string? Nome { get; set; }

    public string? AreaDeEspecializacao { get; set; }

    public virtual ICollection<CURSO> CURSO { get; set; } = new List<CURSO>();
}
