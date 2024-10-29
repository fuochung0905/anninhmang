using System;
using System.Collections.Generic;

namespace ENTITIES.DBContent;

public partial class Conversation
{
    public Guid ConversationId { get; set; }

    public bool IsGroup { get; set; }

    public DateTime NgayTao { get; set; }

    public bool IsActived { get; set; }

    public bool IsDeleted { get; set; }
}
