using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models.DTO
{
    public class IndexViewModel
    {
       public List<Product> products { get; set; }
       public List<Order> orders { get; set; }
    }
}
