using System.Collections.Generic;

namespace Maxst.Passport
{
    public enum LoginErrorCode
    {
        TOKEN_IS_EMPTY,
    }

    public interface ILoginListener
    {
        void OnSuccess();
        void OnFail(LoginErrorCode errorCode);
    }
}
