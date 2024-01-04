using System;
using System.Collections.Generic;

namespace WebShop.DB;

public partial class User
{
    public long Id { get; set; }

    public string Login { get; set; } = null!;

    public string Password { get; set; } = null!;

    public long RoleId { get; set; }

    public long? PersonId { get; set; }

    public long? OrganizationId { get; set; }

    public virtual Organization? Organization { get; set; }

    public virtual Person? Person { get; set; }

    public virtual Role Role { get; set; } = null!;
}
