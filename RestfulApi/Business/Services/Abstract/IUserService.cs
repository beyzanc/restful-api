using RestfulApi.Models;

namespace RestfulApi.Business.Services.Abstract
{
    public interface IUserService
    {
        bool Login (string username, string password);

    }
}
