using System;
using System.Collections.Generic;

namespace Entities.Models
{
    public partial class Comment
    {
        public int Id { get; set; }
        public int UsersId { get; set; }
        public string Email { get; set; } = null!;
        public string Rewiew { get; set; } = null!;
        public string Name { get; set; } = null!;
        public int Star { get; set; }
    }
}
