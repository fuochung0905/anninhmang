using System;
using System.Collections.Generic;

namespace ENTITIES.DBContent;

public partial class ConversationParticipant
{
    public Guid ParticipantId { get; set; }

    public Guid ConversationId { get; set; }

    public Guid UserId { get; set; }
}
