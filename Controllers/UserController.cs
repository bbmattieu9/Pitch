using Microsoft.AspNetCore.Mvc;

namespace DotnetAPI.Controllers;


[ApiController]
[Route("[controller]")]
public class UserController : ControllerBase
{
    public UserController()
    {
    }
    
    
    [HttpGet(Name = "GetUsers/{inputValue}")]
    public string[] GetUsers(string inputValue)
    {
        string[] responsearray =
        [
            "test1",
            "test2",
            inputValue
        ];
        return responsearray;
    }
}
