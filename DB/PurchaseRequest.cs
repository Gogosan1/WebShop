using System;
using System.Collections.Generic;

namespace WebShop.DB;

public partial class PurchaseRequest
{
    public long Id { get; set; }

    public long? IdRequest { get; set; }

    public long? IdCounterparty { get; set; }

    public virtual Counterparty? IdCounterpartyNavigation { get; set; }

    public virtual Request? IdRequestNavigation { get; set; }
}
