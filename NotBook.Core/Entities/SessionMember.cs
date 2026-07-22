using System;
using System.Collections.Generic;
using System.Text;

namespace NotBook.Core.Entities
{
    public class SessionMember : BaseEntity
    {
        public DateTime JoinedAt { get; set; } = DateTime.UtcNow;

        public Guid SessionId { get; set; }
        public Session Session { get; set; } = null!;

        public Guid UserId { get; set; }
        public User User { get; set; } = null!;
    }
}
