using System;
using System.Collections.Generic;

namespace Géoportail.Models;

public partial class GdbItem
{
    public int ObjectId { get; set; }

    public Guid Uuid { get; set; }

    public Guid Type { get; set; }

    public string? Name { get; set; }

    public string? PhysicalName { get; set; }

    public string? Path { get; set; }

    public string? Url { get; set; }

    public int? Properties { get; set; }

    public byte[]? Defaults { get; set; }

    public int? DatasetSubtype1 { get; set; }

    public int? DatasetSubtype2 { get; set; }

    public string? DatasetInfo1 { get; set; }

    public string? DatasetInfo2 { get; set; }

    public string? Definition { get; set; }

    public string? Documentation { get; set; }

    public string? ItemInfo { get; set; }
}
