using System;
using System.Collections.Generic;

namespace Géoportail.Models;

public partial class SdeMetadatum
{
    public int RecordId { get; set; }

    public string? ObjectDatabase { get; set; }

    public string ObjectName { get; set; } = null!;

    public string ObjectOwner { get; set; } = null!;

    public int ObjectType { get; set; }

    public string? ClassName { get; set; }

    public string? Property { get; set; }

    public string? PropValue { get; set; }

    public string? Description { get; set; }

    public DateTime CreationDate { get; set; }
}
