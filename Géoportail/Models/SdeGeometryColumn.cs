using System;
using System.Collections.Generic;

namespace Géoportail.Models;

public partial class SdeGeometryColumn
{
    public string FTableCatalog { get; set; } = null!;

    public string FTableSchema { get; set; } = null!;

    public string FTableName { get; set; } = null!;

    public string FGeometryColumn { get; set; } = null!;

    public string? GTableCatalog { get; set; }

    public string GTableSchema { get; set; } = null!;

    public string GTableName { get; set; } = null!;

    public int? StorageType { get; set; }

    public int? GeometryType { get; set; }

    public int? CoordDimension { get; set; }

    public int? MaxPpr { get; set; }

    public int Srid { get; set; }

    public virtual SdeSpatialReference Sr { get; set; } = null!;
}
