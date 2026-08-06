using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace NotBook.Application.DTOs
{
    public class CreateSessionDto
    {
        public string? Name { get; set; }
        [Range(25,480, ErrorMessage = "Work duration must be between 25 and 480 minutes.")]
        public int WorkDuration { get; set; } = 25;
        [Range(0, 90, ErrorMessage = "Break duration must be less than 90 minutes.")]
        public int BreakDuration { get; set; } = 5;
        public Guid CreatedByUserId { get; set; }
    }
}
