using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Lab_Week_5.Models;
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

        public Kid GetKid(int id)
        {
            return _context.Kids.Find(id);
        }

        public IEnumerable<Kid> GetKidsForUser()
        {
            return _context.Kids.ToList();
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