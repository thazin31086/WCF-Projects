using System;
using System.Security.Authentication;
using WCF.Common;
using WCF.DATA.DBContext;
using WCF.DATA.Interface;
using WCF.DATA.Repository;

namespace WCF
{
    public class TokenService : ITokenService
    {
        public string GetData(int value)
        {
            return string.Format("You entered: {0}", value);
        }

        public CompositeType GetDataUsingDataContract(CompositeType composite)
        {
            if (composite == null)
            {
                throw new ArgumentNullException("composite");
            }
            if (composite.BoolValue)
            {
                composite.StringValue += "Suffix";
            }
            return composite;
        }

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

        public string GetToken(string username, string password)
        {
            string result;
            try
            {
                using (var dbContext = new WCFDBContext())
                {
                    UserModel _user = new UserModel()
                    {
                        UserName = username, 
                        Password = password
                    };

                    IUserRepository validator = new UserRepository(dbContext);
                    if (!validator.VerifyUser(_user))
                    {
                        throw new InvalidCredentialException("Invalid credentials");
                    }

                    result = new TokenRepository(dbContext).GetToken(_user).Message;
                }
            }
            catch (Exception ex)
            {
                result = ex.Message;
            }
            return result;
        }
    }
}
