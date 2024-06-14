using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VetmanagerAPI.data;

namespace VetmanagerAPI.responses
{
    internal class PetResponse
    {
        public bool? Success {  get; set; }
        public string? Message { get; set; }

        public PetData? Data { get; set; }

    }
}
