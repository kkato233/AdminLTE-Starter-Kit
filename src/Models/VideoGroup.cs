using System;
using System.Collections.Generic;

namespace asp_net_admin.Models;

public partial class VideoGroup
{
    public ulong Id { get; set; }

    /// <summary>
    /// ビデオグループタイトル
    /// </summary>
    public string Title { get; set; } = null!;

    /// <summary>
    /// 概要
    /// </summary>
    public string? Description { get; set; }

    /// <summary>
    /// 作成者
    /// </summary>
    public uint AuthorId { get; set; }

    /// <summary>
    /// 視聴コード
    /// </summary>
    public string? Code { get; set; }

    public bool? Exist { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public DateTime? DeletedAt { get; set; }

    /// <summary>
    /// 選択されているMP一覧
    /// </summary>
    public string? SelectedItems { get; set; }

    /// <summary>
    /// WebAR MP グループ で利用する テンプレート
    /// </summary>
    public string? WebArTemplate { get; set; }

    public virtual User Author { get; set; } = null!;

    public virtual ICollection<VideoGroupVideoProject> VideoGroupVideoProjects { get; set; } = new List<VideoGroupVideoProject>();
}
