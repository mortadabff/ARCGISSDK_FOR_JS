using System;
using System.Collections.Generic;

namespace Géoportail.Models;

public partial class SdeDbtune
{
    public string Keyword { get; set; } = null!;

    public string ParameterName { get; set; } = null!;

    public string? ConfigString { get; set; }
}
