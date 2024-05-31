using System;
using System.Collections.Generic;

namespace Géoportail.Models;

public partial class SdeLayer
{
    public int LayerId { get; set; }

    public string? Description { get; set; }

    public string DatabaseName { get; set; } = null!;

    public string TableName { get; set; } = null!;

    public string Owner { get; set; } = null!;

    public string SpatialColumn { get; set; } = null!;

    public int Eflags { get; set; }

    public int LayerMask { get; set; }

    public double Gsize1 { get; set; }

    public double Gsize2 { get; set; }

    public double Gsize3 { get; set; }

    public double Minx { get; set; }

    public double Miny { get; set; }

    public double Maxx { get; set; }

    public double Maxy { get; set; }

    public double? Minz { get; set; }

    public double? Maxz { get; set; }

    public double? Minm { get; set; }

    public double? Maxm { get; set; }

    public int Cdate { get; set; }

    public string? LayerConfig { get; set; }

    public int? OptimalArraySize { get; set; }

    public int? StatsDate { get; set; }

    public int? MinimumId { get; set; }

    public int Srid { get; set; }

    public int BaseLayerId { get; set; }

    public int? SecondarySrid { get; set; }

    public virtual ICollection<SdeLayerStat> SdeLayerStats { get; set; } = new List<SdeLayerStat>();

    public virtual SdeSpatialReference? SecondarySr { get; set; }

    public virtual SdeSpatialReference Sr { get; set; } = null!;
}
