using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Core.Entites;


namespace Entities.Models
{
    [Table("Watch", Schema = "dbo")]

    public partial class Watch : IEntity
    {
        [Key]
        public int Id { get; set; }
        public int UsersId { get; set; }
        public int ProductId { get; set; }

        public virtual Product Product { get; set; } 
    }
}
