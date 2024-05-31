using System;
using System.Collections.Generic;

namespace Géoportail.Models;

public partial class GdbItemrelationshiptype
{
    public int ObjectId { get; set; }

    public Guid Uuid { get; set; }

    public string Name { get; set; } = null!;

    public string? ForwardLabel { get; set; }

    public string? BackwardLabel { get; set; }

    public Guid OrigItemTypeId { get; set; }

    public Guid DestItemTypeId { get; set; }

    public short? IsContainment { get; set; }
}
