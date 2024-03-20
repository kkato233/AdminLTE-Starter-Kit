using System;
using System.Collections.Generic;

namespace asp_net_admin.Models;

public partial class VideoFile
{
    public ulong Id { get; set; }

    /// <summary>
    /// 動画のS3上のパス　拡張子を含めたフルパス
    /// </summary>
    public string? Filepath { get; set; }

    /// <summary>
    /// 元々の動画の名前
    /// </summary>
    public string? Filename { get; set; }

    /// <summary>
    /// 動画のデータ容量
    /// </summary>
    public int? Filesize { get; set; }

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
    /// 動画の長さ
    /// </summary>
    public int? Duration { get; set; }

    /// <summary>
    /// 作成者
    /// </summary>
    public uint AuthorId { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public DateTime? DeletedAt { get; set; }

    public int Rotate { get; set; }

    public int? OwnerProjectId { get; set; }

    public virtual User Author { get; set; } = null!;

    public virtual ICollection<VideoUnitsVideoFile> VideoUnitsVideoFiles { get; set; } = new List<VideoUnitsVideoFile>();
}
