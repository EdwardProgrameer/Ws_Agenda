using System.Security.Cryptography;
using System.Text;

namespace Ws_Agenda.Helpers
{
    public class Encrypt
    {
        public static string Key = "NETJ3iSLWrKX%*Ppjc";
        public static string ConvertToEncrypt(string password)
        {

            password += Key;
            var passwordBytes = Encoding.UTF8.GetBytes(password);
            return Convert.ToBase64String(passwordBytes);
        }
        public static string ConvertToDescrypt(string base64EncodeData)
        {
            var base64EncodeBytes = Convert.FromBase64String(base64EncodeData);
            var result = Encoding.UTF8.GetString(base64EncodeBytes);
            result = result.Substring(0, result.Length - Key.Length);
            return result;
        }
    }
}
