using System;
using System.Collections.Generic;

namespace WebShop.DB;

public partial class TypesOfStructuralSubdivision
{
    public long Id { get; set; }

    public string Type { get; set; } = null!;

    public virtual ICollection<StructuralSubdivision> StructuralSubdivisions { get; set; } = new List<StructuralSubdivision>();
}
