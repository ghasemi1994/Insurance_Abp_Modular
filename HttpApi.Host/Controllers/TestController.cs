using Microsoft.AspNetCore.Mvc;
using PaymentGateway.IGatewayServices;


namespace HttpApi.Host.Controllers;


public class TestController : ApiBaseController
{

    private readonly IGatewayService _gatewayService;
    public TestController(
        IGatewayService gatewayService
        )
    {
        _gatewayService = gatewayService;
    }


    [HttpGet("[action]")]
    public async Task<IActionResult> GetGateway(CancellationToken cancellationToken = default)
    {
        await _gatewayService.GetAsync(cancellationToken);
        return Ok();
    }



}

public class User
{
    public int Id { get; set; }
    public string Name { get; set; }

    public User(int id, string name)
    {
        Id = id;
        Name = name;
    }

}


