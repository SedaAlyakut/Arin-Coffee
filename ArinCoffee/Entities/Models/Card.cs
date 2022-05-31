using Core.Entites;
using System;
using System.Collections.Generic;

namespace Entities.Models
{
    public partial class Card : IEntity
    {
        public Card()
        {
            Orders = new HashSet<Order>();
        }

        public int Id { get; set; }
        public int UsersId { get; set; }
        public int ProductId { get; set; }
        public int Status { get; set; }

        public virtual Product Product { get; set; } = null!;
        public virtual ICollection<Order> Orders { get; set; }
    }
}
