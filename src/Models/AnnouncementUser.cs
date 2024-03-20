using System;
using System.Collections.Generic;

namespace asp_net_admin.Models;

public partial class AnnouncementUser
{
    public uint AnnouncementId { get; set; }

    public uint UserId { get; set; }

    public virtual Announcement Announcement { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
