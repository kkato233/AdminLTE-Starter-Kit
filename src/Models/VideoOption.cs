using System;
using System.Collections.Generic;

namespace asp_net_admin.Models;

public partial class VideoOption
{
    public ulong Id { get; set; }

    /// <summary>
    /// ARアイコンの位置情報を記録する値 Json 形式で格納
    /// </summary>
    public string? ArIconJsonInfo { get; set; }

    /// <summary>
    /// 関連する MP 情報の格納された Json 形式データ
    /// </summary>
    public string? MpLinkJsonInfo { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    /// <summary>
    /// ARアイコンの画像番号
    /// </summary>
    public int? ArIconImageId { get; set; }

    /// <summary>
    /// ARアイコン編集用情報
    /// </summary>
    public string? ArIconEditParamJson { get; set; }

    /// <summary>
    /// MP リンク情報を 編集するために利用する追加情報
    /// </summary>
    public string? MpLinkEditInfo { get; set; }
}
