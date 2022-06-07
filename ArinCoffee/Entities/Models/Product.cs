using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Core.Entites;


namespace Entities.Models
{
    [Table("Product", Schema = "dbo")]
public partial class Product : IEntity
    {
        public Product()
        {
            Cards = new HashSet<Card>();
            Watches = new HashSet<Watch>();
        }
        [Key]
        public int ProductId { get; set; }
        public string ProductName { get; set; } 
        public int? Weight { get; set; }
        public int? Status { get; set; }
        public string Image1 { get; set; } 
        public string Image2 { get; set; } 
        public string Image3 { get; set; } 
        public string Image4 { get; set; }  
        public string Image5 { get; set; } 
        public int? Price { get; set; } 
        public string Category { get; set; }

        public virtual ICollection<Card> Cards { get; set; }
        public virtual ICollection<Watch> Watches { get; set; }
    }
}
