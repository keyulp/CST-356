using System.Collections.Generic;
using Lab_Week_5.Data.Entities;

namespace Lab_Week_5.Repositories
{
    public interface IRepository
    {
        Kid GetKid(int id);

        IEnumerable<Kid> GetKidsForUser();

        void SaveKid(Kid kid);

        void UpdateKid(Kid kid);

        void DeleteKid(int id);
    }
}