using System;
using System.Collections.Generic;

namespace WebShop.DB;

public partial class Counterparty
{
    public long Id { get; set; }

    public long Inn { get; set; }

    public string BanksName { get; set; } = null!;

    public long CurrentAccountNumber { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<Price> Prices { get; set; } = new List<Price>();

    public virtual ICollection<PurchaseRequest> PurchaseRequests { get; set; } = new List<PurchaseRequest>();
}
