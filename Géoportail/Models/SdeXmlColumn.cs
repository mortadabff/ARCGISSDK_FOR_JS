using System;
using System.Collections.Generic;

namespace Géoportail.Models;

public partial class SdeXmlColumn
{
    public int ColumnId { get; set; }

    public int RegistrationId { get; set; }

    public string ColumnName { get; set; } = null!;

    public int? IndexId { get; set; }

    public int? MinimumId { get; set; }

    public string? ConfigKeyword { get; set; }

    public int Xflags { get; set; }

    public virtual SdeXmlIndex? Index { get; set; }

    public virtual SdeTableRegistry Registration { get; set; } = null!;
}
