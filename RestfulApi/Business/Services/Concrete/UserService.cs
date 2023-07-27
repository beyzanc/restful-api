using RestfulApi.Business.Services.Abstract;
using RestfulApi.Models;

namespace RestfulApi.Business.Services.Concrete
{

    public class UserService : IUserService
    {


        private List<User> _users;
        public UserService() {

            _users = new List<User>()
            {
                new User { Username = "test_test", Password = "test123!"}

            };
             
        }

        public bool Login(string username, string password)
        {
            foreach (var user in _users)
            {
                if (user.Username == username && user.Password == password) {

                    return true;
                
                }

            }
            return false;

        }

    }
}
