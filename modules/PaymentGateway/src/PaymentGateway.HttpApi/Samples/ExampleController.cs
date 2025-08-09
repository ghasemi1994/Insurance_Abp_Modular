using System.Threading.Tasks;
using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using Volo.Abp;

namespace PaymentGateway.Samples;


[Area(PaymentGatewayRemoteServiceConsts.ModuleName)]
[RemoteService(Name = PaymentGatewayRemoteServiceConsts.RemoteServiceName)]
[Route("api/payment-gateway")]
[ApiVersion("1.0", Deprecated = true)]
public class ExampleController : PaymentGatewayController
{
    [HttpGet("get-ipg")]
    public async Task<IActionResult> GetAsync()
    {
        return Ok("this is ipg test");
    }

}
