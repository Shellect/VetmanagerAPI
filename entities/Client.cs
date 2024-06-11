using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VetmanagerAPI.entities
{
    public class Client
    {
        public int Client_id { get; set; }
        public string? Last_name { get; set; }
        public string? First_name { get; set; }
        public string? Middle_name { get; set; }
        public string? Email { get; set; }
        public string? Address { get; set; }
        public int? In_blacklist { get; set; }
        public string? Description { get; set; }
        public string? Balance { get; set; }
        public string? Type { get; set; }
        public string? Cell_phone { get; set; }
        public string? Status { get; set; }
        public string? Apartment { get; set; }
        public string? Phone_prefix { get; set; }
        public int? City_id { get; set; }
        public string? City_title { get; set; }
        public int? City_type_id { get; set; }
        public int? Street_id { get; set; }
        public string? Street_title { get; set; }
        public string? Street_type { get; set; }
        public string? Clinic_phone_prefix { get; set; }
        public List<Pet>? Pets { get; set; }

        public string FullName { get { return Last_name + ' ' + First_name + ' ' + Middle_name; } }
    }
}
