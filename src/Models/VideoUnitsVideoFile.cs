using System;
using System.Collections.Generic;

namespace asp_net_admin.Models;

public partial class VideoUnitsVideoFile
{
    public ulong Id { get; set; }

    /// <summary>
    /// 動画ユニットの外部キー
    /// </summary>
    public ulong VideoUnitId { get; set; }

    /// <summary>
    /// 動画ファイルの外部キー
    /// </summary>
    public ulong VideoFileId { get; set; }

    /// <summary>
    /// 動画ユニットに対しての並び順
    /// </summary>
    public uint Order { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public virtual VideoFile VideoFile { get; set; } = null!;

    public virtual VideoUnit VideoUnit { get; set; } = null!;
}
