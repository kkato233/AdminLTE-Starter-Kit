using System;
using System.Collections.Generic;

namespace asp_net_admin.Models;

public partial class ConvertedVideo
{
    public ulong Id { get; set; }

    /// <summary>
    /// 動画のS3上のパス
    /// </summary>
    public string? Dirpath { get; set; }

    /// <summary>
    /// 動画のエンコード形式
    /// </summary>
    public string Type { get; set; } = null!;

    /// <summary>
    /// 動画のエンコード状態
    /// </summary>
    public string Status { get; set; } = null!;

    /// <summary>
    /// 作成者
    /// </summary>
    public uint AuthorId { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public DateTime? DeletedAt { get; set; }

    public string? JobLow { get; set; }

    public string? JobHigh { get; set; }

    public DateTime? ConvertStartTime { get; set; }

    public DateTime? ConvertLowTime { get; set; }

    public DateTime? ConvertHighTime { get; set; }

    public virtual User Author { get; set; } = null!;

    public virtual ConvertStatus StatusNavigation { get; set; } = null!;

    public virtual VideoType TypeNavigation { get; set; } = null!;

    public virtual ICollection<VideoProject> VideoProjectConvertedVideos { get; set; } = new List<VideoProject>();

    public virtual ICollection<VideoProject> VideoProjectWebArConvertedVideos { get; set; } = new List<VideoProject>();

    public virtual ICollection<VideoUnit> VideoUnits { get; set; } = new List<VideoUnit>();
}
