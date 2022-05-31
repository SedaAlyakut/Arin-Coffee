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
    public class UserManager : IUserServicecs
    {

        private readonly IUserDal _userDal;
        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }
        public List<User> GetList()
        {
            return _userDal.GetList();
        }
    }
}
