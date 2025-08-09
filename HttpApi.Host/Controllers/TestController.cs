using Microsoft.AspNetCore.Mvc;



namespace HttpApi.Host.Controllers;


public class TestController : HttpApiController
{

    public TestController()
    {
    }


    [HttpGet("[action]")]
    public async Task<IActionResult> GetOntMainApp(CancellationToken cancellationToken = default)
    {       
        return Ok();
    }



}



