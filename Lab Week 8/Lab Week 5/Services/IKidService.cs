using System.Collections.Generic;
using Lab_Week_5.Models.View;

namespace Lab_Week_5.Services
{
    public interface IKidService
    {
        KidViewModel GetKid(int id);

        IEnumerable<KidViewModel> GetKidsForUser();

        void SaveKid(KidViewModel kid);

        void UpdateKid(KidViewModel user);

        void DeleteKid(int id);
    }
}
