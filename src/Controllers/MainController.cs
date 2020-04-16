namespace registry.Controllers
{
    using Microsoft.AspNetCore.Mvc;

    public class MainController : ControllerBase
    {
        public IActionResult Index() => Ok("kukareku");
    }
}