using OyunPazari.Model.Entities;
using OyunPazari.Service.Abstract;
using System;

namespace OyunPazari.Service.Concrete
{
    public class AppUserService:BaseService<AppUser>
    {
        public AppUser GetuserByUserName(string userName)
        {
            return GetByDefault(user => user.UserName == userName);
        }

        public Guid GetIDByUserName(string userName) => GetByDefault(user => user.UserName == userName).ID;

    }
}
