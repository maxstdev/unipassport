# unipassport

unipassport package is for developing Unity apps that target native platforms.

## 개요
PASSPORT 로그인은 소셜 미디어 계정(구글, 페이스북 등)처럼 PASSPORT 계정으로 간편하게 로그인할 수 있습니다. PASSPORT 로그인 OAuth 2.0 프로토콜을 기반으로 작동합니다. 사용자가 서비스 로그인 시, PASSPORT 계정으로 로그인할 수 있도록 합니다. 사용자의 가입 절차를 간편화하고, PASSPORT 계정 정보를 이용할 수 있으므로, 사용자 친화적인 서비스를 제공할 수 있습니다. 또한 사용자의 로그인 정보를 안전하게 보호할 수 있습니다. 

## 소개
PASSPORT 로그인은 PASSPORT 계정으로 다양한 서비스에 로그인할 수 있도록 하는 소셜 로그인 서비스입니다. 이를 통해 복잡한 인증, 인가 과정을 간소화하고 안전하게 처리할 수 있을 뿐만 아니라, 맥스버스에서 제공하는 다양한 API를 사용할 수 있습니다. unipassport는 해당 기능을 구현할수 있도록 제공합니다.

### SampleCode

기본 설정  

```
public class SampleScript : MonoBehaviour, IOpenIDConnectListener
{
    [SerializeField] private OpenIDConnectArguments openidConnectArguments;
    private OpenIDConnectAdapter OpenIdConnectAdapter;
    public ILoginListener LoginListener { get; set; } = null;

    private void Awake()
    {
        OpenIdConnectAdapter = OpenIDConnectAdapter.Instance;
        OpenIdConnectAdapter.InitOpenIDConnectAdapter(openidConnectArguments, this);
    }

    public void OnFail(LoginErrorCode LoginErrorCode)
    {
    }

    public void OnLogout()
    {
    }

    public void OnSuccess(Token Token)
    {
    }
}
```

로그인 요청   

```
var PKCEManagerInstance = PKCEManager.GetInstance();
var CodeVerifier = PKCEManagerInstance.GetCodeVerifier();
var CodeChallenge = PKCEManagerInstance.GetCodeChallenge(CodeVerifier);

OpenIdConnectAdapter.ShowOIDCProtocolLoginPage(CodeVerifier, CodeChallenge);
```

unipassport의 상세 가이드는 아래 링크를 참고하십시오.

### Unity Version
* Unity 2021.3.14f1

### Platform
* Window
* Android
* iOS

## Docs about unipassport
You can check docs and guides at [unipassport](https://doc.maxverse.io/passport-login-sdk)

## License
The source code for the site is licensed under the MIT license, which you can find in the [License.txt](https://github.com/maxstdev/unipassport/blob/main/LICENSE.txt) file.

### Third Party
* [UniRx](https://github.com/neuecc/UniRx.git) : [MIT license](https://github.com/neuecc/UniRx/blob/master/LICENSE)
* [UniTask](https://github.com/Cysharp/UniTask.git) : [MIT license](https://github.com/Cysharp/UniTask/blob/master/LICENSE)
