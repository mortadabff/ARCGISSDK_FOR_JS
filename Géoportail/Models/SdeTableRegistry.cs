using System;
using System.Collections.Generic;

namespace Géoportail.Models;

public partial class SdeTableRegistry
{
    public int RegistrationId { get; set; }

    public string DatabaseName { get; set; } = null!;

    public string TableName { get; set; } = null!;

    public string Owner { get; set; } = null!;

    public string? RowidColumn { get; set; }

    public string? Description { get; set; }

    public int ObjectFlags { get; set; }

    public int RegistrationDate { get; set; }

    public string? ConfigKeyword { get; set; }

    public int? MinimumId { get; set; }

    public string? ImvViewName { get; set; }

    public virtual SdeArchive? SdeArchiveArchivingReg { get; set; }

    public virtual SdeArchive? SdeArchiveHistoryReg { get; set; }

    public virtual ICollection<SdeColumnRegistry> SdeColumnRegistries { get; set; } = new List<SdeColumnRegistry>();

    public virtual ICollection<SdeXmlColumn> SdeXmlColumns { get; set; } = new List<SdeXmlColumn>();

    public virtual ICollection<SdeState> States { get; set; } = new List<SdeState>();
}
