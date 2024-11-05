namespace StudentTeacherManagement
{
    public class MyMiddleware : IMiddleware
    {
        public async Task InvokeAsync(HttpContext ctx, RequestDelegate next)
        {
            Console.WriteLine($"My class middleware:{ctx.Request.Host.Host}:{ctx.Request.Host.Port}");
            await next.Invoke(ctx);
        }
    }
}
