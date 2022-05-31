using Core.Entites;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models
{
    [Table("Card", Schema = "dbo")]
    public partial class Card : IEntity
    {
        public Card()
        {
            Orders = new HashSet<Order>();
        }
        [Key]
        public int Id { get; set; }
        public int UsersId { get; set; }
        public int ProductId { get; set; }
        public int Status { get; set; }
        public virtual Product Product { get; set; } 
        public virtual ICollection<Order> Orders { get; set; }
    }
}
