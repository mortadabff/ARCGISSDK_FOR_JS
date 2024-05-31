using System;
using System.Collections.Generic;

namespace Géoportail.Models;

public partial class StSpatialReferenceSystem
{
    public int SrsId { get; set; }

    public double XOffset { get; set; }

    public double XScale { get; set; }

    public double YOffset { get; set; }

    public double YScale { get; set; }

    public double ZOffset { get; set; }

    public double ZScale { get; set; }

    public double MOffset { get; set; }

    public double MScale { get; set; }

    public string? Organization { get; set; }

    public int? OrganizationCoordsysId { get; set; }

    public string Definition { get; set; } = null!;
}
