using System;
using System.Collections.Generic;

namespace Géoportail.Models;

public partial class SdeServerConfig
{
    public string PropName { get; set; } = null!;

    public string? CharPropValue { get; set; }

    public int? NumPropValue { get; set; }
}
