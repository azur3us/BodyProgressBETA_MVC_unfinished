using BodyProgress.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BodyProgress.Logic
{
    public class BodyPartsSizeService : IBodyPartsSizeService
    {
        private readonly BodyProgressDbContext _context;

        public BodyPartsSizeService(BodyProgressDbContext context)
        {
            _context = context;
        }

        public void CreateBodyParts(List<BodyPartsSize> bodyPartsSize)
        {
            _context.AddRange(bodyPartsSize);
            _context.SaveChanges();
        }

        public List<BodyPartsSize> ShowAllBodyParts(string userId)
        {
            return _context.BodyPartsSizes.Where(b => b.UserId == userId).ToList();
        }
    }
}
