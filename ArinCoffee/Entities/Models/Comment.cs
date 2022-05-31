using Core.Entites;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models
{
    [Table("Comment", Schema = "dbo")]
    public partial class Comment: IEntity
    {
        [Key]
        public int Id { get; set; }
        public int UsersId { get; set; }
        public string Email { get; set; } 
        public string Rewiew { get; set; } 
        public string Name { get; set; } 
        public int Star { get; set; }
    }
}
