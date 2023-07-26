using Microsoft.AspNetCore.Mvc;

namespace StateComponents.State.MI.Controllers;

[ApiController]
[Route("mi")]
public class MIController : ControllerBase
{
    [HttpGet(Name = "GetMIData")]
    public string Get()
    {
      return "Hello from the Michigan Controller!";
    }
}
