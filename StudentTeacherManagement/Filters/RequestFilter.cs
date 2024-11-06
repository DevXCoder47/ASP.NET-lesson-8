using Microsoft.AspNetCore.Mvc.Filters;
using StudentTeacherManagement.Controllers;

namespace StudentTeacherManagement.Filters
{
    public class RequestFilter : IActionFilter
    {
        public void OnActionExecuting(ActionExecutingContext context)
        {
            if(context.Controller.GetType() == typeof(StudentController))
            {
                Console.WriteLine($"Request host: {context.HttpContext.Request.Host}");
                Console.WriteLine($"Request scheme: {context.HttpContext.Request.Scheme}");
                Console.WriteLine($"Request path: {context.HttpContext.Request.Path}");
                Console.WriteLine($"Controller: {context.Controller.GetType()}");
                Console.WriteLine($"Http method: {context.HttpContext.Request.Method}");
                Console.WriteLine($"Http method name: {context.ActionDescriptor.DisplayName}");
                Console.WriteLine($"Method arguments: {string.Join(", ",context.ActionArguments.Keys)}");
            }
        }
        public void OnActionExecuted(ActionExecutedContext context)
        {
            if (context.Controller.GetType() == typeof(StudentController))
            {
                Console.WriteLine("Ping after action");
            }
        }
    }
}
