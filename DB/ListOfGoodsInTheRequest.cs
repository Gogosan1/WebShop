using System;
using System.Collections.Generic;

namespace WebShop.DB;

public partial class ListOfGoodsInTheRequest
{
    public long? IdRequest { get; set; }

    public long? IdGoods { get; set; }

    public long Quantity { get; set; }

    public virtual Good? IdGoodsNavigation { get; set; }

    public virtual Request? IdRequestNavigation { get; set; }
}
