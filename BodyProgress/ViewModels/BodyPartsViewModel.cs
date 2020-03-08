using BodyProgress.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BodyProgress.ViewModels
{
    public class BodyPartsViewModel
    {
        public List<BodyPartSize> bodyPartsList { get; set; }
        public decimal?[] Result { get; set; }
    }
}
