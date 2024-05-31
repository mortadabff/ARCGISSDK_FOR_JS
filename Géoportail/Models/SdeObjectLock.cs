using System;
using System.Collections.Generic;

namespace Géoportail.Models;

public partial class SdeObjectLock
{
    public int SdeId { get; set; }

    public int ObjectId { get; set; }

    public int ObjectType { get; set; }

    public int ApplicationId { get; set; }

    public string Autolock { get; set; } = null!;

    public string LockType { get; set; } = null!;

    public DateTime LockTime { get; set; }
}
