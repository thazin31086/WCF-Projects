using System;
using System.Security.Authentication;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Web;
using WCF.Common;

namespace WCF
{
    [ServiceContract]
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "SomeService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select SomeService.svc or SomeService.svc.cs at the Solution Explorer and start debugging.
    public class SomeService
    {  
        [OperationContract]
        //[WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
        public OperationStatus SomeMethod()
        {
            OperationStatus result = new OperationStatus();
            try
            {
                var token = HttpContext.Current.Request.Headers["Token"];
                if (token == null)
                {
                    throw new AuthenticationException("Access Denied.");
                }
                else
                {
                    result.Message =  "Do Some Work";
                    result.Success = true;
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
