using System.Collections.Generic;
using Lab_Week_5.Models.View;

namespace Lab_Week_5.Services
{
    public interface IUserService
    {
        UserViewModel GetUser(int id);

        IEnumerable<UserViewModel> GetAllUsers();

        void SaveUser(UserViewModel user);

        void UpdateUser(UserViewModel user);

        void DeleteUser(int id);
    }
}
