using System.Runtime.Serialization;
using System.ServiceModel;
using WCF.Common;

namespace WCF
{
    [ServiceContract]
    public interface ITokenService
    {

        [OperationContract]
        string GetData(int value);

        [OperationContract]
        CompositeType GetDataUsingDataContract(CompositeType composite);

        [OperationContract]
        OperationStatus GetToken(UserModel _user);

        [OperationContract(Name= "GetTokenByPara")]
        string GetToken(string username, string password);
    }
    
    [DataContract]
    public class CompositeType
    {
        bool boolValue = true;
        string stringValue = "Hello ";

        [DataMember]
        public bool BoolValue
        {
            get { return boolValue; }
            set { boolValue = value; }
        }

        [DataMember]
        public string StringValue
        {
            get { return stringValue; }
            set { stringValue = value; }
        }
    }

}
