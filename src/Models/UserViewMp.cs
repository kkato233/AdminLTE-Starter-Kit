using System;
using System.Collections.Generic;

namespace asp_net_admin.Models;

public partial class UserViewMp
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
    /// MP ID
    /// </summary>
    public uint MpId { get; set; }

    /// <summary>
    /// ビュー数
    /// </summary>
    public uint ViewCount { get; set; }
}
