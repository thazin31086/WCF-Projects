using System.Collections.Generic;
using System.Runtime.Serialization;

namespace WCF.Common
{
    [DataContract]
    public class UserModel
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string UserName { get; set; }
        [DataMember]
        public string Password { get; set; }
        [DataMember]
        public string Salt { get; set; }

    }

    [DataContract]
    public class TokenModel
    {
        [DataMember]
        public long Id { get; set; }

        [DataMember]
        public string TokenCode { get; set; }

    }
        
    [DataContract]
    public class OperationStatus
    {
        [DataMember]
        public bool Success { get; set; }

        [DataMember]
        public string Message { get; set; }

        [DataMember]
        public object Results { get; set; }

    }
}
