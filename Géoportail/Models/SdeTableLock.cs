using System;
using System.Collections.Generic;

namespace Géoportail.Models;

public partial class SdeTableLock
{
    public int SdeId { get; set; }

    public int RegistrationId { get; set; }

    public string LockType { get; set; } = null!;

    public DateTime LockTime { get; set; }
}
