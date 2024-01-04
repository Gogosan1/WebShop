using System;
using System.Collections.Generic;

namespace WebShop.DB;

public partial class Assortment
{
    public long Id { get; set; }

    public long IdStructuralSubdivision { get; set; }

    public virtual StructuralSubdivision? IdSturcturalSubdivisionNavigation { get; set; }
}
