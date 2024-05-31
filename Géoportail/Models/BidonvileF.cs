using System;
using System.Collections.Generic;

namespace Géoportail.Models;

public partial class BidonvileF
{
    public int Objectid1 { get; set; }

    public int? Objectid { get; set; }

    public string? NomDouar { get; set; }

    public string? Prefecture { get; set; }

    public string? Commune { get; set; }

    public decimal? ShapeLeng { get; set; }

    public string? Etat { get; set; }

    public int? NearFid { get; set; }

    public decimal? NearDist { get; set; }

    public decimal? NearX { get; set; }

    public decimal? NearY { get; set; }

    public string? FidSiteAc { get; set; }
}
