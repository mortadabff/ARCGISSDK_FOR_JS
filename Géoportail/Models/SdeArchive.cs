using System;
using System.Collections.Generic;

namespace Géoportail.Models;

public partial class SdeArchive
{
    public int ArchivingRegid { get; set; }

    public int HistoryRegid { get; set; }

    public string FromDate { get; set; } = null!;

    public string ToDate { get; set; } = null!;

    public long ArchiveDate { get; set; }

    public long ArchiveFlags { get; set; }

    public virtual SdeTableRegistry ArchivingReg { get; set; } = null!;

    public virtual SdeTableRegistry HistoryReg { get; set; } = null!;
}
