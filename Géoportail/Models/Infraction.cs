using System;
using System.Collections.Generic;

namespace Géoportail.Models;

public partial class Infraction
{
    public int Objectid { get; set; }

    public string? Objet { get; set; }

    public string? Type { get; set; }

    public string? Prefecture { get; set; }
}
