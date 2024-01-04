using System;
using System.Collections.Generic;

namespace WebShop.DB;

public partial class ListOfGoodsInTheCheck
{
    public long? IdCheck { get; set; }

    public long? IdGoods { get; set; }

    public long? Quantity { get; set; }

    public virtual Check? IdCheckNavigation { get; set; }

    public virtual Good? IdGoodsNavigation { get; set; }
}
