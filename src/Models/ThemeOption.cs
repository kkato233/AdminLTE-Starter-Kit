using System;
using System.Collections.Generic;

namespace asp_net_admin.Models;

public partial class ThemeOption
{
    public uint Id { get; set; }

    public uint ThemeId { get; set; }

    public string Key { get; set; } = null!;

    public string? Value { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public virtual Theme Theme { get; set; } = null!;
}
