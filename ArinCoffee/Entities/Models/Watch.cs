using System;
using System.Collections.Generic;

namespace Entities.Models
{
    public partial class Watch
    {
        public int Id { get; set; }
        public int UsersId { get; set; }
        public int ProductId { get; set; }

        public virtual Product Product { get; set; } = null!;
    }
}
