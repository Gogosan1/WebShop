using System;
using System.Collections.Generic;

namespace WebShop.DB;

public partial class Price
{
    public long Id { get; set; }

    public long? IdCounterparty { get; set; }

    public virtual Counterparty? IdCounterpartyNavigation { get; set; }
}
