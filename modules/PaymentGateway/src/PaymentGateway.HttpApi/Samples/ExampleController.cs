using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp;

namespace PaymentGateway.Samples;

[Area(PaymentGatewayRemoteServiceConsts.ModuleName)]
[RemoteService(Name = PaymentGatewayRemoteServiceConsts.RemoteServiceName)]
[Route("api/payment-gateway/example")]
public class ExampleController : PaymentGatewayController
{



    [HttpGet]
    public async Task<IActionResult> GetAsync()
    {
        return Ok();
    }

    [HttpGet]
    [Route("authorized")]
    [Authorize]
    public async Task<IActionResult> GetAuthorizedAsync()
    {
        return Ok();
    }
}
