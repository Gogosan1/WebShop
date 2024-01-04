using System;
using System.Collections.Generic;

namespace WebShop.DB;

public partial class RelocationRequest
{
    public long Id { get; set; }

    public long IdStructuralSubdivision { get; set; }

    public long IdRequest { get; set; }

    public virtual Request IdRequestNavigation { get; set; } = null!;

    public virtual StructuralSubdivision IdStructuralSubdivisionNavigation { get; set; } = null!;
}
