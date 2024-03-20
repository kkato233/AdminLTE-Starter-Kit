using System;
using System.Collections.Generic;

namespace asp_net_admin.Models;

public partial class Plan
{
    public uint Id { get; set; }

    public string Name { get; set; } = null!;

    public string? Description { get; set; }

    public string Features { get; set; } = null!;

    public string PlanId { get; set; } = null!;

    public ulong RoleId { get; set; }

    public bool Default { get; set; }

    public string? Price { get; set; }

    public int TrialDays { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public int Order { get; set; }

    public virtual Role Role { get; set; } = null!;
}
