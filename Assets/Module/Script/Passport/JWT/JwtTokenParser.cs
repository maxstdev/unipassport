using Newtonsoft.Json;
using System;
using System.Text;
using UnityEngine;

namespace Maxst.Token
{
    public class JwtTokenParser
    {
        public static JwtTokenBody BodyDecode(string accessToken)
        {
            try
            {
                if (accessToken == null) return null;

                var splitArray = accessToken.Split(char.Parse("."));
                var body = splitArray[1];
                switch (splitArray[1].Length % 4)
                {
                    case 3:
                        body += "=";
                        break;
                    case 2:
                        body += "==";
                        break;
                    case 1:
                        body += "===";
                        break;
                }
                byte[] decodedBytes = Convert.FromBase64String(body);
                var json = Encoding.UTF8.GetString(decodedBytes);
                return JsonConvert.DeserializeObject<JwtTokenBody>(json);
            }
            catch (Exception e)
            {
                Debug.Log("Decode Error:" + e.StackTrace);
                return null;
            }
        }
    }
}
