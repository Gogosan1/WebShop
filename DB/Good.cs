using System;
using System.Collections.Generic;

namespace WebShop.DB;

public partial class Good
{
    public long Id { get; set; }

    public string Name { get; set; }

    public long IdUnit { get; set; }

    public virtual Unit IdUnitNavigation { get; set; }
}
