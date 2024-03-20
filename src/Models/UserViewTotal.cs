using System;
using System.Collections.Generic;

namespace asp_net_admin.Models;

public partial class UserViewTotal
{
    public ulong Id { get; set; }

    /// <summary>
    /// 作成者
    /// </summary>
    public uint AuthorId { get; set; }

    /// <summary>
    /// YYYYMM
    /// </summary>
    public uint YyyyMm { get; set; }

    /// <summary>
    /// MP ページビュー数
    /// </summary>
    public uint MpViewCount { get; set; }

    /// <summary>
    /// MP グループページビュー数
    /// </summary>
    public uint GroupMpViewCount { get; set; }

    /// <summary>
    /// 通知済みフラグ
    /// </summary>
    public bool NotifiedFlg { get; set; }
}
