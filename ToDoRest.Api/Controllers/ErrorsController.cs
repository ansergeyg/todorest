using Microsoft.AspNetCore.Mvc;

namespace ToDoRest.Api.Controllers;

public class ErrorsController: ControllerBase
{
    [Route("/error")]
    public IActionResult Error()
    {
        return Problem();
    }
}