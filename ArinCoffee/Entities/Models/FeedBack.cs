using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Core.Entites;


namespace Entities.Models
{
    [Table("FeedBack",Schema ="dbo")]
    public class FeedBack : IEntity
    {
        [Key]
        public int? Id { get; set; }
        public string Message { get; set; }
        public string NameSurname { get; set; }
        public string Topic { get; set; }
        public string Email { get; set; }
        public DateTime? DateTime { get; set; }
        public string Answer { get; set; }
        public int? Status { get; set; }
    }
}
