using Microsoft.AspNetCore.Mvc;
using Scout.Application.Commands;

namespace Scout.WebAPI.Controllers;


[Route("objects")]
public class ObjectController : BaseController
{
    [HttpPost]
    public async Task<ActionResult> Post(CreateScoutObject command)
    {
        await Mediator.Send(command);
        return Ok();
    }
}