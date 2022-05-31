using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramwork;
using Entities.Models;


namespace DataAccess.Concrete
{
    internal class EfOrderDal : EfEntityRepositoryBase<Order, ArinCoffeeContext>, IOrderDal
    {
    }
}
