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
}
