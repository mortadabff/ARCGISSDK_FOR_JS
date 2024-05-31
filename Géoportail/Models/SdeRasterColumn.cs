using System;
using System.Collections.Generic;

namespace Géoportail.Models;

public partial class SdeRasterColumn
{
    public int RastercolumnId { get; set; }

    public string? Description { get; set; }

    public string DatabaseName { get; set; } = null!;

    public string Owner { get; set; } = null!;

    public string TableName { get; set; } = null!;

    public string RasterColumn { get; set; } = null!;

    public int Cdate { get; set; }

    public string? ConfigKeyword { get; set; }

    public int? MinimumId { get; set; }

    public int BaseRastercolumnId { get; set; }

    public int RastercolumnMask { get; set; }

    public int? Srid { get; set; }

    public virtual SdeSpatialReference? Sr { get; set; }
}
