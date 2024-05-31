using System;
using System.Collections.Generic;

namespace Géoportail.Models;

public partial class GdbReplicalog
{
    public int Id { get; set; }

    public int ReplicaId { get; set; }

    public int Event { get; set; }

    public int ErrorCode { get; set; }

    public DateTime LogDate { get; set; }

    public int SourceBeginGen { get; set; }

    public int SourceEndGen { get; set; }

    public int TargetGen { get; set; }
}
