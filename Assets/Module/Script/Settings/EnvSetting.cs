using UnityEngine;
using Maxst.Passport;

namespace Maxst.Settings
{
    public enum EnvType
    {
        Beta = 0,
    }
    public enum DomainType
    {
        maxst = 0
    }

    public enum LngType
    {
        ko = 0,
        en,
        ja,
    }

    static class EnvUrlTypeExtensions
    {
        public static EnvSetting EnvSetting(this DomainType type)
        {
            return EnvUrlSetting.Instance.EnvSettings[(int)type];
        }
    }

    static class EnvTypeExtensions
    {

        public static string Meta(this EnvType env)
        {
            return env switch
            {
                EnvType.Beta => "-" + env.ToString().ToLower(),
                _ => "",
            };
        }

        public static string Prefix(this EnvType env)
        {
            return env.ToString().ToUpper() + "_";
        }
    }

    [System.Serializable]
    public class EnvData
    {
        public AuthUrlSetting authUrlSetting;

        public OpenIDConnectSetting OpenIDConnectSetting;
    }

    [CreateAssetMenu(fileName = "EnvSetting", menuName = "Packages/Scriptable Dictionary/EnvSetting", order = 1000)]
    public class EnvSetting : ScriptableDictionary<EnvType, EnvData>
    {

    }
}
