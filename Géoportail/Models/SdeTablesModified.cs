using System;
using System.Collections.Generic;

namespace Géoportail.Models;

public partial class SdeTablesModified
{
    public string TableName { get; set; } = null!;

    public DateTime TimeLastModified { get; set; }
}
