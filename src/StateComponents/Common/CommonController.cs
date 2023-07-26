using Microsoft.AspNetCore.Mvc;

namespace StateComponents.Common.Controllers;

[ApiController]
[Route("common")]
public class CommonController : ControllerBase
{
    [HttpGet(Name = "GetCommonData")]
    public string Get()
    {
      return "Hello from the State Common Controller!";
    }
}
