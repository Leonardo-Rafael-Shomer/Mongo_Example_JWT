using Microsoft.AspNetCore.Mvc;
using MongoExample.Models;
using MongoExample.Services;

namespace MongoExample.Controllers;

[Controller]
[Route("[controller]")]
public class LoginController : ControllerBase
{
    private readonly MongoDbService _mongoDBService;
    public LoginController(MongoDbService mongoDBService)
    {
        _mongoDBService = mongoDBService;
    }
    
    [HttpPost]
    public Task<IActionResult> Post([FromBody] JwtToken jwtToken)
    {

        var acessToken = TokenGenerator.GenerateToken(jwtToken.Imei, jwtToken.IdMobile, jwtToken.UuidFirebase);
        return Task.FromResult<IActionResult>(Ok(acessToken));
    }

}
