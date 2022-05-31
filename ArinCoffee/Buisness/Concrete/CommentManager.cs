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
    public class CommentManager: ICommentService
    {
        private readonly ICommentDal _commentDal;
        public CommentManager(ICommentDal commentDal)
        {
            _commentDal = commentDal;
        }
        public List<Comment> GetList()
        {
            return _commentDal.GetList();
        }
    }
}
