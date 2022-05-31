using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramwork;
using Entities.Models;


namespace DataAccess.Concrete
{
    public class EfProductDal : EfEntityRepositoryBase<Product, ArinCoffeeContext>, IProductDal
    {
    }
}
