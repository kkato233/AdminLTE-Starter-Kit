using System;
using System.Collections.Generic;

namespace asp_net_admin.Models;

public partial class UserConfig
{
    public ulong Id { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public bool ShowExOption1 { get; set; }

    public bool ShowOldFunction { get; set; }

    public virtual ICollection<User> Users { get; set; } = new List<User>();
}
