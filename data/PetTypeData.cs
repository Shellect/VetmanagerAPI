using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VetmanagerAPI.data
{
    public class PetTypeData
    {
        public int? TotalCount { get; set; }
        public List<PetType>? PetType { get; set; }
    }
}
