using System;
using System.Collections.Generic;

namespace asp_net_admin.Models;

public partial class Announcement
{
    public uint Id { get; set; }

    public string Title { get; set; } = null!;

    public string Description { get; set; } = null!;

    public string Body { get; set; } = null!;

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }
}
