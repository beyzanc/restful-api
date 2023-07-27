using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using RestfulApi.Business.Services.Abstract;

namespace RestfulApi.Business.Attributes
{
    public class UserAuthorize : Attribute, IAuthorizationFilter
    {


        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var username = context.HttpContext.Request.Headers["username"].ToString();
            var password = context.HttpContext.Request.Headers["password"].ToString();

            var userService = (IUserService)context.HttpContext.RequestServices.GetService(typeof(IUserService));

            if (!userService.Login(username, password))
            {

                context.Result = new UnauthorizedResult();

            }
        }
    }
}
