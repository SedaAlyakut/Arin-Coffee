using Core.Entites;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models
{
    [Table("Order", Schema = "dbo")]

    public partial class Order : IEntity
    {
        [Key]
        public int OrderId { get; set; }
        public int UsersId { get; set; }
        public int CardId { get; set; }
        public int Status { get; set; }
        public DateTime? OrderTime { get; set; }
        public DateTime? EndTime { get; set; }

        public virtual Card Card { get; set; } 
    }
}
