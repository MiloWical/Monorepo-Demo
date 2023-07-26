using Microsoft.AspNetCore.Mvc;

namespace StateComponents.State.VA.Controllers;

[ApiController]
[Route("va")]
public class VAController : ControllerBase
{
    [HttpGet(Name = "GetVAData")]
    public string Get()
    {
      return "Hello from the Virginia Controller!";
    }
}
