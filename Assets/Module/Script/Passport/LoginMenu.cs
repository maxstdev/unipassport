using Maxst.Settings;
using UnityEngine;
using UnityEngine.UI;

namespace Maxst.Passport
{
    public class LoginMenu : MonoBehaviour, IOpenIDConnectListener
    {
        [SerializeField] private GameObject loginPopupPrefeb;
        [SerializeField] private Button loginFromEmailBtn;
        [SerializeField] private OpenTab openTab;
        [SerializeField] private Button LogoutBtn;
        [SerializeField] private Button ReFreshBtn;
        [SerializeField] private OpenIDConnectArguments openidConnectArguments;

        private OpenIDConnectAdapter OpenIdConnectAdapter;

        public ILoginListener LoginListener { get; set; } = null;

        private void Awake()
        {
#if !UNITY_EDITOR && UNITY_WEBGL
            Debug.Log("LoginMenu Awake UNITY");
#else
            Debug.Log("LoginMenu UNITY");
            loginFromEmailBtn.onClick.AddListener(OnClickloginFromEmailBtn);
            LogoutBtn.onClick.AddListener(OnClickLogoutBtn);
            ReFreshBtn.onClick.AddListener(OnClickRefreshBtn);
            OpenIdConnectAdapter = OpenIDConnectAdapter.Instance;
            OpenIdConnectAdapter.InitOpenIDConnectAdapter(openidConnectArguments, this);
#endif
        }

#if UNITY_EDITOR || !UNITY_WEBGL
        private void OnClickLogoutBtn()
        {
            OpenIdConnectAdapter.OnLogout();
        }

        private void OnClickloginFromEmailBtn()
        {
            var PKCEManagerInstance = PKCEManager.GetInstance();
            var CodeVerifier = PKCEManagerInstance.GetCodeVerifier();
            var CodeChallenge = PKCEManagerInstance.GetCodeChallenge(CodeVerifier);

            OpenIdConnectAdapter.ShowOIDCProtocolLoginPage(CodeVerifier, CodeChallenge);
        }

        private void OnClickRefreshBtn()
        {
            OpenIdConnectAdapter.OnRefreshToken();
        }
#endif

        public void OnSuccess(Token Token)
        {
            Debug.Log($"[LoginMenu] OnSuccess idToken : {Token.idToken}");
            Debug.Log($"[LoginMenu] OnSuccess accessToken : {Token.accessToken}");
            Debug.Log($"[LoginMenu] OnSuccess refreshToken : {Token.refreshToken}");
            LoginListener?.OnSuccess();
        }

        public void OnFail(LoginErrorCode LoginErrorCode)
        {
            Debug.Log($"[LoginMenu] OnFail : {LoginErrorCode}");
            LoginListener?.OnFail(LoginErrorCode);
        }

        public void OnLogout()
        {
            Debug.Log($"[LoginMenu] OnLogout");
        }
    }
}