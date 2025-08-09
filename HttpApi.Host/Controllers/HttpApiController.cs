
using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp;
using Volo.Abp.AspNetCore.Mvc;

namespace HttpApi.Host.Controllers;


[Route("api/[controller]")]
[ApiController]
[RemoteService(Name = "Name")]
public class HttpApiController : AbpController
{

}
