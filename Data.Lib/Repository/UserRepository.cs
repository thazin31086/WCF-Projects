using System;
using System.Linq;
using WCF.Common;
using WCF.DATA.Crypto;
using WCF.DATA.DBContext;

namespace WCF.DATA.LIB.Repository
{
    public class UserRepository
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
