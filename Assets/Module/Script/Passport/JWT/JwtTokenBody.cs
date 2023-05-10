using Newtonsoft.Json;

namespace Maxst.Token
{
    public class JwtTokenBody
    {
        [JsonProperty("exp")]
        public long exp;
        [JsonProperty("iat")]
        public long iat;
        [JsonProperty("auth_time")]
        public long authTime;
        [JsonProperty("jti")]
        public string jti;
        [JsonProperty("iss")]
        public string iss;
        [JsonProperty("sub")]
        public string sub;
        [JsonProperty("typ")]
        public string typ;
        [JsonProperty("azp")]
        public string azp;
        [JsonProperty("nonce")]
        public string nonce;
        [JsonProperty("session_state")]
        public string sessionState;
        [JsonProperty("at_hash")]
        public string atHash;
        [JsonProperty("acr")]
        public string acr;
        [JsonProperty("sid")]
        public string sid;
        [JsonProperty("email_verified")]
        public bool emailVerified;
        [JsonProperty("name")]
        public string name;
        [JsonProperty("preferred_username")]
        public string preferredUsername;
        [JsonProperty("given_name")]
        public string givenName;
        [JsonProperty("family_name")]
        public string familyName;
        [JsonProperty("email")]
        public string email;
    }
}
