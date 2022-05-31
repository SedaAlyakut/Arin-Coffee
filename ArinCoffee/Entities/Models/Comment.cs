using Core.Entites;
using System;
using System.Collections.Generic;

namespace Entities.Models
{
    public partial class Comment: IEntity
    {
        public int Id { get; set; }
        public int UsersId { get; set; }
        public string Email { get; set; } 
        public string Rewiew { get; set; } 
        public string Name { get; set; } 
        public int Star { get; set; }
    }
}
