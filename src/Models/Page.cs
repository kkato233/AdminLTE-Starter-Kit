using System;
using System.Collections.Generic;

namespace asp_net_admin.Models;

public partial class Page
{
    public uint Id { get; set; }

    public int AuthorId { get; set; }

    public string Title { get; set; } = null!;

    public string? Excerpt { get; set; }

    public string? Body { get; set; }

    public string? Image { get; set; }

    public string Slug { get; set; } = null!;

    public string? MetaDescription { get; set; }

    public string? MetaKeywords { get; set; }

    public string Status { get; set; } = null!;

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }
}
