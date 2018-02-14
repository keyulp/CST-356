using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Lab_Week_5.Data;
using Lab_Week_5.Data.Entities;

namespace Lab_Week_5.Repositories
{
    public class Repository : IRepository
    {
        private readonly DatabaseContext _context;

        public Repository(DatabaseContext context)
        {
            _context = context;
        }

        public User GetUser(int id)
        {
            return _context.Users.Find(id);
        }

        public IEnumerable<User> GetAllUsers()
        {
            return _context.Users;
        }

        public void SaveUser(User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
        }

        public void UpdateUser(User user)
        {
            _context.SaveChanges();
        }

        public void DeleteUser(int id)
        {
            var user = _context.Users.Find(id);

            if (user == null) return;

            _context.Users.Remove(user);
            _context.SaveChanges();
        }

        public Kid GetKid(int id)
        {
            return _context.Kids.Find(id);
        }

        public IEnumerable<Kid> GetKidsForUser(int userId)
        {
            return _context.Kids.Where(kid=> kid.UserId == userId).ToList();
        }

        public void SaveKid(Kid kid)
        {
            _context.Kids.Add(kid);
            _context.SaveChanges();
        }

        public void UpdateKid(Kid kid)
        {
            _context.SaveChanges();
        }

        public void DeleteKid(int id)
        {
            var kid = _context.Kids.Find(id);

            if (kid == null) return;

            _context.Kids.Remove(kid);
            _context.SaveChanges();
        }
    }
}