using System;
using System.Collections.Generic;

namespace asp_net_admin.Models;

public partial class Theme
{
    public uint Id { get; set; }

    public string Name { get; set; } = null!;

    public string Folder { get; set; } = null!;

    public bool Active { get; set; }

    public string Version { get; set; } = null!;

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public virtual ICollection<ThemeOption> ThemeOptions { get; set; } = new List<ThemeOption>();
}
