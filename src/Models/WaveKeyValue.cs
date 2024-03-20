using System;
using System.Collections.Generic;

namespace asp_net_admin.Models;

public partial class WaveKeyValue
{
    public uint Id { get; set; }

    public string Type { get; set; } = null!;

    public uint KeyvalueId { get; set; }

    public string KeyvalueType { get; set; } = null!;

    public string Key { get; set; } = null!;

    public string Value { get; set; } = null!;
}
