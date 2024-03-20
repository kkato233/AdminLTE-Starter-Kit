using System;
using System.Collections.Generic;

namespace asp_net_admin.Models;

public partial class SubscriptionItem
{
    public ulong Id { get; set; }

    public ulong SubscriptionId { get; set; }

    public string StripeId { get; set; } = null!;

    public string StripePlan { get; set; } = null!;

    public int Quantity { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }
}
