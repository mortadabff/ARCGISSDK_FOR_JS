using System;
using System.Collections.Generic;

namespace Géoportail.Models;

public partial class GdbItemrelationship
{
    public int ObjectId { get; set; }

    public Guid Uuid { get; set; }

    public Guid Type { get; set; }

    public Guid OriginId { get; set; }

    public Guid DestId { get; set; }

    public int? Properties { get; set; }

    public string? Attributes { get; set; }
}
