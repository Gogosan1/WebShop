using System;
using System.Collections.Generic;

namespace WebShop.DB;

public partial class CorrespondencePositionPerson
{
    public long? IdPerson { get; set; }

    public long? Id { get; set; }

    public double? Salary { get; set; }

    public string? DateOfEmployment { get; set; }

    public long? DateOfUnemployment { get; set; }

    public long? PartTimeWorker { get; set; }

    public virtual Position? IdNavigation { get; set; }

    public virtual Person? IdPersonNavigation { get; set; }
}
