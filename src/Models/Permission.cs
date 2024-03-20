using System;
using System.Collections.Generic;

namespace asp_net_admin.Models;

public partial class Permission
{
    public ulong Id { get; set; }

    public string Key { get; set; } = null!;

    public string? TableName { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public uint? PermissionGroupId { get; set; }

    public virtual ICollection<Role> Roles { get; set; } = new List<Role>();
}
