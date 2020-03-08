using BodyProgress.Models;
using System.Collections.Generic;

namespace BodyProgress.Logic
{
    public interface IBodyPartsSizeService
    {
        void CreateUserBody(UserBody userBody, List<BodyPartSize> bodyPartsSize);
        void UpdateUserBody(List<BodyPartSize> bodyPartSizes);
        List<BodyPart> GetAllBodyParts();
        List<BodyPartSize> ShowUserBodyParts(string userId);
        
    }
}
