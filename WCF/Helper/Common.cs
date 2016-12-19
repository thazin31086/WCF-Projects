using WCF.Common;
using WCF.DATA.DBContext;
using WCF.DATA.Interface;
using WCF.DATA.Repository;
using WCF.Common;

namespace WCF.Helper
{
    public class Common
    {
        public OperationStatus VerifyToken(string token)
        {
            OperationStatus result = new OperationStatus();

            if (string.IsNullOrEmpty(token))
               result.Message = "Access Denied.";

            using (var dbContext = new WCFDBContext())
            {
                ITokenRepository tokenrepo = new TokenRepository(dbContext);
                return tokenrepo.VerifyToken(token);
            }
        }
    }
}