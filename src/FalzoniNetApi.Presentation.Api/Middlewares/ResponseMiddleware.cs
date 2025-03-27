using FalzoniNetApi.Presentation.Api.Models.Common;

namespace FalzoniNetApi.Presentation.Api.Attributes
{
    public class ResponseMiddleware
    {
        private ResponseModel _model;
        private readonly RequestDelegate _next;

        public ResponseMiddleware(RequestDelegate next)
        {
            _next = next;
            _model = new ResponseModel();
        }

        public async Task Invoke(HttpContext context)
        {
            await _next.Invoke(context);
            
            switch(context.Response.StatusCode)
            {
                case StatusCodes.Status401Unauthorized:
                    await context.Response.WriteAsJsonAsync<ResponseModel>(_model.SetUnauthorized());
                    break;
                case StatusCodes.Status404NotFound:
                    await context.Response.WriteAsJsonAsync<ResponseModel>(_model.SetNotFound());
                    break;
                case StatusCodes.Status403Forbidden:
                    await context.Response.WriteAsJsonAsync<ResponseModel>(_model.SetForbidden());
                    break;
            }
        }
    }
}
