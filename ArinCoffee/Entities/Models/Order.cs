using Core.Entites;
using System;
using System.Collections.Generic;

namespace Entities.Models
{
    public partial class Order : IEntity
    {
        
        public int OrderId { get; set; }
        public int UsersId { get; set; }
        public int CardId { get; set; }
        public int Status { get; set; }
        public DateTime OrderTime { get; set; }
        public DateTime EndTime { get; set; }

        public virtual Card Card { get; set; } 
    }
}
