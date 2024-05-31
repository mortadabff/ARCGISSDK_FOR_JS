using System;
using System.Collections.Generic;

namespace Géoportail.Models;

public partial class StGeometryColumn
{
    public string TableSchema { get; set; } = null!;

    public string TableName { get; set; } = null!;

    public string ColumnName { get; set; } = null!;

    public string TypeSchema { get; set; } = null!;

    public string TypeName { get; set; } = null!;

    public int SrsId { get; set; }
}
