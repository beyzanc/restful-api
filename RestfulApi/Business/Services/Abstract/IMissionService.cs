using RestfulApi.Models;

namespace RestfulApi.Business.Services.Abstract
{
    public interface IMissionService
    {

        string CustomDateFormat(Mission mission);
        List<Mission> GetAllMissions();
    }
}
