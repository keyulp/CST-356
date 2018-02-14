using System.Collections.Generic;
using Lab_Week_5.Data.Entities;

namespace Lab_Week_5.Repositories
{
    public interface IRepository
    {
        User GetUser(int id);

        IEnumerable<User> GetAllUsers();

        void SaveUser(User user);

        void UpdateUser(User user);

        void DeleteUser(int id);

        Kid GetKid(int id);

        IEnumerable<Kid> GetKidsForUser(int userId);

        void SaveKid(Kid kid);

        void UpdateKid(Kid kid);

        void DeleteKid(int id);
    }
}