﻿namespace registry.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    [ApiController]
    public class MainController : ControllerBase
    {
        [HttpGet("/")]
        public IActionResult Fetch() 
            => RedirectPermanent("https://runic.cloud");
    }
}