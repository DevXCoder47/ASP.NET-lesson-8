namespace StudentTeacherManagement.Middlewares
{
    public class MyMiddleware
    {
        private readonly RequestDelegate _next;
        public MyMiddleware(RequestDelegate next)
        {
            _next = next;
        }
        public async Task InvokeAsync(HttpContext ctx)
        {
            Console.WriteLine($"My class middleware: {ctx.Request.Host.Host} : {ctx.Request.Host.Port}");
            await _next.Invoke(ctx);
        }
    }
}
