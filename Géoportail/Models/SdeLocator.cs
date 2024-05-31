using System;
using System.Collections.Generic;

namespace Géoportail.Models;

public partial class SdeLocator
{
    public int LocatorId { get; set; }

    public string Name { get; set; } = null!;

    public string Owner { get; set; } = null!;

    public string Category { get; set; } = null!;

    public int Type { get; set; }

    public string? Description { get; set; }
}
