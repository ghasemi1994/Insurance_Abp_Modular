using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp;

namespace Notification.Samples;

[Area(NotificationRemoteServiceConsts.ModuleName)]
[RemoteService(Name = NotificationRemoteServiceConsts.RemoteServiceName)]
[Route("api/notification/example")]
public class ExampleController : NotificationController
{


    [HttpGet]
    public async Task<IActionResult> GetAsync()
    {
        return Ok();
    }

    [HttpGet]
    [Route("authorized")]
    //[Authorize]
    public async Task<IActionResult> GetAuthorizedAsync()
    {
        return Ok();
    }
}
