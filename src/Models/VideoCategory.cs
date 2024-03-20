using System;
using System.Collections.Generic;

namespace asp_net_admin.Models;

public partial class VideoCategory
{
    public ulong Id { get; set; }

    /// <summary>
    /// 並び替え順
    /// </summary>
    public int Order { get; set; }

    /// <summary>
    /// カテゴリ 日本語名
    /// </summary>
    public string Name { get; set; } = null!;

    /// <summary>
    /// カテゴリ 英名
    /// </summary>
    public string Slug { get; set; } = null!;

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public DateTime? DeletedAt { get; set; }

    public virtual ICollection<VideoProject> VideoProjects { get; set; } = new List<VideoProject>();
}
