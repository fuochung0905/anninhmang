using System;
using System.Collections.Generic;

namespace ENTITIES.DBContent;

public partial class Log
{
    public int Id { get; set; }

    public DateTime Date { get; set; }

    public string Thread { get; set; } = null!;

    public string Level { get; set; } = null!;

    public string Logger { get; set; } = null!;

    public string Message { get; set; } = null!;

    public string Exception { get; set; } = null!;

    public string UserName { get; set; } = null!;

    public Guid DonViId { get; set; }

    public string IpAddress { get; set; } = null!;

    public bool IsDeleted { get; set; }
}
