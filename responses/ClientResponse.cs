using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VetmanagerAPI.data;

namespace VetmanagerAPI.responses
{
    internal class ClientResponse
    {
        public ClientData? Data { get; set; }
        public bool Success { get; set; }

    }
}
