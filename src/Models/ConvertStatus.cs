using System;
using System.Collections.Generic;

namespace asp_net_admin.Models;

public partial class ConvertStatus
{
    public string Status { get; set; } = null!;

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public virtual ICollection<ConvertedVideo> ConvertedVideos { get; set; } = new List<ConvertedVideo>();
}
