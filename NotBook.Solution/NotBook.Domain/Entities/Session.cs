using System;
using System.Collections.Generic;
using System.Text;

namespace NotBook.Domain.Entities
{
    public class Session : BaseEntity
    {
        public string JoinCode { get; set; } = string.Empty;
        public string? Name { get; set; }
        public int WorkDuration { get; set; } = 25;
        public int BreakDuration { get; set; } = 5;
        public Guid CreatedByUserId { get; set; }

        //FK
        public Guid UpdatedByUserId { get; set; }
        public User CreatedByUser { get; set; } = null!;
    }
}
