using System;
using System.Collections.Generic;

namespace asp_net_admin.Models;

public partial class ImageFile
{
    public ulong Id { get; set; }

    /// <summary>
    /// 画像のS3上のパス　拡張子を含めたフルパス
    /// </summary>
    public string? Filepath { get; set; }

    /// <summary>
    /// 元々の名前
    /// </summary>
    public string? Filename { get; set; }

    /// <summary>
    /// 画像の横幅px
    /// </summary>
    public int? Width { get; set; }

    /// <summary>
    /// 画像の縦幅px
    /// </summary>
    public int? Height { get; set; }

    /// <summary>
    /// 作成者
    /// </summary>
    public uint AuthorId { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public DateTime? DeletedAt { get; set; }

    public int VerNo { get; set; }

    public int Filesize { get; set; }

    public int? OwnerProjectId { get; set; }

    public virtual User Author { get; set; } = null!;

    public virtual ICollection<VideoProject> VideoProjectArImages { get; set; } = new List<VideoProject>();

    public virtual ICollection<VideoProjectOptionImageFile> VideoProjectOptionImageFiles { get; set; } = new List<VideoProjectOptionImageFile>();

    public virtual ICollection<VideoProject> VideoProjectOverwrapImages { get; set; } = new List<VideoProject>();

    public virtual ICollection<VideoProject> VideoProjectTitleImages { get; set; } = new List<VideoProject>();
}
