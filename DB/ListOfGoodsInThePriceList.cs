using System;
using System.Collections.Generic;

namespace WebShop.DB;

public partial class ListOfGoodsInThePriceList
{
    public long? IdPrice { get; set; }

    public long? IdGoods { get; set; }

    public long? Cost { get; set; }

    public virtual Good? IdGoodsNavigation { get; set; }

    public virtual Price? IdPriceNavigation { get; set; }
}
