namespace registry.Middlewares
{
    using System.Text;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Http;

    public class BotRequestShield
    {
        private readonly RequestDelegate _next;

        public BotRequestShield(RequestDelegate next) => this._next = next;


        public async Task InvokeAsync(HttpContext context)
        {
            if ($"{context.Request.Path}".Contains("php"))
            {
                context.Response.StatusCode = 451;
                await context.Response.WriteAsync("");
                return;
            }
            if ($"{context.Request.Path}".Contains("robots.txt"))
            {
                context.Response.StatusCode = 200;
                var robots = new StringBuilder();

                robots.AppendLine("User-agent: *");
                robots.AppendLine("Disallow: /");

                await context.Response.WriteAsync(robots.ToString());
                return;
            }
            await _next(context);
        }
    }
}