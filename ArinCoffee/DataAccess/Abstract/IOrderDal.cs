using Core.DataAccess;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Entites;


namespace DataAccess.Abstract
{
    public interface IOrderDal : IEntityRepository<Order>
    {
    }
}
