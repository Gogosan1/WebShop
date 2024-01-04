using System;
using System.Collections.Generic;

namespace WebShop.DB;

public partial class Unit
{
    public long Id { get; set; }

    public string? Name { get; set; }

    public virtual ICollection<Good> Goods { get; set; } = new List<Good>();
}
