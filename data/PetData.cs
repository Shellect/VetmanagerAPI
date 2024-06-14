using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VetmanagerAPI.data
{
    public class PetData
    {
        public int? TotalCount {  get; set; }

        public PetInfo? Pet { get; set; }
    }
}
