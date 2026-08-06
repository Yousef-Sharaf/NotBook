using System;
using System.Collections.Generic;
using System.Text;

namespace NotBook.Application.DTOs
{
    public class JoinSessionDto
    {
        public string JoinCode { get; set; } = string.Empty;
        public Guid UserId { get; set; }
    }
}
