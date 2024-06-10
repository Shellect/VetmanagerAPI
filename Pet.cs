using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VetmanagerAPI
{
    public class Pet
    {
        public int? Pet_id { get; set; }
        public string? Alias { get; set; }
        public string? Sex { get; set; }
        public string? Birthday { get; set; }
        public int? Owner_id { get; set; }
        public string? Pet_type { get; set; }
        public string? Breed { get; set; }
        public string? Pet_type_title { get; set; }
        public int? Pet_type_id { get; set; }
    }
}
