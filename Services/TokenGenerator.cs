using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace MongoExample.Services;

public class TokenGenerator
{
    public static string GenerateToken(string imei, string firebaseUid, string idMobile)
    {
        var tokenHandler = new JwtSecurityTokenHandler()
        {
            SetDefaultTimesOnTokenCreation = false
        };

        var key = Encoding.UTF8.GetBytes(DotNetEnv.Env.GetString("JWT_TOKEN_SECRET_KEY"));

        var claims = new List<Claim>
        {
            new("IMEI", imei),
            new("UID_FIREBASE", firebaseUid),
            new("UID_MOBILE", idMobile),
            new("TOKEN",Guid.NewGuid().ToString()),
            //new(JwtRegisteredClaimNames.Iat, DateTimeOffset.Now.ToUnixTimeMilliseconds().ToString()),
        };
        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(claims),
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key),SecurityAlgorithms.HmacSha256Signature)
        };
        
        var token = tokenHandler.CreateJwtSecurityToken(tokenDescriptor);
        
        return tokenHandler.WriteToken(token);
    }

}