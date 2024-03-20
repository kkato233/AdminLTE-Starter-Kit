using System;
using System.Collections.Generic;

namespace asp_net_admin.Models;

public partial class VideoProject
{
    public ulong Id { get; set; }

    /// <summary>
    /// 動画タイトル
    /// </summary>
    public string Title { get; set; } = null!;

    /// <summary>
    /// 動画概要
    /// </summary>
    public string? Description { get; set; }

    /// <summary>
    /// 出力動画の外部キー
    /// </summary>
    public ulong? ConvertedVideoId { get; set; }

    /// <summary>
    /// 動画ユニットの外部キー
    /// </summary>
    public ulong? VideoUnitId { get; set; }

    /// <summary>
    /// 静止画の外部キー
    /// </summary>
    public ulong? ArImageId { get; set; }

    /// <summary>
    /// 作成者
    /// </summary>
    public uint AuthorId { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public DateTime? DeletedAt { get; set; }

    public bool? AutoStart { get; set; }

    public int EffectType { get; set; }

    public ulong? TitleImageId { get; set; }

    public bool PublicFlg { get; set; }

    public int ArExecMode { get; set; }

    /// <summary>
    /// ビデオカテゴリの外部キー
    /// </summary>
    public ulong? VideoCategoryId { get; set; }

    public int? VideoOptionId { get; set; }

    public int AutoEnd { get; set; }

    public string? ActionUrl { get; set; }

    public int ActionUrlAskFlg { get; set; }

    public ulong? OverwrapImageId { get; set; }

    public bool VideoNoResize { get; set; }

    /// <summary>
    /// 視聴コード
    /// </summary>
    public string? Code { get; set; }

    /// <summary>
    /// 動画開始日時
    /// </summary>
    public DateTime? StartAt { get; set; }

    /// <summary>
    /// 動画終了日時
    /// </summary>
    public DateTime? EndAt { get; set; }

    public bool? Exist { get; set; }

    public int ArAreaAnimation { get; set; }

    /// <summary>
    /// WebAr用のビデオ
    /// </summary>
    public ulong? WebArConvertedVideoId { get; set; }

    /// <summary>
    /// 一括ダウンロードフラグ
    /// </summary>
    public int UserBatchDownloadFlg { get; set; }

    /// <summary>
    /// WebAR MP 用で利用する テンプレート
    /// </summary>
    public string? WebArTemplate { get; set; }

    public virtual ImageFile? ArImage { get; set; }

    public virtual User Author { get; set; } = null!;

    public virtual ConvertedVideo? ConvertedVideo { get; set; }

    public virtual ImageFile? OverwrapImage { get; set; }

    public virtual ImageFile? TitleImage { get; set; }

    public virtual VideoCategory? VideoCategory { get; set; }

    public virtual ICollection<VideoGroupVideoProject> VideoGroupVideoProjects { get; set; } = new List<VideoGroupVideoProject>();

    public virtual ICollection<VideoProjectOptionImageFile> VideoProjectOptionImageFiles { get; set; } = new List<VideoProjectOptionImageFile>();

    public virtual VideoUnit? VideoUnit { get; set; }

    public virtual ConvertedVideo? WebArConvertedVideo { get; set; }
}
