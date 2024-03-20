using System;
using System.Collections.Generic;

namespace asp_net_admin.Models;

public partial class VideoProjectOptionImageFile
{
    public ulong Id { get; set; }

    /// <summary>
    /// プロジェクトの外部キー
    /// </summary>
    public ulong VideoProjectId { get; set; }

    /// <summary>
    /// 画像ファイルの外部キー
    /// </summary>
    public ulong ImageFileId { get; set; }

    public bool? Enabled { get; set; }

    public int? X { get; set; }

    public int? Y { get; set; }

    public int? Z { get; set; }

    public int? Width { get; set; }

    public int? Height { get; set; }

    public string? ActionParam { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public virtual ImageFile ImageFile { get; set; } = null!;

    public virtual VideoProject VideoProject { get; set; } = null!;
}
