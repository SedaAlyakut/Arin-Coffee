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
    public class FeedBackManager : IFeedBackService
    {

        private readonly IFeedBackDal _feedbackDal;
        public FeedBackManager(IFeedBackDal feedbackDal)
        {
            _feedbackDal = feedbackDal;
        }
        public List<FeedBack> GetList()
        {
            return _feedbackDal.GetList();
        }
    }
}
