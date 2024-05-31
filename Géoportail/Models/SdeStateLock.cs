using System;
using System.Collections.Generic;

namespace Géoportail.Models;

public partial class SdeStateLock
{
    public int SdeId { get; set; }

    public long StateId { get; set; }

    public string Autolock { get; set; } = null!;

    public string LockType { get; set; } = null!;

    public DateTime LockTime { get; set; }
}
