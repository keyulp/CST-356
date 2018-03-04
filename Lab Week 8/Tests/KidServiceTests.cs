using System;
using NUnit.Framework;
using FakeItEasy;
using Lab_Week_5.Data.Entities;
using Lab_Week_5.Repositories;
using Lab_Week_5.Services;


namespace Tests
{
    [TestFixture]
    public class KidServiceTests
    {
        private IRepository _kidRepository;

        [SetUp]
        public void SetUp()
        {
            _kidRepository = A.Fake<IRepository>();
        }

        [Test]
        public void ShouldNotShowBirthdayIn2Weeks()
        {
            A.CallTo(() => _kidRepository.GetKid(A<int>.Ignored)).Returns(new Kid
            {
                Birthday = DateTime.Now.AddDays(50)
            });

            var kidService = new KidService(_kidRepository);
            var kidViewModel = kidService.GetKid(1);

            Assert.IsFalse(kidViewModel.NextBirthday);
        }

        [Test]
        public void ShouldShowBirthdayIn2Weeks()
        {
            A.CallTo(() => _kidRepository.GetKid(A<int>.Ignored)).Returns(new Kid
            {
                Birthday = DateTime.Now.AddDays(2)
            });

            var kidService = new KidService(_kidRepository);
            var kidViewModel = kidService.GetKid(1);

            Assert.IsTrue(kidViewModel.NextBirthday);
        }
    }
}
