using BodyProgress.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace BodyProgress.Logic
{
    public class BodyPartsSizeService : IBodyPartsSizeService
    {
        private readonly BodyProgressDbContext _context;

        public BodyPartsSizeService(BodyProgressDbContext context)
        {
            _context = context;
        }
        
        public void CreateUserBody(UserBody userBody, List<BodyPartSize> bodyPartsSize)
        {
            _context.BodyPartsSizes.AddRange(bodyPartsSize);
            _context.UserBodies.Add(userBody);  
            _context.SaveChanges();
        }

        public void UpdateUserBody(List<BodyPartSize> bodyPartSizes)
        {
            _context.BodyPartsSizes.UpdateRange(bodyPartSizes);
            _context.SaveChanges();
        }

        public List<BodyPart> GetAllBodyParts()
        {
            return _context.BodyParts.ToList();
        }

        public List<BodyPartSize> ShowUserBodyParts(string userId)
        {
            return _context.BodyPartsSizes
                .Include(x => x.BodyPart)
                .Where(x => x.UserBody.UserId == userId).ToList();
        }
    }
}
