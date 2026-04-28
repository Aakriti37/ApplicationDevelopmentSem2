namespace Sem2FirstProject.Middlewares
{
    public class RequestLoggerMiddleware(RequestDelegate next, ILogger<RequestLoggerMiddleware> logger)
    {
        public async Task InvokeAsync(HttpContext context)
        {
            // If we need to edit request, then code is written above next
            // Context -> Request -> Method/Path

            var requestDateTime = DateTime.UtcNow;
            var requestMethod = context.Request.Method;
            var path = context.Request.Path;
            var userRole = "Anonymous";


            await next(context);

            // User -> claims -> roles, name, id

            if (context.User?.Identity!.IsAuthenticated == true)
            {
                var roles = context.User.Claims.Where(c => c.Type.Contains("role")).Select(c => c.Value);

                if (roles.Any())
                {
                    userRole = string.Join(",", roles);

                }

            }

            // If we need to edit Response, then code is written below next

            var statusCode = context.Response.StatusCode;
            var responseTime = (DateTime.UtcNow - requestDateTime).TotalMilliseconds;

            logger.LogInformation($"[{requestDateTime}] {requestMethod} {path} | User: {userRole} | status: {statusCode} | Time: {responseTime}ms");



            // Global Exception Handler is Important for Viva



        }
    }
}
