using System;
using System.Collections.Generic;
using System.Text;

namespace NotBook.Core.Entities
{
    public class User : BaseEntity
    {
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string PasswordHash { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public ICollection<Session> HostedSessions { get; set; } = new List<Session>();
        public ICollection<SessionMember> Memberships { get; set; } = new List<SessionMember>();
    }
}
