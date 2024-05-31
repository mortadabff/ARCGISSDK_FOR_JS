using System;
using System.Collections.Generic;

namespace Géoportail.Models;

public partial class SdeLayerLock
{
    public int SdeId { get; set; }

    public int LayerId { get; set; }

    public string Autolock { get; set; } = null!;

    public string LockType { get; set; } = null!;

    public DateTime LockTime { get; set; }

    public long? Minx { get; set; }

    public long? Miny { get; set; }

    public long? Maxx { get; set; }

    public long? Maxy { get; set; }
}
