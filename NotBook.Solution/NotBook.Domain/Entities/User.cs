using System;
using System.Collections.Generic;
using System.Text;

namespace NotBook.Domain.Entities
{
    public class User : BaseEntity
    {
        public string Username { get; set; } = string.Empty;
        public string? Email { get; set; }
        public string? PasswordHash { get; set; }
        public bool IsGuest { get; set; } = false;

        //Navigation property
        public ICollection<Session> CreatedSessions { get; set; } = new List<Session>();
    }
}
