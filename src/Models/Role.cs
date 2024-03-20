using System;
using System.Collections.Generic;

namespace asp_net_admin.Models;

public partial class Role
{
    public ulong Id { get; set; }

    public string Name { get; set; } = null!;

    public string DisplayName { get; set; } = null!;

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public virtual ICollection<Plan> Plans { get; set; } = new List<Plan>();

    public virtual ICollection<User> Users { get; set; } = new List<User>();

    public virtual ICollection<Permission> Permissions { get; set; } = new List<Permission>();

    public virtual ICollection<User> UsersNavigation { get; set; } = new List<User>();
}
