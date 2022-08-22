using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class SubscribeMailManager : ISubscribeMailService
    {
        ISubscribeMailDal _subscribeMailDal;

        public SubscribeMailManager(ISubscribeMailDal subscribeMailDal)
        {
            _subscribeMailDal = subscribeMailDal;
        }

        public SubscribeMail GetById(int id)
        {
            return _subscribeMailDal.GetById(x=>x.MailID==id);
        }

        public List<SubscribeMail> GetList()
        {
            return _subscribeMailDal.List();
        }

        public void TAdd(SubscribeMail t)
        {
            _subscribeMailDal.Insert(t);
        }

        public void TDelete(SubscribeMail t)
        {
            _subscribeMailDal.Delete(t);
        }

        public void TUpdate(SubscribeMail t)
        {
            _subscribeMailDal.Update(t);
        }
    }
}
