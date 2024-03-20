using System;
using System.Collections.Generic;

namespace asp_net_admin.Models;

public partial class User
{
    public uint Id { get; set; }

    public ulong? RoleId { get; set; }

    public string Name { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string? Avatar { get; set; }

    public DateTime? EmailVerifiedAt { get; set; }

    public string Password { get; set; } = null!;

    public string? RememberToken { get; set; }

    public string? Settings { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public string Username { get; set; } = null!;

    public string? StripeId { get; set; }

    public string? CardBrand { get; set; }

    public string? CardLastFour { get; set; }

    public DateTime? TrialEndsAt { get; set; }

    public string? VerificationCode { get; set; }

    public bool? Verified { get; set; }

    public ulong? CoopInfoId { get; set; }

    public ulong? UserConfigId { get; set; }

    public string? UserKey { get; set; }

    /// <summary>
    /// WebAR MP 用で利用する テンプレート
    /// </summary>
    public string? WebArTemplate { get; set; }

    public string? AnalyticsUrl { get; set; }

    public virtual ICollection<ConvertedVideo> ConvertedVideos { get; set; } = new List<ConvertedVideo>();

    public virtual CoopInfo? CoopInfo { get; set; }

    public virtual ICollection<ImageFile> ImageFiles { get; set; } = new List<ImageFile>();

    public virtual Role? Role { get; set; }

    public virtual UserConfig? UserConfig { get; set; }

    public virtual ICollection<VideoFile> VideoFiles { get; set; } = new List<VideoFile>();

    public virtual ICollection<VideoGroup> VideoGroups { get; set; } = new List<VideoGroup>();

    public virtual ICollection<VideoProject> VideoProjects { get; set; } = new List<VideoProject>();

    public virtual ICollection<VideoUnit> VideoUnits { get; set; } = new List<VideoUnit>();

    public virtual ICollection<Role> Roles { get; set; } = new List<Role>();
}
