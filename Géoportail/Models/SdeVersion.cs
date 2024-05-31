using System;
using System.Collections.Generic;

namespace Géoportail.Models;

public partial class SdeVersion
{
    public int Major { get; set; }

    public int Minor { get; set; }

    public int Bugfix { get; set; }

    public string Description { get; set; } = null!;

    public int Release { get; set; }

    public int SdesvrRelLow { get; set; }
}
