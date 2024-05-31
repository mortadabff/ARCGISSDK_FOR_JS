using System;
using System.Collections.Generic;

namespace Géoportail.Models;

public partial class SdeXmlIndex
{
    public int IndexId { get; set; }

    public string IndexName { get; set; } = null!;

    public string Owner { get; set; } = null!;

    public int IndexType { get; set; }

    public string? Description { get; set; }

    public virtual ICollection<SdeXmlColumn> SdeXmlColumns { get; set; } = new List<SdeXmlColumn>();

    public virtual ICollection<SdeXmlIndexTag> SdeXmlIndexTags { get; set; } = new List<SdeXmlIndexTag>();
}
