using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Buisness.Abstract
{
    internal interface IFeedBackService
    {
        List<FeedBack> GetList();
    }
}
