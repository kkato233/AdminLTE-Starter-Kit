using System;
using System.Collections.Generic;

namespace asp_net_admin.Models;

public partial class ApiKey
{
    public uint Id { get; set; }

    public uint UserId { get; set; }

    public string Name { get; set; } = null!;

    public string Key { get; set; } = null!;

    public DateTime? LastUsedAt { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }
}
