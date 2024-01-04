using System;
using System.Collections.Generic;

namespace WebShop.DB;

public partial class ListOfProductsInAssortment
{
    public long? IdAssortiment { get; set; }

    public long? IdGoods { get; set; }

    public long? Quantity { get; set; }

    public long? Cost { get; set; }

    public virtual Assortment? IdAssortimentNavigation { get; set; }

    public virtual Good? IdGoodsNavigation { get; set; }
}
