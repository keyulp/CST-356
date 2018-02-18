using System;
using System.Collections.Generic;
using Lab_Week_5.Data.Entities;
using Lab_Week_5.Models.View;
using Lab_Week_5.Repositories;

namespace Lab_Week_5.Services
{
    public class KidService : IKidService
    {
        private readonly IRepository _repository;

        public KidService(IRepository repository)
        {
            _repository = repository;
        }

        public KidViewModel GetKid(int id)
        {
            var kid = _repository.GetKid(id);
            return MapToKidViewModel(kid);
        }

        public IEnumerable<KidViewModel> GetKidsForUser(int userId)
        {
            var kidViewModels = new List<KidViewModel>();

            var kidList = _repository.GetKidsForUser(userId);

            foreach (var kid in kidList)
            {
                kidViewModels.Add(MapToKidViewModel(kid));
            }

            return kidViewModels;
        }

        public void SaveKid(KidViewModel kidViewModel)
        {
            var kid = MapToKid(kidViewModel);
            _repository.SaveKid(kid);
        }

        public void UpdateKid(KidViewModel kidViewModel)
        {
            var kid = _repository.GetKid(kidViewModel.Id);

            CopyToKid(kidViewModel, kid);

            _repository.UpdateKid(kid);
        }

        public void DeleteKid(int id)
        {
            _repository.DeleteKid(id);
        }

        private Kid MapToKid(KidViewModel kidViewModel)
        {
            return new Kid
            {
                Id = kidViewModel.Id,
                FirstName = kidViewModel.FirstName,
                LastName = kidViewModel.LastName,
                Age = kidViewModel.Age,
                Parent1 = kidViewModel.Parent1,
                Parent2 = kidViewModel.Parent2,
                Birthday = kidViewModel.Birthday,
                UserId = kidViewModel.UserId
            };
        }

        void NextBirthday(KidViewModel kidViewModel)
        {
            kidViewModel.NextBirthday = (kidViewModel.Birthday - DateTime.Now).Days < 14;
        }

        private KidViewModel MapToKidViewModel(Kid kid)
        {
            var kidViewModel = new KidViewModel
            {
                Id = kid.Id,
                FirstName = kid.FirstName,
                LastName = kid.LastName,
                Age = kid.Age,
                Parent1 = kid.Parent1,
                Parent2 = kid.Parent2,
                Birthday = kid.Birthday,
                UserId = kid.UserId
            };

            NextBirthday(kidViewModel);
            
            ;

            return kidViewModel;
        }

        private void CopyToKid(KidViewModel kidViewModel, Kid kid)
        {
            kid.Id = kidViewModel.Id;
            kid.FirstName = kidViewModel.FirstName;
            kid.LastName = kidViewModel.LastName;
            kid.Age = kidViewModel.Age;
            kid.Parent1 = kidViewModel.Parent1;
            kid.Parent2 = kidViewModel.Parent2;
            kid.Birthday = kidViewModel.Birthday;
            kid.UserId = kidViewModel.UserId;
        }
    }
}