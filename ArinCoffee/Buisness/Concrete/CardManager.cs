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
    public class CardManager : ICardService
    {
        private readonly ICardDal _cardDal;
        public CardManager(ICardDal cardDal)
        {
            _cardDal = cardDal;
        }
        public List<Card> GetList()
        {
            return _cardDal.GetList();
        }
    }
}
