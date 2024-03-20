using System;
using System.Collections.Generic;

namespace asp_net_admin.Models;

public partial class CoopInfo
{
    public ulong Id { get; set; }

    /// <summary>
    /// 名称
    /// </summary>
    public string Name { get; set; } = null!;

    /// <summary>
    /// ヘッダー表示 HTML
    /// </summary>
    public string? LoginHtmlHeader { get; set; }

    /// <summary>
    /// フッター表示 HTML
    /// </summary>
    public string? LoginHtmlFooter { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public DateTime? DeletedAt { get; set; }

    public virtual ICollection<User> Users { get; set; } = new List<User>();
}
