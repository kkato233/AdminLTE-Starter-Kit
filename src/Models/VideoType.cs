using System;
using System.Collections.Generic;

namespace asp_net_admin.Models;

public partial class VideoType
{
    public string Type { get; set; } = null!;

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public virtual ICollection<ConvertedVideo> ConvertedVideos { get; set; } = new List<ConvertedVideo>();
}
