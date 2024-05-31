using System;
using System.Collections.Generic;

namespace Géoportail.Models;

public partial class SdeColumnRegistry
{
    public string DatabaseName { get; set; } = null!;

    public string TableName { get; set; } = null!;

    public string Owner { get; set; } = null!;

    public string ColumnName { get; set; } = null!;

    public int SdeType { get; set; }

    public int? ColumnSize { get; set; }

    public int? DecimalDigits { get; set; }

    public string? Description { get; set; }

    public int ObjectFlags { get; set; }

    public int? ObjectId { get; set; }

    public virtual SdeTableRegistry SdeTableRegistry { get; set; } = null!;
}
