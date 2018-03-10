using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using Lab_Week_4.Data;
using Lab_Week_4.Data.Entities;

namespace Lab9API.Controllers
{
    public class KidsController : ApiController
    {
        private DatabaseContext _context;

        public KidsController()
        {
            _context = new DatabaseContext();
        }

        [HttpGet]
        public IEnumerable<Kid> GetAllKids()
        {
            return _context.Kids.ToList();
        }

        [HttpGet]
        public IHttpActionResult GetKid(int id)
        {
            var kid = _context.Kids.FirstOrDefault((p) => p.Id == id);
            if (kid == null)
            {
                return NotFound();
            }
            return Ok(kid);
        }
    }
}
