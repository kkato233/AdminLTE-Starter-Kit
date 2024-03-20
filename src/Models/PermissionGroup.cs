using System;
using System.Collections.Generic;

namespace asp_net_admin.Models;

public partial class PermissionGroup
{
    public uint Id { get; set; }

    public string Name { get; set; } = null!;
}
