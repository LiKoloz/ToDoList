using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace ServerApp.Models
{
    public class AuthOptions
    {
        public const string ISSUER = "ServerApp";
        public const string AUDIENCE = "ClientApp";
        const string KEY = "TopSecret_SeCreTKey!123";
        public static SymmetricSecurityKey GetSymmetricSecurityKey() =>
            new SymmetricSecurityKey(Encoding.UTF8.GetBytes(KEY));
    }
}
