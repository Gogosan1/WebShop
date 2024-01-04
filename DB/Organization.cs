using System;
using System.Collections.Generic;

namespace WebShop.DB;

public partial class Organization
{
    public long Id { get; set; }

    public string? Name { get; set; }

    public string? LegalAddress { get; set; }

    public virtual ICollection<StructuralSubdivision> StructuralSubdivisions { get; set; } = new List<StructuralSubdivision>();

    public virtual ICollection<User> Users { get; set; } = new List<User>();
}
