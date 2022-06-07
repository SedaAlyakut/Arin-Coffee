using Buisness.Abstract;
using DataAccess.Abstract;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Buisness.Concrete
{
    public class ProductManager : IProductService
    {

        private readonly IProductDal _productDal;
        public ProductManager(IProductDal productDal)
        {
            _productDal = productDal;
        }
        public List<Product> GetList()
        {
            return _productDal.GetList();
        }
        public Product Get(int Id)
        {
            return _productDal.Get(q => q.ProductId == Id);
        }
        public void Add(Product product)
        {
            _productDal.Add(product);
        }
    }
}
