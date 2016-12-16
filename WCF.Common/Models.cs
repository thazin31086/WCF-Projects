using System.Collections.Generic;

namespace WCF.Common
{
    public class UserModel
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Salt { get; set; }

    }

    public class TokenModel
    {
        public long Id { get; set; }
        public string TokenCode { get; set; }

    }
   
    public class OperationStatus
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public object Results { get; set; }

    }
}
