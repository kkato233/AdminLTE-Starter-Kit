using System;
using System.Collections.Generic;

namespace asp_net_admin.Models;

public partial class VideoGroupVideoProject
{
    public ulong Id { get; set; }

    /// <summary>
    /// 動画グループの外部キー
    /// </summary>
    public ulong VideoGroupId { get; set; }

    /// <summary>
    /// ビデオプロジェクトの外部キー
    /// </summary>
    public ulong VideoProjectId { get; set; }

    public virtual VideoGroup VideoGroup { get; set; } = null!;

    public virtual VideoProject VideoProject { get; set; } = null!;
}
