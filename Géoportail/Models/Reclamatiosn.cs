using System;
using System.Collections.Generic;

namespace Géoportail.Models;

public partial class Reclamatiosn
{
    public int Objectid1 { get; set; }

    public int? Objectid { get; set; }

    public string? Objet { get; set; }

    public string? Message { get; set; }

    public string? DemarcheD { get; set; }

    public string? Mail { get; set; }
}
