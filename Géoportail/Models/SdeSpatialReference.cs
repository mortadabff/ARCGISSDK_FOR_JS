using System;
using System.Collections.Generic;

namespace Géoportail.Models;

public partial class SdeSpatialReference
{
    public int Srid { get; set; }

    public string? Description { get; set; }

    public string? AuthName { get; set; }

    public int? AuthSrid { get; set; }

    public double Falsex { get; set; }

    public double Falsey { get; set; }

    public double Xyunits { get; set; }

    public double Falsez { get; set; }

    public double Zunits { get; set; }

    public double Falsem { get; set; }

    public double Munits { get; set; }

    public double? XyclusterTol { get; set; }

    public double? ZclusterTol { get; set; }

    public double? MclusterTol { get; set; }

    public int ObjectFlags { get; set; }

    public string Srtext { get; set; } = null!;

    public virtual ICollection<SdeGeometryColumn> SdeGeometryColumns { get; set; } = new List<SdeGeometryColumn>();

    public virtual ICollection<SdeLayer> SdeLayerSecondarySrs { get; set; } = new List<SdeLayer>();

    public virtual ICollection<SdeLayer> SdeLayerSrs { get; set; } = new List<SdeLayer>();

    public virtual ICollection<SdeRasterColumn> SdeRasterColumns { get; set; } = new List<SdeRasterColumn>();
}
