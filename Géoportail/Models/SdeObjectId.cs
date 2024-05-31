using System;
using System.Collections.Generic;

namespace Géoportail.Models;

public partial class SdeObjectId
{
    public int IdType { get; set; }

    public long BaseId { get; set; }

    public string ObjectType { get; set; } = null!;
}
