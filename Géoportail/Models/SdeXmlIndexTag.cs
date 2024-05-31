using System;
using System.Collections.Generic;

namespace Géoportail.Models;

public partial class SdeXmlIndexTag
{
    public int IndexId { get; set; }

    public int TagId { get; set; }

    public string TagName { get; set; } = null!;

    public int DataType { get; set; }

    public int? TagAlias { get; set; }

    public string? Description { get; set; }

    public int IsExcluded { get; set; }

    public virtual SdeXmlIndex Index { get; set; } = null!;
}
