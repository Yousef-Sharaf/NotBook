using System;
using System.Collections.Generic;
using System.Text;

namespace NotBook.Application.DTOs
{
    public class SessionResultDto
    {
        public Guid Id { get; set; }
        public string JoinCode { get; set; } = string.Empty;
        public string? Name { get; set; }
        public int WorkDuration { get; set; }
        public int BreakDuration { get; set; }
    }
}
