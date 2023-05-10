namespace Maxst.Passport
{
    public interface IOpenIDConnectListener
    {
        void OnSuccess(Token Token);
        void OnFail(LoginErrorCode LoginErrorCode);
        void OnLogout();
    }
}
