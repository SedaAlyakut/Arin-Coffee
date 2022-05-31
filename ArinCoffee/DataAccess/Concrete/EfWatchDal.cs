using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramwork;
using Entities.Models;


namespace DataAccess.Concrete
{
    public class EfWatchDal : EfEntityRepositoryBase<Watch, ArinCoffeeContext>, IWatchDal
    {
    }
}
