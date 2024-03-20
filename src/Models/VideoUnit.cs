using System;
using System.Collections.Generic;

namespace asp_net_admin.Models;

public partial class VideoUnit
{
    public ulong Id { get; set; }

    /// <summary>
    /// 動画のFPS
    /// </summary>
    public double? Fps { get; set; }

    /// <summary>
    /// 動画の横幅px
    /// </summary>
    public int? Width { get; set; }

    /// <summary>
    /// 動画の縦幅px
    /// </summary>
    public int? Height { get; set; }

    /// <summary>
    /// 出力動画の外部キー
    /// </summary>
    public ulong? ConvertedVideoId { get; set; }

    /// <summary>
    /// 作成者
    /// </summary>
    public uint AuthorId { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public DateTime? DeletedAt { get; set; }

    public virtual User Author { get; set; } = null!;

    public virtual ConvertedVideo? ConvertedVideo { get; set; }

    public virtual ICollection<VideoProject> VideoProjects { get; set; } = new List<VideoProject>();

    public virtual ICollection<VideoUnitsVideoFile> VideoUnitsVideoFiles { get; set; } = new List<VideoUnitsVideoFile>();
}
