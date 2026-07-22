using System;
using System.Collections.Generic;
using System.Text;

namespace NotBook.Core.Entities
{
    public class Session : BaseEntity
    {
        public string Title { get; set; } = string.Empty;
        public int WorkMinutes { get; set; }
        public int BreakMinutes { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public Guid HostUserId { get; set; }
        public User Host { get; set; } = null!;
        public ICollection<SessionMember> Members { get; set; } = new List<SessionMember>();
    }
}
