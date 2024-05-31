using System;
using System.Collections.Generic;

namespace Géoportail.Models;

public partial class SdeVersion1
{
    public string Name { get; set; } = null!;

    public string Owner { get; set; } = null!;

    public int VersionId { get; set; }

    public int Status { get; set; }

    public long StateId { get; set; }

    public string? Description { get; set; }

    public string? ParentName { get; set; }

    public string? ParentOwner { get; set; }

    public int? ParentVersionId { get; set; }

    public DateTime CreationTime { get; set; }

    public virtual ICollection<SdeLayerStat> SdeLayerStats { get; set; } = new List<SdeLayerStat>();
}
