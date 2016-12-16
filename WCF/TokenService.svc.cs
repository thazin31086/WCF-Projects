using System;
using System.Security.Authentication;
using System.ServiceModel;
using System.ServiceModel.Web;
using WCF.Common;
using WCF.DATA.DBContext;
using WCF.DATA.Interface;
using WCF.DATA.Repository;

namespace WCF
{
    [ServiceContract]
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class TokenService
    {
        [OperationContract]
        //[WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
        public OperationStatus GetToken(UserModel _user)
        {
            OperationStatus result = new OperationStatus();
            try
            {
                using (var dbContext = new WCFDBContext())
                {
                    IUserRepository validator = new UserRepository(dbContext);
                    if (!validator.VerifyUser(_user))
                    {
                        throw new InvalidCredentialException("Invalid credentials");                        
                    }

                    result = new TokenRepository(dbContext).GetToken(_user);

                }
            }           
            catch (Exception ex)
            {
                result.Message = ex.Message;                 
            }
            return result;            
        }
    }
}