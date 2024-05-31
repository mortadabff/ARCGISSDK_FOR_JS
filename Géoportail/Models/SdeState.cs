using System;
using System.Collections.Generic;

namespace Géoportail.Models;

public partial class SdeState
{
    public long StateId { get; set; }

    public string Owner { get; set; } = null!;

    public DateTime CreationTime { get; set; }

    public DateTime? ClosingTime { get; set; }

    public long ParentStateId { get; set; }

    public long LineageName { get; set; }

    public virtual ICollection<SdeTableRegistry> Registrations { get; set; } = new List<SdeTableRegistry>();
}
