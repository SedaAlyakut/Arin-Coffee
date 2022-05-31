using System;
using System.Collections.Generic;

namespace Entities.Models
{
    public partial class Product
    {
        public Product()
        {
            Cards = new HashSet<Card>();
            Watches = new HashSet<Watch>();
        }

        public int ProductId { get; set; }
        public string ProductName { get; set; } = null!;
        public int Weight { get; set; }
        public int Status { get; set; }
        public string Image1 { get; set; } = null!;
        public string Image2 { get; set; } = null!;
        public string Image3 { get; set; } = null!;
        public string Image4 { get; set; } = null!;
        public string Image5 { get; set; } = null!;

        public virtual ICollection<Card> Cards { get; set; }
        public virtual ICollection<Watch> Watches { get; set; }
    }
}
