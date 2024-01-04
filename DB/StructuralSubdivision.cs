using System;
using System.Collections.Generic;

namespace WebShop.DB;

public partial class StructuralSubdivision
{
    public long Id { get; set; }

    public long IdOrganization { get; set; }

    public string Address { get; set; } = null!;

    public string Name { get; set; } = null!;

    public long IdOfType { get; set; }

    public virtual ICollection<Assortment> Assortments { get; set; } = new List<Assortment>();

    public virtual ICollection<Check> Checks { get; set; } = new List<Check>();

    public virtual TypesOfStructuralSubdivision IdOfTypeNavigation { get; set; } = null!;

    public virtual Organization? IdOrganizationNavigation { get; set; }

    public virtual ICollection<Person> People { get; set; } = new List<Person>();

    public virtual ICollection<RelocationRequest> RelocationRequests { get; set; } = new List<RelocationRequest>();

    public virtual ICollection<Request> Requests { get; set; } = new List<Request>();
    
  /*  public StructuralSubdivision(long OrgId, string address, string name, long typeId)
    {
        IdOrganization = OrgId;
        Address = address;
        Name = name;
        IdOfType = typeId;
    }*/
}
