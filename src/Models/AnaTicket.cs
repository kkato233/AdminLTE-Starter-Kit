using System;
using System.Collections.Generic;

namespace asp_net_admin.Models;

public partial class AnaTicket
{
    public ulong Id { get; set; }

    public int Status { get; set; }

    public string Passcode { get; set; } = null!;

    /// <summary>
    /// S3 に登録したファイル名
    /// </summary>
    public string? S3Filename { get; set; }

    /// <summary>
    /// OCR 解析した結果の JSON情報
    /// </summary>
    public string? ResultJson { get; set; }

    /// <summary>
    /// エラーメッセージ等
    /// </summary>
    public string? Message { get; set; }

    /// <summary>
    /// データ登録時間
    /// </summary>
    public DateTime? DataAddAt { get; set; }

    /// <summary>
    /// 画像解析完了時間
    /// </summary>
    public DateTime? ResultAt { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public DateTime? DeletedAt { get; set; }
}
