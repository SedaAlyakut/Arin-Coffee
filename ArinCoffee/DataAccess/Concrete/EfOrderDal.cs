using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramwork;
using Entities.Models;


namespace DataAccess.Concrete
{
    public class EfOrderDal : EfEntityRepositoryBase<Order, ArinCoffeeContext>, IOrderDal
    {
    }
}
