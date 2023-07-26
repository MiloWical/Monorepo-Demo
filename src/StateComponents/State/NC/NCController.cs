using Microsoft.AspNetCore.Mvc;

namespace StateComponents.State.NC.Controllers;

[ApiController]
[Route("nc")]
public class NCController : ControllerBase
{
    [HttpGet(Name = "GetNCData")]
    public string Get()
    {
      return "Hello from the North Carolina Controller!";
    }
}
