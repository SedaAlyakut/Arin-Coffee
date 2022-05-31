using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models
{
    [Table("FeedBack",Schema ="dbo")]
    public class FeedBack
    {
        [Key]
        public int Id { get; set; }
        public string Message { get; set; }
        public string Topic { get; set; }
        public string Email { get; set; }
        public DateTime? DateTime { get; set; }
        public string Answer { get; set; }
        public int Status { get; set; }
    }
}
