using System;
using System.Collections.Generic;

namespace ENTITIES.DBContent;

public partial class Message
{
    public Guid MessageId { get; set; }

    public Guid ConversationId { get; set; }

    public Guid UserId { get; set; }

    public string NoiDung { get; set; } = null!;

    public DateTime NgayTao { get; set; }

    public DateTime? NgaySua { get; set; }

    public DateTime? NgayXoa { get; set; }

    public bool IsActived { get; set; }

    public bool IsDeleted { get; set; }
}
