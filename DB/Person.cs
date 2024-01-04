using System;
using System.Collections.Generic;

namespace WebShop.DB;

public partial class Person
{
    public long Id { get; set; }

    public long? IdStructuralSubdivision { get; set; }

    public long? PassportSeries { get; set; }

    public long? PassportNumber { get; set; }

    public long? Snils { get; set; }

    public string? Inn { get; set; }

    public string? Address { get; set; }

    public string? Sex { get; set; }

    public long? Age { get; set; }

    public string Name { get; set; } = null!;

    public string Surname { get; set; } = null!;

    public string? FatherName { get; set; }

    public string? TelephoneNumber { get; set; }

    public virtual ICollection<Check> Checks { get; set; } = new List<Check>();

    public virtual StructuralSubdivision? IdStructuralSubdivisionNavigation { get; set; }

    public virtual ICollection<User> Users { get; set; } = new List<User>();
}
