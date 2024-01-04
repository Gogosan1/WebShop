using System;
using System.Collections.Generic;

namespace WebShop.DB;

public partial class Check
{
    public long Id { get; set; }

    public long? IdStructuralSubdivision { get; set; }

    public long? SerialNumber { get; set; }

    public string? Date { get; set; }

    public string? Time { get; set; }

    public long? IdPerson { get; set; }

    public long? Field7 { get; set; }

    public virtual Person? IdPersonNavigation { get; set; }

    public virtual StructuralSubdivision? IdStructuralSubdivisionNavigation { get; set; }
}
