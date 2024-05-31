using System;
using System.Collections.Generic;

namespace Géoportail.Models;

public partial class SdeGeometry3
{
    public int GeometryId { get; set; }

    public byte[]? Cad { get; set; }
}
