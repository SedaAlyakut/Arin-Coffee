using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Buisness.Abstract
{
    public interface IProductService
    {
        List<Product> GetList();
        Product Get(int Id);
        void Add(Product product);
        void Update(Product product);
        void Delete(int productId);
    }
}
