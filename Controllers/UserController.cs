using DotnetAPI.Data;
using Microsoft.AspNetCore.Mvc;

namespace DotnetAPI.Controllers;


[ApiController]
[Route("[controller]")]
public class UserController : ControllerBase
{
    private DataContextDapper _dapper;
    public UserController(IConfiguration configuration)
    {
        _dapper = new DataContextDapper(configuration);
    }

    [HttpGet("TestConnection")]
    public DateTime TestConnection()
    {
        return _dapper.LoadDataSingle<DateTime>("SELECT GETDATE()");   
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
