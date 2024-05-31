using System;
using System.Collections.Generic;

namespace Géoportail.Models;

public partial class GdbTablesLastModified
{
    public string TableName { get; set; } = null!;

    public int LastModifiedCount { get; set; }
}
