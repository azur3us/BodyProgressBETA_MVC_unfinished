using BodyProgress.Models;
using System.Collections.Generic;

namespace BodyProgress.Logic
{
    public interface IBodyPartsSizeService
    {
        void CreateBodyParts(List<BodyPartsSize> bodyPartsSize);
        List<BodyPartsSize> ShowAllBodyParts(string userId);
    }
}
