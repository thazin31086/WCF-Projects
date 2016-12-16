using System;
using System.Linq;
using WCF.Common;
using WCF.DATA.Crypto;
using WCF.DATA.DBContext;
using WCF.DATA.Interface;

namespace WCF.DATA.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly WCFDBContext _DbContext;

        public UserRepository(WCFDBContext dbContext)
        {
            _DbContext = dbContext;
        }

        public bool VerifyUser(UserModel user)
        {
            var _user = _DbContext.Users.SingleOrDefault(u => u.UserName.Equals(user.UserName, StringComparison.CurrentCultureIgnoreCase));
            return _user != null && Hash.Compare(user.Password, user.Salt, user.Password, Hash.DefaultHashType, Hash.DefaultEncoding);
        }
    }
}
