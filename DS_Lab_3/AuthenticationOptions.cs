using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace DS_Lab_3;

public class AuthenticationOptions
{
    public const string ISSUER = "MyAuthServer";
    public const string AUDIENCE = "MyAuthClient";
    private const string KEY = "bloodforthebloodgodskullsfortheskullthrone!!!";

    public static SymmetricSecurityKey GetSymmetricSecurityKey() =>
        new SymmetricSecurityKey(Encoding.UTF8.GetBytes(KEY));
}