using System;
using System.Collections.Generic;

namespace WebShop.DB;

public partial class Request
{
    public long Id { get; set; }

    public long? IdStructuralSubdivision { get; set; }

    public string? Date { get; set; }

    public string? Time { get; set; }

    public virtual StructuralSubdivision? IdStructuralSubdivisionNavigation { get; set; }

    public virtual ICollection<PurchaseRequest> PurchaseRequests { get; set; } = new List<PurchaseRequest>();

    public virtual ICollection<RelocationRequest> RelocationRequests { get; set; } = new List<RelocationRequest>();
}
