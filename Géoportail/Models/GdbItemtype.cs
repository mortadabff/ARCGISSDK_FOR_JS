using System;
using System.Collections.Generic;

namespace Géoportail.Models;

public partial class GdbItemtype
{
    public int ObjectId { get; set; }

    public Guid Uuid { get; set; }

    public string Name { get; set; } = null!;

    public Guid ParentTypeId { get; set; }
}
