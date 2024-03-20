using System;
using System.Collections.Generic;

namespace asp_net_admin.Models;

public partial class Subscription
{
    public uint Id { get; set; }

    public uint UserId { get; set; }

    public string Name { get; set; } = null!;

    public string StripeId { get; set; } = null!;

    public string StripePlan { get; set; } = null!;

    public int Quantity { get; set; }

    public DateTime? TrialEndsAt { get; set; }

    public DateTime? EndsAt { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public string StripeStatus { get; set; } = null!;
}
