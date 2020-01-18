using BodyProgress.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BodyProgress.Logic
{
    public class PartOfBodyService : IPartOfBodyService
    {
        private readonly BodyProgressDbContext _context;

        public PartOfBodyService(BodyProgressDbContext context)
        {
            this._context = context;
        }

        public void AddParfOfBody(PartOfBody partOfBody)
        {
            _context.PartOfBodies.Add(partOfBody);
            _context.SaveChanges();
        }
    }
}
