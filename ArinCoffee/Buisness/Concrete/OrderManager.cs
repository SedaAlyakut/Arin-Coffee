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
    public class OrderManager : IOrderService
    {
        private readonly IOrderDal _orderDal;
        public OrderManager(IOrderDal orderDal)
        {
            _orderDal = orderDal;
        }
        public List<Order> GetList()
        {
            return _orderDal.GetList();
        }
    }
}

